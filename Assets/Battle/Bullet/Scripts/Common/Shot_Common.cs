//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Common : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn
    GameObject stage;   //�����蔻��ƂȂ�X�e�[�W�i�[����ϐ�����

    protected GameObject player_position;   //�G�Ƃ̋����𑪂鎞�Ɏg���v���C���[�̈ʒu���i�[����ϐ�����
    protected GameObject target_position;   //�G�Ƃ̋����𑪂鎞�Ɏg���^�[�Q�b�g�̈ʒu���i�[����ϐ�����
    protected Transform bullet_position;    //�G�Ƃ̋����𑪂鎞�Ɏg���e�̈ʒu���i�[����ϐ�����
    public  GameObject bullet_normal;    //�Ō�ɔ�юU�鏈��������Ƃ��Ɏg���e���i�[����ϐ����邾��

//--------------------------------------------------------------------------------------
//�ϐ��n

    public float damage;    //�e�̃_���[�W����        
    public float bullet_Speed = 0;  //�e�̑��x����

//--------------------------------------------------------------------------------------
//�ŏ��̏���

    void Start()
    {
        stage = GameObject.Find("Stage");   //�X�e�[�W�̃I�u�W�F�N�g�������
    }

//--------------------------------------------------------------------------------------
//�O�ɏo�����̏���

    void OnTriggerExit2D(Collider2D collision)
    {
        #region �X�e�[�W�O�ɒe���o��Ƃ��̏�������
        if (collision.gameObject.tag == "BuckStage")
        {
            Destroy(this.gameObject);   //�e���̂����������
        }
        #endregion
    }

//--------------------------------------------------------------------------------------
//�ڐG���̏���

    void OnTriggerEnter2D(Collider2D collision)
    {
        #region �_���[�W��������
        if (collision.gameObject.tag == "Hit_Body_P1" || collision.gameObject.tag == "Hit_Body_P2")
        {
            
            if (collision.gameObject.GetComponent<Player_Manager_R>())//����̗̑͂𒲂ׂ��
            {
                collision.gameObject.GetComponent<Player_Manager_R>().Damage(damage);   //�_���[�W��^�����
            }
            Destroy(this.gameObject);
        }
        #endregion
        #region �o���A�������Ă�����e��������������
        if (collision.gameObject.tag == "Barrier")
        {
            Destroy(this.gameObject);   //�e���̂����������
        }
        #endregion
    }

//--------------------------------------------------------------------------------------

}
