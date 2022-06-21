using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{

    //[SerializeField] TextMeshPro _text;//�v���C���[�ɔ����`����e�L�X�g(�p�ς�)
    [SerializeField] TextMeshProUGUI _uiText;//�v���C���[�ɔ����`����e�L�X�g
    public static ScoreText Instance;//�I�[�g���[�h�������Ă��邽�߂̃V���O���g��
    public int _pure;
    public int _far;
    public int _lost;
    public int _auto;
    public bool _musicEnd;
    public string _resultText;
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this.gameObject);             //���̃Q�[���I�u�W�F�N�g���󂳂ꖳ���Ȃ���
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        JudgeTextMessage();
    }

    private void JudgeTextMessage()
    {
        if (_musicEnd == false && AutoMode.Instance._autoMode == true)
        {
            _uiText.text = $"PURE {_pure}\nFAR {_far}\nLOST {_lost}\nAUTO{_auto}";
            _resultText = $"PURE {_pure}\nFAR {_far}\nLOST {_lost}\nAUTO{_auto}";

        }
        if (_musicEnd == false && AutoMode.Instance._autoMode == false)
        {
            _uiText.text = $"PURE {_pure}\nFAR {_far}\nLOST {_lost}\n";
            _resultText = $"PURE {_pure}\nFAR {_far}\nLOST {_lost}\n";
        }
    }
}
/*
 * �ȈՔŃV���O���g���ȂɂȂ�
 */