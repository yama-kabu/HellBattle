using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //A～Bの間にイベントを発生させる
    public float TimeA;
    public float TimeB;

    //イベントの数
    public int EventCount;

    //時間の乱数生成を制御するスイッチ
    public bool EventSwitch;//Onはカウント中、Offなら生成

    float EventTime;

    void Start()
    {
        EventSwitch = false;
    }

    void Update()
    {
        //イベント発生までの時間の振れ幅を決める
        if (EventSwitch == false)
        {
            EventSwitch = true;
            EventTime = Random.Range(TimeA, TimeB);
        }

        //カウント
        EventTime -= Time.deltaTime;

        //カウントが終ったらイベント発生に取り掛かる
        if (EventTime <= 0)
        {
            //イベントの個数を把握し、その中からランダムな数を取り出す
            int Rand = Random.Range(1, EventCount+1);

            //その番号にちなんだイベントを実行
            switch (Rand)
            {
                case 1:
                    Event1();
                    break;
                case 2:
                    Event2();
                    break;
                case 3:
                    Event3();
                    break;
                case 4:
                    Event4();
                    break;
                case 5:
                    Event5();
                    break;
            }
            //最後にスイッチを戻してカウントの乱数を生成できるようにする
            EventSwitch = false;
        }
    }

    //各イベントの処理
    void Event1()
    {
        
    }

    void Event2()
    {
        
    }

    void Event3()
    {
        
    }

    void Event4()
    {
        
    }

    void Event5()
    {
        
    }
}
