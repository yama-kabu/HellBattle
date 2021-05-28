using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool HPSwitch = false;
    bool SESwitch, Barrier = false;

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

    float EventTime;

    void Start()
    {
        EventSwitch = false;
        Aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        //�C�x���g�����܂ł̎��Ԃ̐U�ꕝ�����߂�
        if (EventSwitch == false)
        {
            EventCount = Random.Range(TimeA, TimeB);
            //�C�x���g�̌���c�����A���̒����烉���_���Ȑ������o��
            Rand = Random.Range(1, EventNumber + 1);
            EventSwitch = true;
            SESwitch = false;
        }

        EventCount -= Time.deltaTime;

        //�J�E���g���I���Ă���Ԃ̓C�x���g���s��
        if (EventCount <= 0)
        {
            if (SESwitch == false)
            {
                Aud.PlayOneShot(StartSE);
                SESwitch = true;
            }
        }
    }

    //�e�C�x���g�̏���
    void Event1()//���C�t�񕜃C�x���g
    {
        //Instantiate(LifeItem);//�񕜃A�C�e������(��������܂ŃR�����g�A�E�g)

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
            //�����Ƀo���A�����̏���������
            Barrier = true;
            EventSwitch = false;
        }
        else
        {
            Rand = Random.Range(1, EventNumber + 1);
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
}
