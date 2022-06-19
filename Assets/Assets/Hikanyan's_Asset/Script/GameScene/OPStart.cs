using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPStart : MonoBehaviour
{

    [SerializeField] GameObject _op;
    [SerializeField] GameObject _startMenu;
    private void Start()
    {
        _op.gameObject.SetActive(true);
        _startMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        StartCoroutine("OpEnd");
    }
    IEnumerator OpEnd()
    {
        yield return new WaitForSeconds(40);
        _startMenu.gameObject.SetActive(true);
    }
}
