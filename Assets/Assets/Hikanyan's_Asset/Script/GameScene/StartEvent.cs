using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.SceneManagement;
public class StartEvent : MonoBehaviour
{
    [SerializeField] private GameObject _loadingUI;
    [SerializeField] private Slider _slider;
 
        public void OnClickStartButton()
        {
            Debug.Log("UIが押されたGameScreen1に移行");
            SceneManager.LoadScene("GameScreen1");
        }
    
}
