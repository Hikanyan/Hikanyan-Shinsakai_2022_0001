
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



public class NotesManager : MonoBehaviour
{
    public int _noteNum;//�m�[�c�̑���

    public List<int> _laneNum = new();//���Ԗڂ̃��[���Ƀm�[�c�������Ă��邩
    public List<int> _noteType = new();//Notes�̎��
    public List<float> _notesTime = new();//�m�[�c��������Əd�Ȃ鎞��
    public List<GameObject> _notesObject = new();//GameObject

    
   
    [SerializeField] private string _sonfName;//�Ȗ�������֐����쐬����B�ۑ�����Json�̖��O������
    [SerializeField] private GameObject _noteObject;//�m�[�c�̃v���n�u������
    [SerializeField] private GameObject _noteLongObject;//�����O�m�[�c�̃v���n�u������
    [SerializeField] private float _notesSeed;//�m�[�c�̃X�s�[�h

    private void Awake()//�I�u�W�F�N�g���L���ɂ��ꂽ�Ƃ���񂾂��Ăяo�����
    {
        _noteNum = 0;//�m�[�c��0�ɏ�����
        NotesLoad(_sonfName);//NotesLoad(_sonfName)���Ăяo��
    }

    //�L���ɂ��ꂽ��Json�t�@�C����ǂݍ��݁A���W���v�Z���Ĕz�u����
    //Update���g��Ȃ����R��Play���ɃY���Ȃ��悤�ɂ��邽��




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