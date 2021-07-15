//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Homing : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn 

    Shot_Manager s_Manager;   //Shot_Manager���Ăяo�����߂̂��̂���

//--------------------------------------------------------------------------------------
//�ϐ��n

    float cooltime_count = 100;     //�N�[���^�C���̎��Ԃ���
    float random_homing_cooltime = 15;  //�N�[���^�C���̊�l����

//--------------------------------------------------------------------------------------
//�ŏ��̏���

    void Start()
    {
        s_Manager = GetComponent<Shot_Manager>(); //s_Manager�ɂ���ϐ����g����悤�ɂ����
    }

//--------------------------------------------------------------------------------------
//���ˏ���

    public void Shot6()
    {
        cooltime_count += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.V) || Input.GetButtonDown("Button_Y1") || Input.GetButtonDown("Button_Y2"))
        {
            if (cooltime_count > random_homing_cooltime)
            {
                cooltime_count = 0;
            }
            if (cooltime_count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject Shot = Instantiate(s_Manager.BulletList[5]);
                    Shot.transform.SetParent(s_Manager.prefab.transform);    //�v���n�u��������e�ɂ��ďo����
                    Shot.transform.position = this.transform.position;
                }
            }
        }
    }
}
