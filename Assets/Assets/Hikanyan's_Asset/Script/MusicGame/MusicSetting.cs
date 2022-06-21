using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MusicSetting : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;//箱
    [SerializeField] private GameObject _settingsMenu;//箱
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    

    public void OpenSettings()
    {
        // 設定メニューのパネルをアクティブ
        _settingsMenu.SetActive(true);
        // メインメニューのパネルを非アクティブ
        _mainMenu.SetActive(false);
        //押したときに表示
        _textMeshPro.text = $"{Notes._notesSpeed}";
    }


    // 設定メニューを閉じる
    public void CloseSettings()
    {
        // メインメニューのパネルをアクティブ
        _mainMenu.SetActive(true);
        // 設定メニューのパネルを非アクティブ
        _settingsMenu.SetActive(false);
    }

    //押したときに0.5プラス
    public void SpeedPlus()
    {
        NotesManager._notesSpeed += 0.5f;
        Notes._notesSpeed += 0.5f;
        Debug.Log(Notes._notesSpeed);
        _textMeshPro.text = $"{NotesManager._notesSpeed}";
    }
    //押したときに0.5マイナス
    public void SpeedDown()
    {
        NotesManager._notesSpeed -= 0.5f;
        Notes._notesSpeed -= 0.5f;
       
        _textMeshPro.text = $"{Notes._notesSpeed}";
    }
}
