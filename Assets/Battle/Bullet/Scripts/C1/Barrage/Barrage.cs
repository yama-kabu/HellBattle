//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn 

    Shot_Manager s_Manager;   //Shot_Manager���Ăяo�����߂̂��̂���

//--------------------------------------------------------------------------------------
//�ϐ��n

    int launch_interval = 0;    //���ˊԊu����
    float duration_time = 3;    //�ł������鎞��
    float quantity = 25;    //���˂���ʂ���
    float bullet_speed = 1f;    //�e�̑��x����
    int attack_time = 3;    //�U���������鎞�Ԃ���

    bool duration = false;  //�U�����Ă��邩�����
    bool cooltime_check = false;    //�N�[���^�C�����������

//--------------------------------------------------------------------------------------
//�ŏ��̏���

    void Start()
    {
        s_Manager = GetComponent<Shot_Manager>();  //s_Manager�ɂ���ϐ����g����悤�ɂ����
    }

//--------------------------------------------------------------------------------------
//�ŏ��̏���

    public void Shot5()
    {
        if (Input.GetKeyDown(KeyCode.V) || Input.GetButtonDown("Button_Y1") || Input.GetButtonDown("Button_Y2"))
        {
            if (cooltime_check == false && duration == false)
            {
                duration = true;
            }
        }
        if (cooltime_check == false && duration == true)
        {
            launch_interval++;
            //�����̐�����������ƁA���ł����e�̗ʂ𒲐����邱�Ƃ��ł���
            if (launch_interval % quantity == 0)
            {
                #region �G�Ƃ̊p�x�v�Z
                if (s_Manager.target != null)
                {
                    //�x�N�g���v�Z
                    s_Manager.distance = s_Manager.target.transform.position - s_Manager.player.transform.position;
                }
                else if (s_Manager.target == null)
                {
                    s_Manager.distance = s_Manager.player.transform.position;
                }
                #endregion
                #region�@�e���΂�����
                Vector2 vec = new Vector2(0.0f, 1.0f);
                vec = Quaternion.Euler(0, 0, Random.Range(-35f, 35f)) * vec;
                vec *= bullet_speed;
                var q = Quaternion.Euler(0, 0, -Mathf.Atan2(s_Manager.distance.x + Random.Range(-400f, 400f), s_Manager.distance.y + Random.Range(-40f, 40f)) * Mathf.Rad2Deg);
                var t = Instantiate(s_Manager.BulletList[4], transform.position, q);
                t.transform.SetParent(s_Manager.prefab.transform);    //�v���n�u��������e�ɂ��ďo����
                t.GetComponent<Rigidbody2D>().velocity = vec;
                #endregion
            }
        }
        #region �N�[���^�C���̏���
        if (duration == true && cooltime_check == false)
        {
            duration_time -= Time.deltaTime;
            if (duration_time <= 0)
            {
                duration = false;
                cooltime_check = true;
                duration_time = attack_time;
            }
        }
        else if (cooltime_check == true && duration == false)
        {
            s_Manager.total_cool_time -= Time.deltaTime;
            if (s_Manager.total_cool_time <= 0)
            {
                cooltime_check = false;
                s_Manager.total_cool_time = 3;
                launch_interval = 0;
            }
        }
        #endregion
    }
}
