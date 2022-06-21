using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{

    //[SerializeField] TextMeshPro _text;//プレイヤーに判定を伝えるテキスト(用済み)
    [SerializeField] TextMeshProUGUI _judgeUiText;//プレイヤーに判定を伝えるテキスト
    [SerializeField] TextMeshProUGUI _resultRankUiText;
    [SerializeField] TextMeshProUGUI _resultScoreUiText;

    public static ScoreText Instance;//オートモードを持ってくるためのシングルトン
    public int _noteNum;
    public int _pure;
    public int _far;
    public int _lost;
    public int _auto;
    public bool _musicEnd;
    public string _resultJudgeText;
    public string _resultRankJudgeText;
    public int _maxScore = 10000000;
    public int _singleScore;
    public string _resultScoreJudgeText;
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
            _judgeUiText.text = $"PURE {_pure}\nFAR {_far}\nLOST {_lost}\nAUTO{_auto}";
            _resultJudgeText = $"PURE {_pure}\nFAR {_far}\nLOST {_lost}\nAUTO{_auto}";
            _resultRankUiText.text = "Auto";
            _resultRankJudgeText = "Auto";
        }
        if (_musicEnd == false && AutoMode.Instance._autoMode == false)
        {
            _judgeUiText.text = $"PURE {_pure}\nFAR {_far}\nLOST {_lost}\n";
            _resultJudgeText = $"PURE {_pure}\nFAR {_far}\nLOST {_lost}\n";
            ResultScore();
        }
    }

    public void ResultScore()
    {

        //_maxScore -= ((_far*10 / 2) + _lost*10);
        _resultScoreUiText.text = $"{_maxScore}";
        _resultScoreJudgeText = $"{_maxScore}";
        if (_maxScore == 10000000)
        {
            _resultRankUiText.text = "PM";
            _resultRankJudgeText = "PM";
        }
        else if (_maxScore >= 900000)
        {
            _resultRankUiText.text = "EX";
            _resultRankJudgeText = "EX";
        }
        else if (_maxScore >= 8000000)
        {
            _resultRankUiText.text = "AA";
            _resultRankJudgeText = "AA";
        }
        else if (_maxScore >= 7000000)
        {
            _resultRankUiText.text = "A";
            _resultRankJudgeText = "A";
        }
        else if (_maxScore >= 6000000)
        {
            _resultRankUiText.text = "B";
            _resultRankJudgeText = "B";
        }
        else if (_maxScore >= 5000000)
        {
            _resultRankUiText.text = "C";
            _resultRankJudgeText = "C";
        }
        else
        {
            _resultRankUiText.text = "D";
            _resultRankJudgeText = "D";
        }

    }
}


/*
 * 理想           500                 500                     20001
 * （10000000+全体のノーツの総数）/全体のノーツの総数　＝　一個当たりのスコアの点数
 * if (_maxScore == 10000000)
        {
            _resultRankUiText.text = "PM";
            _resultRankJudgeText = "PM";
        }
        else if (_maxScore >= 9900000)
        {
            _resultRankUiText.text = "EX";
            _resultRankJudgeText = "EX";
        }
        else if (_maxScore >= 9800000)
        {
            _resultRankUiText.text = "AA";
            _resultRankJudgeText = "AA";
        }
        else if (_maxScore >= 9500000)
        {
            _resultRankUiText.text = "A";
            _resultRankJudgeText = "A";
        }
        else if (_maxScore >= 9200000)
        {
            _resultRankUiText.text = "B";
            _resultRankJudgeText = "B";
        }
        else if (_maxScore >= 8900000)
        {
            _resultRankUiText.text = "C";
            _resultRankJudgeText = "C";
        }
        else if (_maxScore >= 8600000)
        {
            _resultRankUiText.text = "C";
            _resultRankJudgeText = "C";
        }
        else
        {
            _resultRankUiText.text = "D";
            _resultRankJudgeText = "D";
        }
 */