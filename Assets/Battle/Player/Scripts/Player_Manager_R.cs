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

    //���s�����߂�ϐ������悤
    GameObject Syouhai;
    GameObject PA;  //�e�����������ۂ̃v���C���[���󂯂�_���[�W�ʂ𒲂ׂ�ς�����
//--------------------------------------------------------------------------------------

    // �Q�[���̃X�^�[�g���̏���
    void Start()
    {
        //Rigidbody2D�@�R���|�[�l���g���擾���ĕϐ��@Player_R�@�Ɋi�[
        Player_R = GetComponent<Rigidbody2D>();
        m_Player_MAXHP = 100;
        m_Player_HP = m_Player_MAXHP;

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
//�e�ɓ��������ۂ̏���
    public void Damage(float damage)
    {
        //�_���[�W�{���̌v�Z
        damage *= PA.GetComponent<Player_Manager_L>().AttackPower_percent;
        //���݂̗̑͂���_���[�W������(�{���v�Z�͍s��)
        m_Player_HP -= damage;
        Debug.Log(damage + "�_���[�W���󂯂Ďc��" + m_Player_HP + "�ł�");
        //�̗͂��O�ȉ��̏ꍇ
        if (m_Player_HP <= 0)
        {
            #region �U�����@�폜
            if (this.gameObject.CompareTag("Hit_Body_P1"))
            {
                GameObject PL = GameObject.Find("Player_L1");
                GameObject PR = GameObject.Find("Player_R1_Ma");
                Destroy(PL);
                //�{�̍폜
                Destroy(PR);
            }
            else if (this.gameObject.CompareTag("Hit_Body_P2"))
            {
                GameObject PL = GameObject.Find("Player_L2");
                GameObject PR = GameObject.Find("Player_R2_Ma");
                Destroy(PL);
                //�{�̍폜
                Destroy(PR);
            }
            #endregion
            Debug.Log("�̗͂� [0] �ɂȂ�܂����B");
            //�e�̔��˂��~�߂�
            Syouhai.GetComponent<Setting>().syouhai = true;
            Debug.Log("�Q�[���I��");
        }
    }
//--------------------------------------------------------------------------------------



//--------------------------------------------------------------------------------------
}
