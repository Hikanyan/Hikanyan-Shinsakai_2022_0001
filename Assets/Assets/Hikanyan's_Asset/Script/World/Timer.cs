using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public float _startTime = 0;
    public float RealTime { get; private set; }
    public static Timer instance;
    [SerializeField] TextMeshPro _text;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        _startTime = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        RealTime = Time.realtimeSinceStartup - _startTime;
        _text.text = RealTime.ToString();
    }
}
