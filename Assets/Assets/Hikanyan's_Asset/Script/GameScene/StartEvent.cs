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
            Debug.Log("UI�������ꂽGameScreen1�Ɉڍs");
            SceneManager.LoadScene("GameScreen1");
        }
    
}
