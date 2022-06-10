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
            Debug.Log("UI‚ª‰Ÿ‚³‚ê‚½GameScreen1‚ÉˆÚs");
            SceneManager.LoadScene("GameScreen1");
        }
    
}
