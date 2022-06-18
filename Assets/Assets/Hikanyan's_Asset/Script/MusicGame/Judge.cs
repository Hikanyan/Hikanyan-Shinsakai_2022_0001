using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Judge : MonoBehaviour
{
    [SerializeField] private GameObject[] _judgeObjects;//プレイヤーに判定を伝えるオブジェクト
    [SerializeField] NotesManager _notesManager;       //スクリプト「_notesManager」を入れる変数
    [SerializeField] Timer _timer;                     //スクリプト「_timer」を入れる関数
    private float _time = 0;
    [HideInInspector] public float _notesOffset;        //動かしたら壊れる
    
    private void Update()
    {
        _time += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.D))//もし、Dキーが押されたとき
        {
            if (_notesManager._notesTime.Count > 0 && _notesManager._laneNum[0] == 0)
            /*
             * _notesManager._notesTime.Countが0以上かつ
             * _notesManager._laneNum[0](レーン0)が0のとき
             * _notesManager._notesTime.Countはノーツが無くなったときに
             * 判定を取らないようにするため
             */
            {
                Judgment(GetABS(Timer.instance.RealTime - _notesManager._notesTime[0] ));
                /*
                 * 本来のノーツを叩く場所と実際に叩いた場所がどれくらいズレているかを求める
                 * その絶対値をJudgment関数に送る
                 */
            }
            Debug.Log($"Dキーが押された{_time}");
        }
        if (Input.GetKeyDown(KeyCode.F))//もし、Fキーが押されたとき
        {

            if (_notesManager._notesTime.Count > 0 && _notesManager._laneNum[0] == 1)
            {
                Judgment(GetABS(Timer.instance.RealTime - _notesManager._notesTime[0]));

            }
            Debug.Log($"Fキーが押された{_time}");
        }
        if (Input.GetKeyDown(KeyCode.J))//もし、Jキーが押されたとき
        {

            if (_notesManager._notesTime.Count > 0 && _notesManager._laneNum[0] == 2)
            {
                Judgment(GetABS(Timer.instance.RealTime - _notesManager._notesTime[0]));

            }
            Debug.Log($"Jキーが押された{_time}");
        }
        if (Input.GetKeyDown(KeyCode.K))//もし、Kキーが押されたとき
        {
            if (_notesManager._notesTime.Count > 0 && _notesManager._laneNum[0] == 3)
            {
                Judgment(GetABS(Timer.instance.RealTime - _notesManager._notesTime[0]));

            }
            Debug.Log($"Kキーが押された{_time}");
        }
        if (_notesManager._notesTime.Count > 0)//_notesManager.NotesTimeが1以上なら実行
        {

            if (Timer.instance.RealTime > _notesManager._notesTime[0] + 0.30f)//もし、本来ノーツをたたくべき時間から0.30秒たっても入力がなかった場合
            {
                Debug.Log("LOST");
                ScoreText.Instance._lost++;
                NotesMessage(2);
                DeleteData();
                //ミス
                Debug.Log($"みす{_time}");
            }
        }

        if (AutoMode.Instance._autoMode == true && _notesManager._notesTime.Count > 0)//オート
        {

            if (Timer.instance.RealTime > _notesManager._notesTime[0])
            {
                Debug.Log("auto");
                ScoreText.Instance._auto++;
                NotesMessage(0);
                DeleteData();
                Debug.Log($"オート{_time}");
            }
        }

    }






    void Judgment(float timeLag)//後から判定を増やすのもあり
    {
        if (timeLag < 0.10f)//もし、本来のノーツを叩くべき時間と実際にノーツを叩いた時間の誤差が0.10秒以下だったら
        {
            Debug.Log("PURE");
            ScoreText.Instance._pure++;
            NotesMessage(0);
            DeleteData();
        }
        else if (timeLag < 0.30f)//もし、本来のノーツを叩くべき時間と実際にノーツを叩いた時間の誤差が0.20秒以下だったら
        {
            Debug.Log("FAR");
            ScoreText.Instance._far++;
            NotesMessage(1);
            DeleteData();
        }

    }

    float GetABS(float num)//因数の絶対値を返す関数
                           //ABSは絶対値 (absolute value) を返す関数という意味
    {
        if (num >= 0)//もし、numが0より大きかったらnumを返す（0以上）
        {
            return num;
        }
        else        //そうじゃなかったら、-numを返す（0以下）
        {
            return -num;
        }
    }

    void DeleteData()//叩いたノーツを非表示もしくは削除する関数
    {
        if (_notesManager._notesTime.Count > 0)//_notesManager.NotesTimeが1以上なら実行
        {
            _notesManager._notesTime.RemoveAt(0);
            _notesManager._laneNum.RemoveAt(0);
            _notesManager._noteType.RemoveAt(0);
        }
    }

    void NotesMessage(int judge)//ノーツを叩いた時の判定の表示
    {
        Instantiate(_judgeObjects[judge], new Vector3(_notesManager._laneNum[0] - 1.5f, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0));
    }
}
