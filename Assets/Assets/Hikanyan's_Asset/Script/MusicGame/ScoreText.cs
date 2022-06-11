using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{

    [SerializeField] TextMeshPro _text;//プレイヤーに判定を伝えるテキスト
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
 * 簡易版シングルトン癖になる
 */