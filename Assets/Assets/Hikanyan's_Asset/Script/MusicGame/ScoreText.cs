using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{

    //[SerializeField] TextMeshPro _text;//プレイヤーに判定を伝えるテキスト(用済み)
    [SerializeField] TextMeshProUGUI _uiText;//プレイヤーに判定を伝えるテキスト
    public static ScoreText Instance;//オートモードを持ってくるためのシングルトン
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
            DontDestroyOnLoad(this.gameObject);             //このゲームオブジェクトが壊され無くなった
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
 * 簡易版シングルトン癖になる
 */