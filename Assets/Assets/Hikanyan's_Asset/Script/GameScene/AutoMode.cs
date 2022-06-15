using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMode : MonoBehaviour
{
    public static AutoMode Instance;                      //�I�[�g���[�h��Bool�������p�����߂̃V���O���g��
    [HideInInspector] public bool _autoMode = false;   //�I�[�g���[�h�����lfalse

    private void Awake()                                //�V���O���g���̂���
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this.gameObject);             //���̃Q�[���I�u�W�F�N�g���󂳂ꖳ���Ȃ���
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void OnClickAutoModeButton()
    {
        if (_autoMode == false)
        {
            _autoMode = true;
            Debug.Log($"�I�[�g���[�h{_autoMode}");
        }
        else if (_autoMode == true)
        {
            _autoMode = false;
            Debug.Log($"�I�[�g���[�h{_autoMode}");
        }
    }
}
