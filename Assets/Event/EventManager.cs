using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EventManager : MonoBehaviour
{

    [Header("最初の60秒間を飛ばすスイッチ")]
    public bool OnOff = false;

    [Header("A～Bの間にイベントを発生させる")]
    public float TimeA;
    public float TimeB;

    [Header("攻撃力アップ倍率")]
    public float AtcRatio;

    [Header("鈍化中のプレイヤー速度")]
    public float PlayerSlow;
    [Header("鈍化中の弾速")]
    public float BulletSpeed1, BulletSpeed2;

    [Header("不利プレイヤー攻撃力アップの時間")]
    public float Time_AtcUP;
    [Header("鈍化の時間")]
    public float Time_Speed;
    [Header("吸収攻撃の時間")]
    public float Time_HP;

    [Header("アナウンス文字")]
    public GameObject EventText;
    public string Event1tex;
    public string Event2tex;
    public string Event3tex;
    public string Event4tex;
    public string Event5tex;

    [Header("イベント処理用変数(触らないでね)")]
    float EventCount;//イベントまでのカウントダウン
    public bool B_Switch = false;//バリアのスイッチ
    public bool EventSwitch;//時間の乱数生成を制御するスイッチ
    float Time2, Time3, Time5;//各イベントのカウントダウン用
    bool Barrier = false;//バリアが一度使ったか判断するスイッチ
    private float x;//最初の60秒のカウント
    float AtcBOX1, AtcBOX2;//元の攻撃力を保管しておく変数
    int Rand;//乱数格納
    public int EventNumber;//イベントの数
    public GameObject LifeItem;//回復アイテムのprefab
    public GameObject Canvas;
    //ステータス保存用
    float HP1, Atc1, SpeedL1, SpeedR1, BSpeed1;
    float HP2, Atc2, SpeedL2, SpeedR2, BSpeed2;
    //プレイヤーオブジェクト格納
    public GameObject PlayerL1;
    public GameObject PlayerR1;
    public GameObject PlayerL2;
    public GameObject PlayerR2;

    void Start()
    {
        EventSwitch = false;
        x = 60;
    }

    void Update()
    {
        Textchange();
        
        //最初の60秒
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
        }

        EventCount -= Time.deltaTime;//イベント発生までのカウントダウン

        //【デバッグ用】押したキーの番号のイベントに変更
        Eventchange();

        //カウントが終っている間はイベントを行う
        if (EventCount <= 0)
        {
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
        GameObject HeelItem = (GameObject)Instantiate(LifeItem);
        HeelItem.transform.SetParent(Canvas.transform, false);
        HeelItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(-500,600);
        GameObject HeelItem2 = (GameObject) Instantiate(LifeItem, new Vector2(0, 0), Quaternion.Euler(0, 0, 180f));
        HeelItem2.transform.SetParent(Canvas.transform, false);
        HeelItem2.GetComponent<RectTransform>().anchoredPosition = new Vector2(500, -600);

        SoundManager.Instance.PlaySE(SE.HeelItem);
        //最後にスイッチを戻してカウントの乱数を生成できるようにする
        EventSwitch = false;
    }

    void Event2()//不利プレイヤー攻撃力アップイベント
    {
        AtcBOX1 = PlayerL1.GetComponent<Player_Manager_L>().AttackPower_percent;
        AtcBOX2 = PlayerL2.GetComponent<Player_Manager_L>().AttackPower_percent;
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
        //一旦保留
        /*SpeedL1 = PlayerL1.GetComponent<Player_Move>().Character_Speed;
        SpeedR1 = PlayerL1.GetComponent<Player_Move>().Character_Speed;
        SpeedL2 = PlayerL2.GetComponent<Player_Move>().Character_Speed;
        SpeedR2 = PlayerL2.GetComponent<Player_Move>().Character_Speed;
        //BSpeed1 = PlayerL1.GetComponent<>

        SpeedL1 = SpeedR1 = SpeedR2 = SpeedL2 = PlayerSlow;
        BSpeed1 = BulletSpeed1;
        BSpeed2 = BulletSpeed2;

        Time3 += Time.deltaTime;
        if (Time3 >= Time_Speed)
        {
            Time3 = 0;
            EventSwitch = false;
        }*/

        //再抽選
        Rand = UnityEngine.Random.Range(1, EventNumber + 1);
    }

    void Event4()
    {
        PlayerL1.GetComponent<Event_Manager>().HPSwitch = true;
        PlayerL2.GetComponent<Event_Manager>().HPSwitch = true;
        Time5 += Time.deltaTime;
        if (Time5 >= Time_HP)
        {
            PlayerL1.GetComponent<Event_Manager>().HPSwitch = false;
            PlayerL2.GetComponent<Event_Manager>().HPSwitch = false;
            EventSwitch = false;
        }
    }

    void Event5()
    {
        HP1 = PlayerR1.GetComponent<Player_Manager_R>().m_Player_HP;
        HP2 = PlayerR2.GetComponent<Player_Manager_R>().m_Player_HP;
        B_Switch = PlayerR1.GetComponent<Event_Manager>().B_Switch;
        if (Barrier == false)
        {
            if (HP1 < HP2)
            {
                B_Switch = PlayerR1.GetComponent<Event_Manager>().B_Switch;
                B_Switch = true;
                Barrier = true;
                EventSwitch = false;
            }
            else if (HP2 < HP1)
            {
                B_Switch = PlayerR2.GetComponent<Event_Manager>().B_Switch;
                B_Switch = true;
                Barrier = true;
                EventSwitch = false;
            }
        }
        else
        {
            Rand = UnityEngine.Random.Range(1, EventNumber + 1);
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
                    //Debug.Log(Rand);
                    break;
                }
            }
        }
    }
}
