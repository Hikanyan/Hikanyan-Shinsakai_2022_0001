using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicEnd : MonoBehaviour
{

    [SerializeField] NotesManager _notesManager;       //�X�N���v�g�u_notesManager�v������ϐ�
    [SerializeField] private string _sceneName;        //�ǂ̃V�[���Ɉڂ�������
    private float _time = 0;
    [HideInInspector] public bool _musicEnd = false;   //�Ȃ��I��������ǂ���

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        _time += Time.deltaTime;
        if (_time > 15 && _notesManager._notesTime.Count == 0)
        {
            StartCoroutine(MusicEndLoad());
        }
    }


    IEnumerator MusicEndLoad()
    {
        ScoreText.Instance._musicEnd = true;
        yield return new WaitForSeconds(3);
        Debug.Log($"{_sceneName}�ڍs");
        LoadingScene.Instance.LoadNextScene(_sceneName);
    }
}
