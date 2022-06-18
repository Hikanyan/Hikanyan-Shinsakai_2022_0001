using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicEnd : MonoBehaviour
{

    [SerializeField] NotesManager _notesManager;       //スクリプト「_notesManager」を入れる変数
    [SerializeField] private string _sceneName;        //どのシーンに移したいか
    public bool _result;
    private float _time = 0;
    void Update()
    {
        _time += Time.deltaTime;
        if (_time>15&&_notesManager._notesTime.Count == 0)
        {
            StartCoroutine(MusicEndLoad());
        }
    }


    IEnumerator MusicEndLoad()
    {
        yield return new WaitForSeconds(3);
        Debug.Log($"UIが押されたに{_sceneName}移行");
        //SceneManager.LoadScene("GameScreen1");
        LoadingScene.Instance.LoadNextScene(_sceneName);
    }
}
