using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartEvent : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    public void OnClickStartButton()
    {
        Debug.Log("UI‚ª‰Ÿ‚³‚ê‚½GameScreen1‚ÉˆÚs");
        //SceneManager.LoadScene("GameScreen1");
        LoadingScene.Instance.LoadNextScene(_sceneName);
    }

}
