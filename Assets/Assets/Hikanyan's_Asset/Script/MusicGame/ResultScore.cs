using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _judgeText;
    [SerializeField] private TextMeshProUGUI _rankText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    void Start()
    {
        _judgeText.text = ScoreText.Instance._resultJudgeText;
        _rankText.text = ScoreText.Instance._resultRankJudgeText;
        _scoreText.text = ScoreText.Instance._resultScoreJudgeText;
    }
}
