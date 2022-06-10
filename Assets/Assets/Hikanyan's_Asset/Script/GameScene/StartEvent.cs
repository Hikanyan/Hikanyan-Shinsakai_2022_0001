using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartEvent : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    public void OnClickStartButton()
    {
        Debug.Log("UIが押されたGameScreen1に移行");
        //SceneManager.LoadScene("GameScreen1");
        LoadingScene.Instance.LoadNextScene(_sceneName);
    }

}
