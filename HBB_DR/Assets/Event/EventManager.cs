using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EventManager : MonoBehaviour
{
    AudioSource Aud;
    public AudioClip StartSE;//イベント発動SE

    //A～Bの間にイベントを発生させる
    public float TimeA;
    public float TimeB;

    //イベントの数
    public int EventNumber;

    //イベント処理用変数
    int Rand;//乱数格納
    public float AtcRatio;//攻撃力アップ倍率
    float AtcBOX1, AtcBOX2;//元の攻撃力を保管しておく変数
    public bool EventSwitch;//時間の乱数生成を制御するスイッチ
    public float PlayerSlow;//時間鈍化中のプレイヤー速度
    public float BulletSpeed1, BulletSpeed2;//時間鈍化中のプレイヤー速度
    float Time2, Time3, Time5;
    bool SESwitch, Barrier = false;
    float EventTime;
    public bool B_Switch = false;
    public bool HPSwitch = false;
    bool OnOff = false;

    //イベントまでのカウントダウン
    float EventCount;
    //各イベントの時間
    public float Time_AtcUP, Time_Speed, Time_HP;

    //プレイヤーオブジェクト格納
    public GameObject Player1;
    public GameObject Player2;
    //プレイヤーステータス格納
    float HP1 = 0, Atc1, Speed1, BSpeed1;//Player1
    float HP2 = 1, Atc2, Speed2, BSpeed2;//Player2

    //アイテム格納
    public GameObject LifeItem;

    //アナウンス文字
    public GameObject EventText;
    public string Event1tex;
    public string Event2tex;
    public string Event3tex;
    public string Event4tex;
    public string Event5tex;

    void Start()
    {
        EventSwitch = false;
        OnOff = false;
        Aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        Textchange();

        float x = 60;
        x -= Time.deltaTime;
        if (x <=0) { OnOff = true; }

        //イベント発生までの時間の振れ幅を決める
        //どのイベントを行うか決める
        if (EventSwitch == false && OnOff == true)
        {
            EventCount = UnityEngine.Random.Range(TimeA, TimeB);
            //イベントの個数を把握し、その中からランダムな数を取り出す
            Rand = UnityEngine.Random.Range(1, EventNumber + 1);
            EventSwitch = true;
            SESwitch = false;
        }

        EventCount -= Time.deltaTime;//イベント発生までのカウントダウン

        //【デバッグ用】押したキーの番号のイベントに変更
        Eventchange();

        //カウントが終っている間はイベントを行う
        if (EventCount <= 0)
        {
            if (SESwitch == false)
            {
                Aud.PlayOneShot(StartSE);
                SESwitch = true;
            }
            switch(Rand)
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
        }
    }

    //各イベントの処理
    void Event1()//ライフ回復イベント
    {
        var Item = Instantiate(LifeItem, new Vector2(-5, 5), Quaternion.identity);
        var Item2 = Instantiate(LifeItem, new Vector2(5, -5), Quaternion.Euler(0, 0, 180f));

        //最後にスイッチを戻してカウントの乱数を生成できるようにする
        EventSwitch = false;
    }

    void Event2()//不利プレイヤー攻撃力アップイベント
    {
        /*ここにプレイヤーの攻撃力を参照する文を書く*/
        Time2 += Time.deltaTime;
        if (HP1 < HP2)
        {
            Atc1 *= AtcRatio;
            Atc2 = AtcBOX2;
        }
        else if (HP1 > HP2)
        {
            Atc2 *= AtcRatio;
            Atc1 = AtcBOX1;
        }

        if (Time_AtcUP <= Time2)//攻撃力を元に戻す
        {
            Atc1 = AtcBOX1;
            Atc2 = AtcBOX2;
            Time2 = 0;
            EventSwitch = false;
        }
    }

    void Event3()
    {
        Time3 += Time.deltaTime;
        Speed1 = Speed2 = PlayerSlow;
        BSpeed1 = BulletSpeed1;
        BSpeed2 = BulletSpeed2;
        if (Time3 >= Time_Speed)
        {
            Time3 = 0;
            EventSwitch = false;
        }
    }

    void Event4()
    {
        if (Barrier == false)
        {
            B_Switch = true;
            Player1.GetComponent<Player_Manager_R>();
            Barrier = true;
            EventSwitch = false;
        }
        else
        {
            Rand = UnityEngine.Random.Range(1, EventNumber + 1);
        }
    }

    void Event5()
    {
        HPSwitch = true;//これをプレイヤー側等で参照して、吸収攻撃を処理
        Time5 += Time.deltaTime;
        if (Time5 >= Time_HP)
        {
            HPSwitch = false;
            EventSwitch = false;
        }
    }

    void Textchange()
    {
        Text Etext = EventText.GetComponent<Text>();

        if (EventCount <= 0)
        {
            switch (Rand)
            {
                case 1:
                    Etext.text = Event1tex;
                    break;
                case 2:
                    Etext.text = Event2tex;
                    break;
                case 3:
                    Etext.text = Event3tex;
                    break;
                case 4:
                    Etext.text = Event4tex;
                    break;
                case 5:
                    Etext.text = Event5tex;
                    break;
            }
        }
        else
        {
            Etext = null;
        }
    }

    //【デバッグ用】押したキーの番号のイベントに変更
    void Eventchange()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    switch(code)
                    {
                        case KeyCode.Alpha1:
                            Rand = 1;
                            break;
                        case KeyCode.Alpha2:
                            Rand = 2;
                            break;
                        case KeyCode.Alpha3:
                            Rand = 3;
                            break;
                        case KeyCode.Alpha4:
                            Rand = 4;
                            break;
                        case KeyCode.Alpha5:
                            Rand = 5;
                            break;
                    }
                    Debug.Log(Rand);
                    break;
                }
            }
        }
    }
}
