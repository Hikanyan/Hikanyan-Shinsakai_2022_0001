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
    public static int _resultPure;
    public int _far;
    public static int _resultFar;
    public int _lost;
    public static int _resultLost;
    public int _auto;
    public static int _resultAuto;
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

        if(AutoMode.Instance._autoMode == true)
        {
            //_text.text = $"PURE {_pure}\nFAR {_far}\nLOST {_lost}\nAUTO{_auto}";
            _uiText.text = $"PURE {_pure}\nFAR {_far}\nLOST {_lost}\nAUTO{_auto}";
            
        }
        else if(AutoMode.Instance._autoMode == false)
        {
            //_text.text = $"PURE {_pure}\nFAR {_far}\nLOST {_lost}\n";
            _uiText.text = $"PURE {_pure}\nFAR {_far}\nLOST {_lost}\n";
        }
    }

    public void Seta()
    {
        _resultPure = _pure;
        _resultFar = _far;
        _resultLost = _lost;
        _resultAuto = _auto;
    }
}
/*
 * 簡易版シングルトン癖になる
 */