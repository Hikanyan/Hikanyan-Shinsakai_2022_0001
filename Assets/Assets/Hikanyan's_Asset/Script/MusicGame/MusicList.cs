using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicList : MonoBehaviour
{
    [SerializeField]private List<GameObject> _musicList = new();          //UI‚ð“ü‚ê‚é” 
    public static MusicList Instance;                  //

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        
    }



}
