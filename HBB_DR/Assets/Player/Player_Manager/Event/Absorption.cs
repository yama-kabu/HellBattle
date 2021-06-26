//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorption : MonoBehaviour
{
    public GameObject pl;
    //�_���[�W�ϐ��󂯎��
    float damage;
    //�_���[�W�v�Z��󂯎��
    float ans;
    // Start is called before the first frame update
    void Start()
    {
        //������
        damage = 0;
        ans = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

//--------------------------------------------------------------------------------------

    void OnTriggerEnter2D(Collider2D BD)
    {
        //������
        ans = 0;
        damage = 0;
        if (BD.gameObject.tag == "Bullet_1" || BD.gameObject.tag == "Bullet_2" || BD.gameObject.tag == "Bullet_3")
        {
            if (BD.gameObject.GetComponent<Shot_Judgment>())
            {
                damage = BD.gameObject.GetComponent<Shot_Judgment>().damage;
            }
            else if (BD.gameObject.GetComponent<Shot_Explosion_ed>())
            {
                damage = BD.gameObject.GetComponent<Shot_Explosion_ed>().damage;
            }
            else if (BD.gameObject.GetComponent<Shot_Homing>())
            {
                damage = BD.gameObject.GetComponent<Shot_Homing>().damage;
            }
            else if (BD.gameObject.GetComponent<Shot_Random_Homing>())
            {
                damage = BD.gameObject.GetComponent<Shot_Random_Homing>().damage;
            }
            else if (BD.gameObject.GetComponent<Shot_ReflectP1>())
            {
                damage = BD.gameObject.GetComponent<Shot_ReflectP1>().damage;
            }
            else if (BD.gameObject.GetComponent<Shot_ReflectP2>())
            {
                damage = BD.gameObject.GetComponent<Shot_ReflectP2>().damage;
            }

//--------------------------------------------------------------------------------------

            //�e�̃_���[�W���l���̈��
            ans = (damage / 4);
            //��
            pl.GetComponent<Player_Manager_R>().m_Player_HP += ans;
        }
    }
}
