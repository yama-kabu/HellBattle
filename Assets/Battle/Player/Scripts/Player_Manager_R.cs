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
    public int m_set_agaki_HP;  //���������g����悤�ɂȂ�HP

    //���s�����߂�ϐ������悤
    GameObject Syouhai;
    GameObject PA;  //�e�����������ۂ̃v���C���[���󂯂�_���[�W�ʂ𒲂ׂ�ς�����

    //--------------------------------------------------------------------------------------
    // �Q�[���̃X�^�[�g���̏���

    private void Awake()
    {
        m_Player_MAXHP = 100;
        m_Player_HP = m_Player_MAXHP;
    }

    void Start()
    {
        //Rigidbody2D�@�R���|�[�l���g���擾���ĕϐ��@Player_R�@�Ɋi�[
        Player_R = GetComponent<Rigidbody2D>();

        //���sBool�擾
        Syouhai = GameObject.Find("Game_Setting");

        if (this.gameObject.CompareTag("Hit_Body_P1"))
        {
            PA = GameObject.Find("Player_L1");
        }
        else if (this.gameObject.CompareTag("Hit_Body_P2"))
        {
            PA = GameObject.Find("Player_L2");
        }
    }

//--------------------------------------------------------------------------------------
//�������Ɋւ��鏈��

    void Update()
    {
        if((m_Player_HP < m_set_agaki_HP) && (PA.GetComponent<Player_Manager_L>().agaki == false))
        {
            PA.GetComponent<Player_Manager_L>().agaki = true;   //���������g����悤�ɂ����B
        }

        //�̗͂��O�ȉ��̏ꍇ
        if (m_Player_HP <= 0)
        {
            #region �U�����@�폜
            if (this.gameObject.CompareTag("Hit_Body_P1"))
            {
                Syouhai.GetComponent<Setting>().WINER = false;   //L�Q�̏����ɂ���
                GameObject PL = GameObject.Find("Player_L1");
                GameObject PR = GameObject.Find("Player_R1_Ma");
                GameObject P_L1 = GameObject.Find("P_L1");
                GameObject P_R1 = GameObject.Find("P_R1");
                //�{�̍폜
                Destroy(PL);
                Destroy(PR);
                Destroy(P_L1);
                Destroy(P_R1);
            }
            else if (this.gameObject.CompareTag("Hit_Body_P2"))
            {
                Syouhai.GetComponent<Setting>().WINER = true; ;   //L�P�̏����ɂ���
                GameObject PL = GameObject.Find("Player_L2");
                GameObject PR = GameObject.Find("Player_R2_Ma");
                GameObject P_L2 = GameObject.Find("P_L2");
                GameObject P_R2 = GameObject.Find("P_R2");
                //�{�̍폜
                Destroy(PL);
                Destroy(PR);
                Destroy(P_L2);
                Destroy(P_R2);
            }
            #endregion
            Debug.Log("�̗͂� [0] �ɂȂ�܂����B");
            //�e�̔��˂��~�߂�
            Syouhai.GetComponent<Setting>().syouhai = true;
            Debug.Log("�Q�[���I��");
        }
    }

//--------------------------------------------------------------------------------------
//�e�ɓ��������ۂ̏���
    public void Damage(float damage)
    {
        //�_���[�W�{���̌v�Z
        damage *= PA.GetComponent<Player_Manager_L>().AttackPower_percent;
        //���݂̗̑͂���_���[�W������(�{���v�Z�͍s��)
        m_Player_HP -= damage;
        Debug.Log(damage + "�_���[�W���󂯂Ďc��" + m_Player_HP + "�ł�");
    }
//--------------------------------------------------------------------------------------



//--------------------------------------------------------------------------------------
}
