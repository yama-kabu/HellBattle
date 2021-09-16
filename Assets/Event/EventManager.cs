using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EventManager : MonoBehaviour
{
    private GameObject Game_Setting;

    [Header("�ŏ���60�b�Ԃ��΂��X�C�b�`")]
    public bool OnOff = false;

    [Header("A�`B�̊ԂɃC�x���g�𔭐�������")]
    public float TimeA;
    public float TimeB;

    [Header("�U���̓A�b�v�{��")]
    public float AtcRatio;

    [Header("�v���C���[���x�̓݉�����")]
    public float PlayerSlow;

    [Header("�݉����̒e��")]
    public float BulletSpeed1, BulletSpeed2;

    [Header("�s���v���C���[�U���̓A�b�v�̎���")]
    public float Time_AtcUP;
    [Header("�݉��̎���")]
    public float Time_Speed;
    [Header("�z���U���̎���")]
    public float Time_HP;

    [Header("�A�i�E���X����")]
    public GameObject EventText;
    public string Event1tex;
    public string Event2tex;
    public string Event3tex;
    public string Event4tex;
    public string Event5tex;

    [Header("�C�x���g�����p�ϐ�(�G��Ȃ��ł�)")]
    float EventCount;//�C�x���g�܂ł̃J�E���g�_�E��
    public bool B_Switch = false;//�o���A�̃X�C�b�`
    public bool EventSwitch;//���Ԃ̗��������𐧌䂷��X�C�b�`
    float Time2, Time3, Time5;//�e�C�x���g�̃J�E���g�_�E���p
    bool Barrier = false;//�o���A����x�g���������f����X�C�b�`
    private float x;//�ŏ���60�b�̃J�E���g
    float E_Atc1, E_Atc2;//�G���n���X��̍U���͂�ۊǂ��Ă����ϐ�
    public float S_Speed1, S_Speed2;//�f�o�t��̈ړ��͂�ۊǂ��Ă����ϐ�
    int Rand;//�����i�[
    public int EventNumber;//�C�x���g�̐�
    public GameObject LifeItem;//�񕜃A�C�e����prefab
    public GameObject Canvas;
    //�X�e�[�^�X�ۑ��p
    float HP1, Atc1, Speed1, BSpeed1;
    float HP2, Atc2, Speed2, BSpeed2;
    //�v���C���[�I�u�W�F�N�g�i�[
    public GameObject L1_Rigid, L2_Rigid;//��𑤂̎��@
    public GameObject R1_Shoter, R2_Shoter;//�U�����̎��@
    public GameObject Move_L1, Move_L2;//��𑤂̃X�s�[�h�擾


    void Start()
    {

        Atc1 = R1_Shoter.GetComponent<Player_Manager_L>().AttackPower_percent;
        Atc2 = R2_Shoter.GetComponent<Player_Manager_L>().AttackPower_percent;
        E_Atc1 = Atc1 * AtcRatio;
        E_Atc2 = Atc2 * AtcRatio;
        Speed1 = Move_L1.GetComponent<Player_Move1>().Character_Speed;
        Speed2 = Move_L2.GetComponent<Player_Move2>().Character_Speed;
        S_Speed1 = Speed1 * PlayerSlow;
        S_Speed2 = Speed2 * PlayerSlow;
        EventSwitch = false;
        x = 60;
        SoundManager.Instance.PlayBGM(BGM.BattleBGM);

        Game_Setting = GameObject.Find("Game_Setting");
    }

    void Update()
    {
        if (Game_Setting.GetComponent<Setting>().WINER == false)
        {
            
            Textchange();

            //�ŏ���60�b
            x -= Time.deltaTime;
            if (x <= 0) { OnOff = true; }

            //�C�x���g�����܂ł̎��Ԃ̐U�ꕝ�����߂�
            //�ǂ̃C�x���g���s�������߂�
            if (EventSwitch == false && OnOff == true)
            {
                EventCount = UnityEngine.Random.Range(TimeA, TimeB);
                //�C�x���g�̌���c�����A���̒����烉���_���Ȑ������o��
                Rand = UnityEngine.Random.Range(1, EventNumber + 1);
                EventSwitch = true;
            }

            EventCount -= Time.deltaTime;//�C�x���g�����܂ł̃J�E���g�_�E��

            //�y�f�o�b�O�p�z�������L�[�̔ԍ��̃C�x���g�ɕύX
            Eventchange();

            //�J�E���g���I���Ă���Ԃ̓C�x���g���s��
            if (EventCount <= 0)
            {
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
            }
        }
    }

    //�e�C�x���g�̏���
    void Event1()//���C�t�񕜃C�x���g
    {
        /*GameObject HeelItem = (GameObject)Instantiate(LifeItem);
        HeelItem.transform.SetParent(Canvas.transform, false);
        HeelItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
        GameObject HeelItem2 = (GameObject) Instantiate(LifeItem, new Vector2(0, 0), Quaternion.Euler(0, 0, 180f));
        HeelItem2.transform.SetParent(Canvas.transform, false);
        HeelItem2.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

        SoundManager.Instance.PlaySE(SE.HeelItem);
        //�Ō�ɃX�C�b�`��߂��ăJ�E���g�̗����𐶐��ł���悤�ɂ���
        EventSwitch = false;*/

        //�Ē��I
        Rand = UnityEngine.Random.Range(1, EventNumber + 1);
    }

    void Event2()//�s���v���C���[�U���̓A�b�v�C�x���g
    {
        if (HP1 != null || HP2 == null)
        {
            return;
        }
        else
        {
            HP1 = L1_Rigid.GetComponent<Player_Manager_R>().m_Player_HP;
            HP2 = L2_Rigid.GetComponent<Player_Manager_R>().m_Player_HP;
        }
        /*�����Ƀv���C���[�̍U���͂��Q�Ƃ��镶������*/
        Time2 += Time.deltaTime;
        if (HP1 < HP2)
        {
            R1_Shoter.GetComponent<Player_Manager_L>().AttackPower_percent = E_Atc1;
            R2_Shoter.GetComponent<Player_Manager_L>().AttackPower_percent = Atc2;
        }
        else if (HP1 > HP2)
        {
            R2_Shoter.GetComponent<Player_Manager_L>().AttackPower_percent = E_Atc2;
            R1_Shoter.GetComponent<Player_Manager_L>().AttackPower_percent = Atc1;
        }

        if (Time_AtcUP <= Time2)//�U���͂����ɖ߂�
        {

            R1_Shoter.GetComponent<Player_Manager_L>().AttackPower_percent = Atc1;
            R2_Shoter.GetComponent<Player_Manager_L>().AttackPower_percent = Atc2;
            Time2 = 0;
            EventSwitch = false;
        }
    }

    void Event3()
    {
        //�f�o�t���鏈��
        /*Move_L1.GetComponent<Player_Move1>().Character_Speed = S_Speed1;
        R1_Shoter.GetComponent<Player_Move1>().Character_Speed = S_Speed1;
        Move_L2.GetComponent<Player_Move2>().Character_Speed = S_Speed2;
        R2_Shoter.GetComponent<Player_Move2>().Character_Speed =S_Speed2;
        //BSpeed1 = PlayerL1.GetComponent<>
        //BSpeed1 = BulletSpeed1;
        //BSpeed2 = BulletSpeed2;

        Time3 += Time.deltaTime;
        if (Time3 >= Time_Speed)
        {
            Time3 = 0;
            Move_L1.GetComponent<Player_Move1>().Character_Speed = Speed1;
            R1_Shoter.GetComponent<Player_Move1>().Character_Speed = Speed1;
            Move_L2.GetComponent<Player_Move2>().Character_Speed = Speed2;
            R2_Shoter.GetComponent<Player_Move2>().Character_Speed = Speed2;
            EventSwitch = false;
        }*/

        //�Ē��I
        Rand = UnityEngine.Random.Range(1, EventNumber + 1);
    }

    void Event4()
    {
        L1_Rigid.GetComponent<Event_Manager>().HPSwitch = true;
        L2_Rigid.GetComponent<Event_Manager>().HPSwitch = true;
        Time5 += Time.deltaTime;
        if (Time5 >= Time_HP)
        {
            L1_Rigid.GetComponent<Event_Manager>().HPSwitch = false;
            L2_Rigid.GetComponent<Event_Manager>().HPSwitch = false;
            EventSwitch = false;
            Time5 = 0;
        }
    }

    void Event5()
    {
        HP1 = L1_Rigid.GetComponent<Player_Manager_R>().m_Player_HP;
        HP2 = L2_Rigid.GetComponent<Player_Manager_R>().m_Player_HP;
        if (Barrier == false)
        {
            if (HP1 < HP2)
            {
                L1_Rigid.GetComponent<Event_Manager>().barrier_number = 1;
                B_Switch = L1_Rigid.GetComponent<Event_Manager>().B_Switch =true;
                Barrier = true;
                EventSwitch = false;
            }
            else if (HP2 < HP1)
            {
                L2_Rigid.GetComponent<Event_Manager>().barrier_number = 1;
                B_Switch = L2_Rigid.GetComponent<Event_Manager>().B_Switch = true;
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

    //�y�f�o�b�O�p�z�������L�[�̔ԍ��̃C�x���g�ɕύX
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
