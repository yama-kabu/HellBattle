//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn 

    Shot_Manager s_Manager;   //Shot_Manager���Ăяo�����߂̂��̂���

//--------------------------------------------------------------------------------------
//�ϐ��n

    public float interval;  //���ˊԊu����
    public int launch_interval = 0;    //���ˍۂɎg�������B���R�ɒ����ł����
    float duration_time = 3; //���˂������鎞�Ԃ���
    float rotation_speed = 1f;  //��]���鑬�x����  �P�O�O�O�ɂ���ƕK�E�Z�݂����ɂȂ��i�悯����Ǝv���ȁj
    public int continue_time = 3;  //��x�̑���ŏo�����鎞�Ԃ���
    float cool_time = 3; //�N�[���^�C������

    bool is_attack = false;   //�U���������邩�ۂ������߂���̂���  true�ɂȂ�����U���J�n���I
    bool is_cooltime_check = false;     //�N�[���^�C���̓����Ă��邩�`�F�b�N�����  true�̎��̓N�[���^�C��������

//--------------------------------------------------------------------------------------
//�ŏ��̏���

    private void Start()
    {
        s_Manager = GetComponent<Shot_Manager>();  //s_Manager�ɂ���ϐ����g����悤�ɂ����
    }

//--------------------------------------------------------------------------------------
//���ˏ���

    public void Shot2()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("Button_A1") || Input.GetButtonDown("Button_A2"))
        {
            //�U���̋����o�����`�F�b�N
            if (is_cooltime_check == false && is_attack == false)
            {
                is_attack = true;
            }
        }
        if (is_cooltime_check == false && is_attack == true)
        {
            launch_interval++;
            //�o�鐔�𒲐����鏈��
            if (launch_interval % interval == 0)
            {
                for (int i = 0; i < 1; i++)     //������i�̐���ς���ƈ�x�ɏo��e�̐����ς���
                {
                    Vector2 Vec = new Vector2(0.0f, 10f);
                    Vec = Quaternion.Euler(0, 0, 50f * launch_interval) * Vec;
                    Vec.Normalize();
                    Vec = Quaternion.Euler(0, 0, (360 / 5) * i) * Vec;  //�ǂ̈ʂ̊p�x�ŏo�����v�Z�����
                    Vec *= rotation_speed;
                    //�R�����ɏo������
                    for (int bullet_counter = 0; bullet_counter < 3; bullet_counter++)
                    {
                        var a = Quaternion.Euler(0, 0, -Mathf.Atan2(Vec.x, Vec.y) * Mathf.Rad2Deg + (bullet_counter * 120));    //�R������spral�Ȃ̂łP�Q�O�x���Ƃɏo����
                        var b = Instantiate(s_Manager.BulletList[1], transform.position, a);
                        b.transform.SetParent(s_Manager.prefab.transform);    //�v���n�u��������e�ɂ��ďo����
                        b.GetComponent<Rigidbody2D>().velocity = Vec;
                    }
                }
            }
        }
        if (is_attack == true && is_cooltime_check == false)
        {
            duration_time -= Time.deltaTime;
            if (duration_time <= 0)
            {
                //������
                is_attack = false;
                is_cooltime_check = true;
                duration_time = continue_time;
            }
        }
        else if (is_cooltime_check == true && is_attack == false)
        {
            //��������������
            cool_time -= Time.deltaTime;
            if (cool_time <= 0)
            {
                is_cooltime_check = false;
                cool_time = 3;
            }
        }
    }
}

