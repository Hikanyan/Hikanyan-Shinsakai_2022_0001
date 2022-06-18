
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
//Serializable �����ɂ��C���X�y�N�^�[��ŃN���X�ɃT�u�v���p�e�B�[�𖄂ߍ��ނ��Ƃ������܂��B
//���O�ƎO�p�L�����\������v���p�e�B�[��W�J�ł��܂��B
public class Data
{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public Note[] notes;
}

[Serializable]
public class Note
{
    public int type;
    public int num;
    public int block;
    public int LPB;
}
/// <summary>
/// Json�t�@�C����ǂݎ����
/// �m�[�c�𐶐�����
/// </summary>


public class NotesManager : MonoBehaviour
{
    /// <summary>�m�[�c�̑��� </summary>
    public int _noteNum;
    /// <summary>���Ԗڂ̃��[���Ƀm�[�c�������Ă��邩 </summary>
    public List<int> _laneNum = new();
    /// <summary>Notes�̎�� </summary>
    public List<int> _noteType = new();
    /// <summary>�m�[�c��������Əd�Ȃ鎞�� </summary>
    public List<float> _notesTime = new();
    /// <summary>�m�[�c�̃I�u�W�F�N�g</summary>
    public List<GameObject> _notesObject = new();


    /// <summary>�Ȗ�</summary>
    [SerializeField] private string _sonfName;//�Ȗ�������֐����쐬����B�ۑ�����Json�̖��O������
    /// <summary>�V���O���m�[�c�̃I�u�W�F�N�g</summary>
    [SerializeField] private GameObject _noteObject;//�m�[�c�̃v���n�u������
    /// <summary>�����O�m�[�c�̃I�u�W�F�N�g</summary>
    [SerializeField] private GameObject _noteLongObject;//�����O�m�[�c�̃v���n�u������
    /// <summary>�m�[�c�̃X�s�[�h</summary>
    [SerializeField] private float _notesSeed;//�m�[�c�̃X�s�[�h
    /// <summary>�m�[�c������Ă���P�\ </summary>
    [SerializeField] public float _notesOffset;//�m�[�c������Ă���x������

    private void Awake()//�I�u�W�F�N�g���L���ɂ��ꂽ�Ƃ���񂾂��Ăяo�����
    {
        _noteNum = 0;//�m�[�c��0�ɏ�����
        StartCoroutine("Delay");//_notesOffset�b���NotesLoad(_sonfName)���Ăяo��
    }

    //�L���ɂ��ꂽ��Json�t�@�C����ǂݍ��݁A���W���v�Z���Ĕz�u����
    //Update���g��Ȃ����R��Play���ɃY���Ȃ��悤�ɂ��邽��

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(_notesOffset);
        NotesLoad(_sonfName);
    }


    private void NotesLoad(string SongName)//�m�[�c
    {
        string inputString = Resources.Load<TextAsset>(SongName).ToString();//���̓��.json�t�@�C����ǂݍ���
        Data inputJson = JsonUtility.FromJson<Data>(inputString);           //


        _noteNum = inputJson.notes.Length;//�m�[�c���̍��v


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        for (int i = 0; i < inputJson.notes.Length; i++)//�m�[�c�̈ʒu������z�u���Ă���
        {
            float syousetu = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB);                                      //�ꏬ�߂̒���
            float beatSec = syousetu * (float)inputJson.notes[i].LPB;                                                   //�m�[�c�̒���
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB) + inputJson.offset + 0.01f; //�m�[�c�̍~���Ă��鎞��
           
            _notesTime.Add(time);                    //NotesTime���X�g�ɒǉ�
            _laneNum.Add(inputJson.notes[i].block);  //LaneNum���X�g�ɒǉ�
            _noteType.Add(inputJson.notes[i].type);  // NoteType���X�g�ɒǉ�

            float z = _notesTime[i] * _notesSeed;     //�m�[�c�̐��������ʒu
            
            _notesObject.Add(Instantiate(_noteObject, new Vector3(inputJson.notes[i].block - 1.5f, 0.55f,z), Quaternion.identity));//�m�[�c�����E�C���X�^���X��
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}


/*
 * �Q�l����
 * 
 * 
 * https://qiita.com/irigoma77/items/ee15b3e748596aa6d086 
 * https://www.youtube.com/watch?v=WWeyn4TI0lI&t=327s
 * https://www.youtube.com/watch?v=TnKnwLIiY_8
 * 
 * 
 * 
 */