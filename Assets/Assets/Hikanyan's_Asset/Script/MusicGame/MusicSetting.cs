using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MusicSetting : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;//��
    [SerializeField] private GameObject _settingsMenu;//��
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    

    public void OpenSettings()
    {
        // �ݒ胁�j���[�̃p�l�����A�N�e�B�u
        _settingsMenu.SetActive(true);
        // ���C�����j���[�̃p�l�����A�N�e�B�u
        _mainMenu.SetActive(false);
        //�������Ƃ��ɕ\��
        _textMeshPro.text = $"{Notes._notesSpeed}";
    }


    // �ݒ胁�j���[�����
    public void CloseSettings()
    {
        // ���C�����j���[�̃p�l�����A�N�e�B�u
        _mainMenu.SetActive(true);
        // �ݒ胁�j���[�̃p�l�����A�N�e�B�u
        _settingsMenu.SetActive(false);
    }

    //�������Ƃ���0.5�v���X
    public void SpeedPlus()
    {
        NotesManager._notesSpeed += 0.5f;
        Notes._notesSpeed += 0.5f;
        Debug.Log(Notes._notesSpeed);
        _textMeshPro.text = $"{NotesManager._notesSpeed}";
    }
    //�������Ƃ���0.5�}�C�i�X
    public void SpeedDown()
    {
        NotesManager._notesSpeed -= 0.5f;
        Notes._notesSpeed -= 0.5f;
       
        _textMeshPro.text = $"{Notes._notesSpeed}";
    }
}
