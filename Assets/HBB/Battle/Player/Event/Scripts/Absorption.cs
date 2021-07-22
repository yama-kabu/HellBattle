//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorption : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn 

    public GameObject pl;   //�����蔻�������ꏊ����

//--------------------------------------------------------------------------------------
//�ϐ��n

    float damage;   //�_���[�W�ϐ��̎󂯎��p����
    float ans;  //�_���[�W�v�Z��̎󂯎��悤����

//--------------------------------------------------------------------------------------
//�ŏ��̏���

    void Start()
    {
        damage = 0; //�_���[�W�ʂ������������
        ans = 0;    //�v�Z��̒l�������������
    }

//--------------------------------------------------------------------------------------
//�z�����̏���

    void OnTriggerEnter2D(Collider2D BD)
    {
        damage = 0; //�_���[�W�ʂ������������
        ans = 0;    //�v�Z��̒l�������������

        if (BD.gameObject.tag == "Bullet_1" || BD.gameObject.tag == "Bullet_2" || BD.gameObject.tag == "Bullet_3")
        {
            if (BD.gameObject.GetComponent<Shot_Common>())  //�G�ꂽ�e����_���[�W�̕ϐ������邩���ׂ��
            {
                damage = BD.gameObject.GetComponent<Shot_Common>().damage;  //�_���[�W��^�����
            }
            ans = (damage / 4);     //�񕜂���ʂ��v�Z�����
            pl.GetComponent<Player_Manager_R>().m_Player_HP += ans;     //���@�i���j�̗̑͂��񕜂������
        }
    }

//--------------------------------------------------------------------------------------

}
