//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager_R : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Player_R;
 
    public float m_Player_MAXHP;
    public float m_Player_HP;


//--------------------------------------------------------------------------------------

    // �Q�[���̃X�^�[�g���̏���
    void Start()
    {
        //Rigidbody2D�@�R���|�[�l���g���擾���ĕϐ��@Player_R�@�Ɋi�[
        Player_R = GetComponent<Rigidbody2D>();
        m_Player_MAXHP = 100;
        m_Player_HP = m_Player_MAXHP;

    }

    //--------------------------------------------------------------------------------------
    public void Damage(float damage)
    {
        //���݂̗̑͂���_���[�W������
        m_Player_HP -= damage;
        Debug.Log(damage + "�_���[�W���󂯂Ďc��" + m_Player_HP + "�ł�");
        //�̗͂��O�ȉ��̏ꍇ
        if (m_Player_HP < 0)
        {
            m_Player_HP = 0; 
            //Destroy(this.gameObject);
        }
    }
//--------------------------------------------------------------------------------------



//--------------------------------------------------------------------------------------
}
