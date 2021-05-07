using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //A�`B�̊ԂɃC�x���g�𔭐�������
    public float TimeA;
    public float TimeB;

    //�C�x���g�̐�
    public int EventCount;

    //���Ԃ̗��������𐧌䂷��X�C�b�`
    public bool EventSwitch;//On�̓J�E���g���AOff�Ȃ琶��

    float EventTime;

    void Start()
    {
        EventSwitch = false;
    }

    void Update()
    {
        //�C�x���g�����܂ł̎��Ԃ̐U�ꕝ�����߂�
        if (EventSwitch == false)
        {
            EventSwitch = true;
            EventTime = Random.Range(TimeA, TimeB);
        }

        //�J�E���g
        EventTime -= Time.deltaTime;

        //�J�E���g���I������C�x���g�����Ɏ��|����
        if (EventTime <= 0)
        {
            //�C�x���g�̌���c�����A���̒����烉���_���Ȑ������o��
            int Rand = Random.Range(1, EventCount+1);

            //���̔ԍ��ɂ��Ȃ񂾃C�x���g�����s
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
            //�Ō�ɃX�C�b�`��߂��ăJ�E���g�̗����𐶐��ł���悤�ɂ���
            EventSwitch = false;
        }
    }

    //�e�C�x���g�̏���
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
