//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn

    Shot_Manager s_Manager;   //Shot_Manager���Ăяo�����߂̂��̂���

//--------------------------------------------------------------------------------------
//�ϐ��n

    float bullet_Speed = 1f;    //�e�̑��x����
    float launch_time = 0;   //���ˎ��Ԃ���
    float push_count_time = 0;  //�{�^����t���Ԃ��L��������̂���
    int push_count = 0;     //�{�^���̉����ꂽ�񐔂���
    int bullet_number = 1;  //�e�̔��˂��鐔����@�O���炶��Ȃ��ĂP���炾��

    bool is_attack = false;     //�U���������邩�ۂ������߂���̂���    true�ɂȂ�����U���J�n���I

//--------------------------------------------------------------------------------------
//�ŏ��̏���

    private void Start()
    {
        s_Manager = GetComponent<Shot_Manager>();     //s_Manager�ɂ���ϐ����g����悤�ɂ����
    }

//--------------------------------------------------------------------------------------
//�{�^���������Ă��甭�˂����܂ł̏���

    public void Shot1()
    {
        //�{�^�����ǂꂾ�����������̏���
        if (Input.GetKeyDown(KeyCode.C) || Input.GetButtonDown("Button_X1") || Input.GetButtonDown("Button_X2"))
        {
            if (!is_attack)     //�U�����s���Ă��Ȃ����Ƃ��m�F�����
            {
                if (push_count < 5)     //MAX�T��܂ŉ������Ƃ��ł����
                {
                    push_count++;
                }
                else if (push_count == 5)
                {
                    is_attack = true;
                }
            }
        }

        #region �{�^�����󂯕t���鎞�ԂɊւ��鏈��
        if (push_count_time < 2 && push_count != 0)     //�Q�b�܂Ŏ󂯕t�����
        {
            push_count_time += Time.deltaTime;
        }
        else if (push_count_time > 2)   //�Q�b��������T�񉟂���Ă��Ȃ��Ă��U�����܂Ŏ����Ă�����
        {
            is_attack = true;
        }
        #endregion
        //���ˊԊu�₤���I���̏������̏���
        if (is_attack)
        {
            launch_time += Time.deltaTime;
            if (launch_time > 0.5 && push_count != 0 && push_count >= bullet_number)    //�{�^�����������񐔂ɂȂ�܂ŁA0.5�b���Ƃɔ��˂����
            {
                #region �G�Ƃ̊p�x�v�Z
                if (s_Manager.target != null)
                {
                    s_Manager.distance = s_Manager.target.transform.position - s_Manager.player.transform.position;
                }
                else if (s_Manager.target == null)
                {
                    s_Manager.distance = s_Manager.player.transform.position;
                }
                #endregion
                if (bullet_number == 5)     //bullet_number���P����X�^�[�g�ɂȂ��Ă��邽�� �O�`�S+�P�Ŕ��f�����
                {
                    for (int i = 0; i < 5; i++)
                    {
                        way(s_Manager.distance, bullet_number, i);
                    }
                }
                else if (bullet_number < 5)
                {
                    for (int i = 0; i < bullet_number; i++)
                    {
                        way(s_Manager.distance, bullet_number, i);
                    }
                }
                bullet_number++;
                launch_time = 0;    //�Čv�Z���s�����߂Ɏ��Ԃ͏����������
            }
            #region ����������
            if (push_count < bullet_number)
            {
                launch_time = 0;
                push_count = 0;
                bullet_number = 1;  //bullet_number�͔��˂���e���P������X�^�[�g���邽�ߏ������͂P
                push_count_time = 0;
                is_attack = false;
            }
            #endregion
        }
    }

//--------------------------------------------------------------------------------------
//���ˏ���

    public void way(Vector3 Distance, int Way_count, int i)
    {
        Vector2 vec = new Vector2(0.0f, 1.0f);
        vec = Quaternion.Euler(0, 0, 0) * vec;
        vec *= bullet_Speed;
        var q = Quaternion.Euler(0, 0, 0);  //�܂��͑������O�ɏ��������s����
        #region �ecount�ɑΉ������e�̔��ˏ���
        if (Way_count == 1)
        {
            q = Quaternion.Euler(0, 0, (-Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg));
        }
        else if (Way_count == 2)
        {
            q = Quaternion.Euler(0, 0, (-Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg) + (-3 + (6 * i)));
        }
        else if (Way_count == 3)
        {
            q = Quaternion.Euler(0, 0, (-Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg) + (-4 + (4 * i)));
        }
        else if (Way_count == 4)
        {
            q = Quaternion.Euler(0, 0, (-Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg) + (-6 + (4 * i)));
        }
        else if (Way_count == 5)
        {
            q = Quaternion.Euler(0, 0, (-Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg) + (-10 + (5 * i)));
        }
        #endregion
        var t = Instantiate(s_Manager.BulletList[0], transform.position, q);   //��ɂ܂Ƃ߂���I
        t.transform.SetParent(s_Manager.prefab.transform);    //�v���n�u��������e�ɂ��ďo����
        t.GetComponent<Rigidbody2D>().velocity = vec;   //���ˁI
    }
}
