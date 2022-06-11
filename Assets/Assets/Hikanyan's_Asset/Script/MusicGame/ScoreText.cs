using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{

    [SerializeField] TextMeshPro _text;//�v���C���[�ɔ����`����e�L�X�g
    public static ScoreText Instance;
    public int _pure;
    public int _far;
    public int _lost;
    public int _auto;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        _text.text = $"PURE {_pure}\nFAR {_far}\nLOST {_lost}\nAUTO{_auto}";
    }
}
/*
 * �ȈՔŃV���O���g���ȂɂȂ�
 */