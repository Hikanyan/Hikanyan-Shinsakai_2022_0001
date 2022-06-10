using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLight : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private int _num = 0;
    private Renderer _rend;
    private float _alfa = 0.0f;
    private void Start()
    {
        _rend = GetComponent<Renderer>();
    }
    void Update()
    {
        JudgementKey();

    }
    void ColorChange()
    {
        _alfa = 0.5f;
        //Materialのカラーを変える RGBA
        _rend.material.color = new Color(_rend.material.color.r, _rend.material.color.g, _rend.material.color.b, _alfa);
    }

    void JudgementKey()
    {
        if (!(_rend.material.color.a <= 0))
        {
            _rend.material.color = new Color(_rend.material.color.r, _rend.material.color.g, _rend.material.color.b, _alfa);
        }

        switch (_num)
        {
            case 0:
                if (Input.GetKey(KeyCode.D))
                { //Dが押された時呼び出す
                    ColorChange();
                }
                break;
            case 1:
                if (Input.GetKey(KeyCode.F))
                { //Fが押された時呼び出す
                    ColorChange();
                }
                break;
            case 2:
                if (Input.GetKey(KeyCode.J))
                { //Jが押された時呼び出す
                    ColorChange();
                }
                break;
            case 3:
                if (Input.GetKey(KeyCode.K))
                { //Kが押された時呼び出す
                    ColorChange();
                }
                break;
        }
        _alfa -= _speed * Time.deltaTime;
    }

}
