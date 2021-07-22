//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn 

    Shot_Manager s_Manager;   //Shot_Manager���Ăяo�����߂̂��̂���

//--------------------------------------------------------------------------------------
//�ϐ��n

    float cooltime_count = 100;//Shot7�p�̃N�[���^�C���J�E���^�[
    float explosion_cooltime = 5;   //�G�N�X�v���[�W�����̃N�[���^�C����

    public bool burst_prefab;   //burst��prefab�̎��Ɏg����

//--------------------------------------------------------------------------------------
//�ŏ��̏���

    void Start()
    {
        s_Manager = GetComponent<Shot_Manager>(); //s_Manager�ɂ���ϐ����g����悤�ɂ����
        //�����̈ʒu�𒲂ׂ��
        if (s_Manager.prefab.gameObject.CompareTag("Bullet_1"))
        {
            burst_prefab = true;
        }
        else if (s_Manager.prefab.gameObject.CompareTag("Bullet_2"))
        {
            burst_prefab = false;
        }
    }

//--------------------------------------------------------------------------------------
//���ˏ���

    public void Shot7()
    {
        cooltime_count += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.C) || Input.GetButtonDown("Button_X1") || Input.GetButtonDown("Button_X2"))
        {
            if (cooltime_count > explosion_cooltime)
            {
                cooltime_count = 0;
            }
            if (cooltime_count == 0)
            {
                GameObject Shot = Instantiate(s_Manager.BulletList[6]);
                Shot.transform.SetParent(s_Manager.prefab.transform);    //�v���n�u��������e�ɂ��ďo����
                Shot.transform.position = this.transform.position;
            }
        }
    }
}
