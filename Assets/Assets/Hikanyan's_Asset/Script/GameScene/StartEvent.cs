using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartEvent : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    public void OnClickStartButton()
    {
        Debug.Log("UI�������ꂽGameScreen1�Ɉڍs");
        //SceneManager.LoadScene("GameScreen1");
        LoadingScene.Instance.LoadNextScene(_sceneName);
    }

}
