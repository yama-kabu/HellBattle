//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn 

    Shot_Homing s_Homing;
    Shot_Manager s_Manager;   //Shot_Manager���Ăяo�����߂̂��̂���

//--------------------------------------------------------------------------------------
//�ϐ��n

    float cooltime_count = 100; //�N�[���^�C���̎��Ԃ���
    float cooltime = 10; //�N�[���^�C���̊�l����

//--------------------------------------------------------------------------------------
//�ŏ��̏���

    void Start()
    {
        s_Manager = GetComponent<Shot_Manager>(); //s_Manager�ɂ���ϐ����g����悤�ɂ����
    }

//--------------------------------------------------------------------------------------
//���ˏ���

    public void Shot3()
    {
        if (cooltime_count < cooltime)
        {
            cooltime_count += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.X) || Input.GetButtonDown("Button_B1") || Input.GetButtonDown("Button_B2"))
        {
            if ((cooltime_count > cooltime))
            {
                GameObject Shot = Instantiate(s_Manager.BulletList[2]);
                Shot.transform.SetParent(s_Manager.prefab.transform);    //�v���n�u��������e�ɂ��ďo����
                Shot.transform.position = this.transform.position;
                //������
                cooltime_count = 0;
            }
        }
    }
}