using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShortCutKey : MonoBehaviour
{

    [SerializeField]
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl)&&Input.GetKey(KeyCode.R)|| Input.GetKey(KeyCode.RightControl) && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(Input.GetKey(KeyCode.LeftControl)&&Input.GetKey(KeyCode.Return)|| Input.GetKey(KeyCode.RightControl) && Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("Result");
        }
    }
}
