using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPStart : MonoBehaviour
{

    [SerializeField] GameObject _op;
    [SerializeField] GameObject _startMenu;
    private void Start()
    {
        _op.SetActive(true);
        _startMenu.SetActive(false);
    }

    private void Update()
    {

        StartCoroutine(nameof(OpEnd));

    }
    IEnumerator OpEnd()
    {
        yield return new WaitForSeconds(40);
        _startMenu.SetActive(true);
    }
}
