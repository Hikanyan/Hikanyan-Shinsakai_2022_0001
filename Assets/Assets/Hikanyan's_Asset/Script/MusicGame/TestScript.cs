using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _testText;
    void Start()
    {
        _testText.text = ScoreText.Instance._resultText;
    }
}
