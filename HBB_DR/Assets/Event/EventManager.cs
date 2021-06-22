using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EventManager : MonoBehaviour
{
    AudioSource Aud;
    public AudioClip StartSE;//�C�x���g����SE

    //A�`B�̊ԂɃC�x���g�𔭐�������
    public float TimeA;
    public float TimeB;

    //�C�x���g�̐�
    public int EventNumber;

    //�C�x���g�����p�ϐ�
    int Rand;//�����i�[
    public float AtcRatio;//�U���̓A�b�v�{��
    float AtcBOX1, AtcBOX2;//���̍U���͂�ۊǂ��Ă����ϐ�
    public bool EventSwitch;//���Ԃ̗��������𐧌䂷��X�C�b�`
    public float PlayerSlow;//���ԓ݉����̃v���C���[���x
    public float BulletSpeed1, BulletSpeed2;//���ԓ݉����̃v���C���[���x
    float Time2, Time3, Time5;
    bool SESwitch, Barrier = false;
    float EventTime;
    public bool B_Switch = false;
    public bool HPSwitch = false;
    bool OnOff = false;

    //�C�x���g�܂ł̃J�E���g�_�E��
    float EventCount;
    //�e�C�x���g�̎���
    public float Time_AtcUP, Time_Speed, Time_HP;

    //�v���C���[�I�u�W�F�N�g�i�[
    public GameObject Player1;
    public GameObject Player2;
    //�v���C���[�X�e�[�^�X�i�[
    float HP1 = 0, Atc1, Speed1, BSpeed1;//Player1
    float HP2 = 1, Atc2, Speed2, BSpeed2;//Player2

    //�A�C�e���i�[
    public GameObject LifeItem;

    //�A�i�E���X����
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

        //�C�x���g�����܂ł̎��Ԃ̐U�ꕝ�����߂�
        //�ǂ̃C�x���g���s�������߂�
        if (EventSwitch == false && OnOff == true)
        {
            EventCount = UnityEngine.Random.Range(TimeA, TimeB);
            //�C�x���g�̌���c�����A���̒����烉���_���Ȑ������o��
            Rand = UnityEngine.Random.Range(1, EventNumber + 1);
            EventSwitch = true;
            SESwitch = false;
        }

        EventCount -= Time.deltaTime;//�C�x���g�����܂ł̃J�E���g�_�E��

        //�y�f�o�b�O�p�z�������L�[�̔ԍ��̃C�x���g�ɕύX
        Eventchange();

        //�J�E���g���I���Ă���Ԃ̓C�x���g���s��
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

    //�e�C�x���g�̏���
    void Event1()//���C�t�񕜃C�x���g
    {
        var Item = Instantiate(LifeItem, new Vector2(-5, 5), Quaternion.identity);
        var Item2 = Instantiate(LifeItem, new Vector2(5, -5), Quaternion.Euler(0, 0, 180f));

        //�Ō�ɃX�C�b�`��߂��ăJ�E���g�̗����𐶐��ł���悤�ɂ���
        EventSwitch = false;
    }

    void Event2()//�s���v���C���[�U���̓A�b�v�C�x���g
    {
        /*�����Ƀv���C���[�̍U���͂��Q�Ƃ��镶������*/
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

        if (Time_AtcUP <= Time2)//�U���͂����ɖ߂�
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
        HPSwitch = true;//������v���C���[�����ŎQ�Ƃ��āA�z���U��������
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
                    Debug.Log(Rand);
                    break;
                }
            }
        }
    }
}
