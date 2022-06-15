using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicEnd : MonoBehaviour
{

    [SerializeField] NotesManager _notesManager;       //�X�N���v�g�u_notesManager�v������ϐ�
    [SerializeField] private string _sceneName;        //�ǂ̃V�[���Ɉڂ�������

    void Update()
    {
        if (_notesManager._notesTime.Count == 0)
        {
            StartCoroutine(MusicEndLoad());
        }
    }


    IEnumerator MusicEndLoad()
    {
        yield return new WaitForSeconds(3);
        Debug.Log($"UI�������ꂽ��{_sceneName}�ڍs");
        //SceneManager.LoadScene("GameScreen1");
        LoadingScene.Instance.LoadNextScene(_sceneName);
    }
}
