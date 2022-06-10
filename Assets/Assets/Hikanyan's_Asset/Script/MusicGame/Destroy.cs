using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        //Destroy(other.gameObject);
        other.gameObject.SetActive(false);
    }
}
