using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Notes : MonoBehaviour
{
    public float _notesSpeed = 1.00f;
    private void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

    void Update()
    {
        transform.position -= new Vector3(0, 0, transform.forward.z * Time.deltaTime * _notesSpeed);
        if (this.transform.position.z < -5.0f)
        {
            
            this.gameObject.SetActive(false);
        }
        if (this.transform.position.z < 18.0f)
        {
            
            GetComponent<Renderer>().enabled = true;
        }
        
    }

    public void NotesEnabled()
    {
        Debug.Log("false");
        this.gameObject.SetActive(false);
    }
}
