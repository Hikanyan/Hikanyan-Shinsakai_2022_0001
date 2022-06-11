using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingEvent : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    public void OnClickLoadingButton()
    {
        Debug.Log($"UI�������ꂽ��{_sceneName}�ڍs");
        //SceneManager.LoadScene("GameScreen1");
        LoadingScene.Instance.LoadNextScene(_sceneName);
    }

}
