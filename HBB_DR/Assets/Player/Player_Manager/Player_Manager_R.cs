//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager_R : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Player_R;
 
    public float m_Player_MAXHP = 0;
    public float m_Player_HP = 0;


//--------------------------------------------------------------------------------------

    // �Q�[���̃X�^�[�g���̏���
    void Start()
    {
        //Rigidbody2D�@�R���|�[�l���g���擾���ĕϐ��@Player_R�@�Ɋi�[
        Player_R = GetComponent<Rigidbody2D>();


        m_Player_MAXHP = 100;
        m_Player_HP = 100;

    }

//--------------------------------------------------------------------------------------

    // �J��Ԃ�����
    void Update()
    {
        //Debug.Log("�c��̗̑͂�" + m_Player_HP + "�ł�");
        if (m_Player_HP < 0)
        {
            Destroy(this.gameObject);
        }
    }

//--------------------------------------------------------------------------------------
    public void Damage(float damage)
    {
        m_Player_HP -= damage;
    }


//--------------------------------------------------------------------------------------
}
