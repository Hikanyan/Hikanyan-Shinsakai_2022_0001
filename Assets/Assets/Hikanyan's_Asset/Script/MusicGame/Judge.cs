using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Judge : MonoBehaviour
{
    [SerializeField] private GameObject[] _judgeObjects;//�v���C���[�ɔ����`����I�u�W�F�N�g
    [SerializeField] NotesManager _notesManager;       //�X�N���v�g�u_notesManager�v������ϐ�
    [SerializeField] Timer _timer;                     //�X�N���v�g�u_timer�v������֐�

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))//�����AD�L�[�������ꂽ�Ƃ�
        {
            if(_notesManager._notesTime.Count > 0 && _notesManager._laneNum[0] == 0)
            /*
             * _notesManager._notesTime.Count��0�ȏォ��
             * _notesManager._laneNum[0](���[��0)��0�̂Ƃ�
             * _notesManager._notesTime.Count�̓m�[�c�������Ȃ����Ƃ���
             * ��������Ȃ��悤�ɂ��邽��
             */
            {
                Judgment(GetABS(Timer.instance.RealTime - _notesManager._notesTime[0]));
                /*
                 * �{���̃m�[�c��@���ꏊ�Ǝ��ۂɒ@�����ꏊ���ǂꂭ�炢�Y���Ă��邩�����߂�
                 * ���̐�Βl��Judgment�֐��ɑ���
                 */
            }
        }
        if (Input.GetKeyDown(KeyCode.F))//�����AF�L�[�������ꂽ�Ƃ�
        {
            /*
             * _notesManager._notesTime.Count��0�ȏォ��
             * _notesManager._laneNum[0](���[��1)��1�̂Ƃ�
             * _notesManager._notesTime.Count�̓m�[�c�������Ȃ����Ƃ���
             * ��������Ȃ��悤�ɂ��邽��
             */
            if (_notesManager._notesTime.Count > 0 && _notesManager._laneNum[0] == 1)
            {
                Judgment(GetABS(Timer.instance.RealTime - _notesManager._notesTime[0]));
                /*
                 * �{���̃m�[�c��@���ꏊ�Ǝ��ۂɒ@�����ꏊ���ǂꂭ�炢�Y���Ă��邩�����߂�
                 * ���̐�Βl��Judgment�֐��ɑ���
                 */
            }
        }
        if (Input.GetKeyDown(KeyCode.J))//�����AJ�L�[�������ꂽ�Ƃ�
        {
            /*
             * _notesManager._notesTime.Count��0�ȏォ��
             * _notesManager._laneNum[0](���[��2)��2�̂Ƃ�
             * _notesManager._notesTime.Count�̓m�[�c�������Ȃ����Ƃ���
             * ��������Ȃ��悤�ɂ��邽��
             */
            if (_notesManager._notesTime.Count > 0 && _notesManager._laneNum[0] == 2)
            {
                Judgment(GetABS(Timer.instance.RealTime - _notesManager._notesTime[0]));
                /*
                 * �{���̃m�[�c��@���ꏊ�Ǝ��ۂɒ@�����ꏊ���ǂꂭ�炢�Y���Ă��邩�����߂�
                 * ���̐�Βl��Judgment�֐��ɑ���
                 */
            }
        }
        if (Input.GetKeyDown(KeyCode.K))//�����AK�L�[�������ꂽ�Ƃ�
        {/*
             * _notesManager._notesTime.Count��0�ȏォ��
             * _notesManager._laneNum[0](���[��3)��3�̂Ƃ�
             * _notesManager._notesTime.Count�̓m�[�c�������Ȃ����Ƃ���
             * ��������Ȃ��悤�ɂ��邽��
             */
            if (_notesManager._notesTime.Count > 0 && _notesManager._laneNum[0] == 3)
            {
                Judgment(GetABS(Timer.instance.RealTime - _notesManager._notesTime[0]));
                /*
                 * �{���̃m�[�c��@���ꏊ�Ǝ��ۂɒ@�����ꏊ���ǂꂭ�炢�Y���Ă��邩�����߂�
                 * ���̐�Βl��Judgment�֐��ɑ���
                 */
            }
        }
        if (_notesManager._notesTime.Count > 0)//_notesManager.NotesTime��1�ȏ�Ȃ���s
        {

            if (Timer.instance.RealTime > _notesManager._notesTime[0] + 0.2f)//�����A�{���m�[�c���������ׂ����Ԃ���0.2�b�����Ă����͂��Ȃ������ꍇ
            {
                Debug.Log("LOST");
                ScoreText.Instance._lost++;
                NotesMessage(2);
                DeleteData();
                //�~�X
            }
        }
    }






    void Judgment (float timeLag)//�ォ�画��𑝂₷�̂�����
    {
        if (timeLag < 0.10)//�����A�{���̃m�[�c��@���ׂ����ԂƎ��ۂɃm�[�c��@�������Ԃ̌덷��0.1�b�ȉ���������
        {
            Debug.Log("PURE");
            ScoreText.Instance._pure++;
            NotesMessage(0);
            DeleteData();
        }
        else if (timeLag < 0.15)//�����A�{���̃m�[�c��@���ׂ����ԂƎ��ۂɃm�[�c��@�������Ԃ̌덷��0.15�b�ȉ���������
        {
            Debug.Log("FAR");
            ScoreText.Instance._far++;
            NotesMessage(1);
            DeleteData();
        }
        
    }

    float GetABS(float num)//�����̐�Βl��Ԃ��֐�
                          //ABS�͐�Βl (absolute value) ��Ԃ��֐��Ƃ����Ӗ�
    {
        if(num >= 0)//�����Anum��0���傫��������num��Ԃ��i0�ȏ�j
        {
            return num;
        }
        else        //��������Ȃ�������A-num��Ԃ��i0�ȉ��j
        {
            return -num;
        }
    }

    void DeleteData()//�@�����m�[�c���\���������͍폜����֐�
    {
        if(_notesManager._notesTime.Count > 0)//_notesManager.NotesTime��1�ȏ�Ȃ���s
        {
            _notesManager._notesTime.RemoveAt(0);
            _notesManager._laneNum.RemoveAt(0);
            _notesManager._noteType.RemoveAt(0);
        }
    }

    void NotesMessage(int judge)//�m�[�c��@�������̔���̕\��
    {
        Instantiate(_judgeObjects[judge],new Vector3(_notesManager._laneNum[0]-1.5f,0.76f,0.15f),Quaternion.Euler(45,0,0));
    }
}
