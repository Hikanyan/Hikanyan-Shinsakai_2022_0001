using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour
{
    private AsyncOperation _async;
    [SerializeField] private GameObject _loadingUI;
    [SerializeField] private Slider _slider;

    public static LoadingScene Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadNextScene(string sceneName)
    {
        _loadingUI.SetActive(true);
        StartCoroutine(LoadScene(sceneName));
    
    }
    IEnumerator LoadScene(string sceneName)
    {
        _async = SceneManager.LoadSceneAsync(sceneName);
        while (!_async.isDone)
        {
            _slider.value = _async.progress;
            yield return null;
        }
        _loadingUI.SetActive(false);
    }
}
