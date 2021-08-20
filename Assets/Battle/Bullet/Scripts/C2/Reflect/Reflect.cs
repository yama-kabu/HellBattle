//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflect : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn 

    Shot_Manager s_Manager;   //Shot_Manager���Ăяo�����߂̂��̂���

//--------------------------------------------------------------------------------------
//�ϐ��n

    float cooltime_count = 100;//Shot4�p�̃N�[���^�C���J�E���^�[

//--------------------------------------------------------------------------------------
//�ŏ��̏���

    private void Start()
    {
        s_Manager = GetComponent<Shot_Manager>();  //s_Manager�ɂ���ϐ����g����悤�ɂ����
        //�ǂ�������ΏۂƊp�x�𑪂�X�^�[�g�n�_�����߂��
        #region �Ώۂ̐ݒ�
        if (this.gameObject.CompareTag("Player_L1"))
        {
            s_Manager.player = GameObject.Find("Player_L1");
            s_Manager.target = GameObject.Find("Hit_Body_P2");
        }
        else if (s_Manager.player.gameObject.CompareTag("Player_L2"))
        {
            s_Manager.player = GameObject.Find("Player_L2");
            s_Manager.target = GameObject.Find("Hit_Body_P1");
        }
        #endregion
    }

    //--------------------------------------------------------------------------------------
    //���ˏ���

    public void Shot4()
    {
        cooltime_count += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.X) || Input.GetButtonDown("Button_B1") || Input.GetButtonDown("Button_B2"))
        {
            //���ˊԊu�̒���
            if (cooltime_count >= s_Manager.total_cool_time)
            {
                cooltime_count = 0;
            }
            #region ���ˏ���
            if (cooltime_count == 0)
            {
                if (s_Manager.target != null)
                {
                    //�x�N�g���v�Z
                    s_Manager.distance = s_Manager.target.transform.position - s_Manager.player.transform.position;

                }
                else if (s_Manager.target == null)
                {
                    s_Manager.distance = s_Manager.player.transform.position;
                }
                Vector2 vec = new Vector2(0.0f, 10f);
                vec = Quaternion.Euler(0, 0, 50f) * s_Manager.distance;
                //�R�����ɏo������
                for (int bullet_counter = 0; bullet_counter < 3; bullet_counter++)
                {
                    var q = Quaternion.Euler(0, 0, -Mathf.Atan2(s_Manager.distance.x, s_Manager.distance.y)
                                                               * Mathf.Rad2Deg + (-45 + (bullet_counter * 45)));    //���ꂼ��̊p�x�ɂ����
                    var t = Instantiate(s_Manager.BulletList[3], transform.position, q);   //��������
                    t.transform.SetParent(s_Manager.prefab.transform);    //�v���n�u��������e�ɂ��ďo����
                    vec.Normalize();    //�P�ɐ��K�������
                    t.GetComponent<Rigidbody2D>().velocity = vec;
                }
                //�����������
                cooltime_count = 0;
            }
            #endregion
        }
    }
}