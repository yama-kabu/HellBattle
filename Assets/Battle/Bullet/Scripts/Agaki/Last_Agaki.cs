using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Last_Agaki : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn 

    Shot_Manager s_Manager;   //Shot_Manager���Ăяo�����߂̂��̂���
    GameObject HP;
    GameObject System;  //���������g�����Ƃ��ɂ��悤�����
    GameObject Player;

//--------------------------------------------------------------------------------------
//�ϐ��n

    private float interval = 22;  //���ˊԊu����
    private int launch_interval = 3;    //���ˍۂɎg�������B���R�ɒ����ł����
    float rotation_speed = 1f;  //��]���鑬�x����  �P�O�O�O�ɂ���ƕK�E�Z�݂����ɂȂ��i�悯����Ǝv���ȁj

    bool is_attack = false;   //�U���������邩�ۂ������߂���̂���  true�ɂȂ�����U���J�n���I
    bool rotation;  //��]������������@���Ȃ�false,�E�Ȃ�true



//--------------------------------------------------------------------------------------
//�������n

    public float agaki_time = 3; //�����������鎞��
    private float time_interval;    //�������Ŏ󂯂鎞�Ԃ��i�[�����
    private float agaki_damage; //�������Ŏ󂯂�_���[�W
    bool set_hp;    //�̗͂��P�O�O�ɖ߂����������

//--------------------------------------------------------------------------------------
//�ŏ��̏���

    private void Start()
    {
        s_Manager = GetComponent<Shot_Manager>();  //s_Manager�ɂ���ϐ����g����悤�ɂ����
        System = GameObject.Find("Game_Setting");   //������bool�擾

        #region �g�p�Ґݒ�
        if (this.gameObject.CompareTag("Player_L1"))
        {
            Player = GameObject.Find("Player_L1");
            HP = GameObject.Find("Hit_Body_P1");
        }
        else if (s_Manager.player.gameObject.CompareTag("Player_L2"))
        {
            Player = GameObject.Find("Player_L2");
            HP = GameObject.Find("Hit_Body_P2");
        }
        #endregion

        agaki_damage = 10 / agaki_time;    //�������Ŏ󂯂�_���[�W���v�Z
    }

//--------------------------------------------------------------------------------------
//���ˏ���

    public void Shot_agaki()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Button_R1") || Input.GetButtonDown("Button_R2")) && System.GetComponent<Setting>().last_of_agaki_check == false)
        {
            System.GetComponent<Setting>().last_of_agaki_check = true;
            set_hp = true;
            Player.GetComponent<Player_Manager_L>().used_agaki = true;
        }
        if(is_attack == false && set_hp == true)
        {
            HP.GetComponent<Player_Manager_R>().m_Player_HP += 5;   //��
            if(HP.GetComponent<Player_Manager_R>().m_Player_HP > 100)
            {
                HP.GetComponent<Player_Manager_R>().m_Player_HP = 100;
                is_attack = true;
            }
        }
        if (is_attack == true)
        {
            launch_interval++;
            //�o�鐔�𒲐����鏈��
            if (launch_interval % interval == 0)
            {
                for (int i = 0; i < 4; i++)     //������i�̐���ς���ƈ�x�ɏo��e�̐����ς���
                {
                    Vector2 Vec = new Vector2(0.0f, 10f);
                    if (i == 0)
                    {
                        Vec = Quaternion.Euler(0, 0, 100f * launch_interval) * Vec;
                    }
                    else if (i == 1)
                    {
                        Vec = Quaternion.Euler(0, 0, -100f * launch_interval) * Vec;
                    }
                    Vec.Normalize();
                    Vec = Quaternion.Euler(0, 0, (360 / 5) * i) * Vec;  //�ǂ̈ʂ̊p�x�ŏo�����v�Z�����
                    Vec *= rotation_speed;
                    //�R�����ɏo������
                    for (int bullet_counter = 0; bullet_counter < 9; bullet_counter++)
                    {
                        var a = Quaternion.Euler(0, 0, -Mathf.Atan2(Vec.x, Vec.y) * Mathf.Rad2Deg + (bullet_counter * 45));    //�R������spral�Ȃ̂łP�Q�O�x���Ƃɏo����
                        var b = Instantiate(s_Manager.BulletList[1], transform.position, a);
                        b.transform.SetParent(s_Manager.prefab.transform);    //�v���n�u��������e�ɂ��ďo����
                        b.GetComponent<Rigidbody2D>().velocity = Vec;
                    }
                }
                for (int i = 0; i < 8; i++)
                {
                    #region�@�e�̊p�x�v�Z
                    //�ʂ̊p�x
                    float Shot_Angle = i * 45;//�ύX����22.5(�S�����ł͂Ȃ��O�����̏ꍇ)
                    Vector3 Angle = transform.eulerAngles;
                    Angle.x = transform.rotation.x;
                    Angle.y = transform.rotation.y;
                    Angle.z = Shot_Angle;
                    #endregion
                    for (int j = 0; j < 2; j++)
                    {
                        #region �e�ɂ��Ă���rotation��bool�������鏈��
                        if (!rotation)
                        {
                            rotation = true;    // ����������I
                        }
                        else if (rotation)
                        {
                            rotation = false;   // �E��������I
                        }
                        #endregion
                        s_Manager.BulletList[7].GetComponent<Shot_Cross>().is_direction = rotation;
                        GameObject Shot = Instantiate(s_Manager.BulletList[7]) as GameObject;
                        Shot.transform.SetParent(s_Manager.prefab.transform);    //�v���n�u��������e�ɂ��ďo����
                        Shot.transform.rotation = Quaternion.Euler(Angle);
                        Shot.transform.position = this.transform.position;
                    }
                }
            }
        }
        if (is_attack == true)    //�_���[�W(�c��̕b�����Q�[�W�ɔ��f�����邽�߂̗̑͌�������)
        {
            time_interval += Time.deltaTime;
            if (time_interval > 0.1f)
            {
                HP.GetComponent<Player_Manager_R>().m_Player_HP -= agaki_damage;
                Debug.Log(HP.GetComponent<Player_Manager_R>().m_Player_HP);
                time_interval = 0;
            }
        }
    }
}
