//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn 

    Shot_Manager s_Manager;   //Shot_Manager���Ăяo�����߂̂��̂���

//--------------------------------------------------------------------------------------
//�ϐ��n
    
    int continue_time = 3; //�X�p�C�����̈�x�̑���ő����鎞��
    float is_attack_time = 3;
    float time_count = 0;
    
    bool rotation;  //��]������������@���Ȃ�false,�E�Ȃ�true
    bool is_attack = false; //�U���������邩�ۂ������߂���̂���  true�ɂȂ�����U���J�n���I
    bool is_cooltime_check = false; //�N�[���^�C�����������

//--------------------------------------------------------------------------------------
//�ŏ��̏���

    void Start()
    {
        s_Manager = GetComponent<Shot_Manager>(); //s_Manager�ɂ���ϐ����g����悤�ɂ����
    }

//--------------------------------------------------------------------------------------
//���ˏ���

    public void Shot8()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("Button_A1") || Input.GetButtonDown("Button_A2"))
        {
            if (is_cooltime_check == false && is_attack == false)
            {
                is_attack = true;
            }
        }
        if (is_cooltime_check == false && is_attack == true)
        {
            time_count++;
            if (time_count % 120 == 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    #region�@�e�̊p�x�v�Z
                    //�ʂ̊p�x
                    float Shot_Angle = i * 45;//�ύX����22.5(�S�����ł͂Ȃ��O�����̏ꍇ)
                    Vector3 Angle = transform.eulerAngles;
                    Angle.x = transform.rotation.x;
                    Angle.y = transform.rotation.y;
                    Angle.z = Shot_Angle;
                    #endregion
                    for (int j = 0; j < 2; j++)
                    {
                        #region �e�ɂ��Ă���rotation��bool�������鏈��
                        if (!rotation)
                        {
                            rotation = true;    // ����������I
                        }
                        else if (rotation)
                        {
                            rotation = false;   // �E��������I
                        }
                        #endregion
                        s_Manager.BulletList[7].GetComponent<Shot_Cross>().is_direction = rotation;
                        GameObject Shot = Instantiate(s_Manager.BulletList[7]) as GameObject;
                        Shot.transform.SetParent(s_Manager.prefab.transform);    //�v���n�u��������e�ɂ��ďo����
                        Shot.transform.rotation = Quaternion.Euler(Angle);
                        Shot.transform.position = this.transform.position;
                    }
                }
            }
        }
        #region �N�[���^�C������
        if (is_attack == true && is_cooltime_check == false)
        {
            is_attack_time -= Time.deltaTime;
            if (is_attack_time <= 0)
            {
                is_attack = false;
                is_cooltime_check = true;
                is_attack_time = continue_time;
            }
        }
        else if (is_cooltime_check == true && is_attack == false)
        {
            s_Manager.total_cool_time -= Time.deltaTime;
            if (s_Manager.total_cool_time <= 0)
            {
                is_cooltime_check = false;
                s_Manager.total_cool_time = 3;
            }
        }
        #endregion
    }
}
