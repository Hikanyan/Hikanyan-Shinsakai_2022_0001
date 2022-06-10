
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
//Serializable 属性によりインスペクター上でクラスにサブプロパティーを埋め込むことを許可します。
//名前と三角記号が表示されプロパティーを展開できます。
public class Data
{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public Note[] notes;
}

[Serializable]
public class Note
{
    public int type;
    public int num;
    public int block;
    public int LPB;
}



public class NotesManager : MonoBehaviour
{
    public int _noteNum;//ノーツの総数

    public List<int> _laneNum = new();//何番目のレーンにノーツが落ちてくるか
    public List<int> _noteType = new();//Notesの種類
    public List<float> _notesTime = new();//ノーツが判定線と重なる時間
    public List<GameObject> _notesObject = new();//GameObject

    
   
    [SerializeField] private string _sonfName;//曲名を入れる関数を作成する。保存したJsonの名前を入れる
    [SerializeField] private GameObject _noteObject;//ノーツのプレハブを入れる
    [SerializeField] private GameObject _noteLongObject;//ロングノーツのプレハブを入れる
    [SerializeField] private float _notesSeed;//ノーツのスピード

    private void Awake()//オブジェクトが有効にされたとき一回だけ呼び出される
    {
        _noteNum = 0;//ノーツを0に初期化
        NotesLoad(_sonfName);//NotesLoad(_sonfName)を呼び出し
    }

    //有効にされたらJsonファイルを読み込み、座標を計算して配置する
    //Updateを使わない理由はPlay中にズレないようにするため




    private void NotesLoad(string SongName)//ノーツ
    {
        string inputString = Resources.Load<TextAsset>(SongName).ToString();//この二つで.jsonファイルを読み込む
        Data inputJson = JsonUtility.FromJson<Data>(inputString);           //


        _noteNum = inputJson.notes.Length;//ノーツ数の合計


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        for (int i = 0; i < inputJson.notes.Length; i++)//ノーツの位置を一個ずつ配置していく
        {
            float syousetu = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB);                                      //一小節の長さ
            float beatSec = syousetu * (float)inputJson.notes[i].LPB;                                                   //ノーツの長さ
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB) + inputJson.offset + 0.01f; //ノーツの降ってくる時間
           
            _notesTime.Add(time);                    //NotesTimeリストに追加
            _laneNum.Add(inputJson.notes[i].block);  //LaneNumリストに追加
            _noteType.Add(inputJson.notes[i].type);  // NoteTypeリストに追加

            float z = _notesTime[i] * _notesSeed;     //ノーツの生成される位置
            
            _notesObject.Add(Instantiate(_noteObject, new Vector3(inputJson.notes[i].block - 1.5f, 0.55f,z), Quaternion.identity));//ノーツ生成・インスタンス化
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}


/*
 * 参考資料
 * 
 * 
 * https://qiita.com/irigoma77/items/ee15b3e748596aa6d086 
 * https://www.youtube.com/watch?v=WWeyn4TI0lI&t=327s
 * https://www.youtube.com/watch?v=TnKnwLIiY_8
 * 
 * 
 * 
 */