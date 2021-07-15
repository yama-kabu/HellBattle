//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Manager : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn 
    public List<GameObject> BulletList; //�e�����X�g�������

    //�X�^�[�g��player�ʒu��
    public GameObject player;
    //�^�[�Q�b�g��G�̈ʒu��
    public GameObject target;
    public Vector3 distance;

    public GameObject prefab;  //�v���n�u�̐e���Q�Ƃ����
//--------------------------------------------------------------------------------------
//�ϐ��n

    public float total_cool_time = 3;//�S�̂̃N�[���^�C�������߂�

//--------------------------------------------------------------------------------------
//�ŏ��̏���

    void Start()
    {
        //�ǂ�������ΏۂƊp�x�𑪂�X�^�[�g�n�_�����߂��
        #region �Ώېݒ�
        if (this.gameObject.CompareTag("Player_L1"))
        {
            player = GameObject.Find("Player_L1");
            target = GameObject.Find("Hit_Body_P2");
            prefab = GameObject.Find("Right_Panel");
        }
        else if (this.gameObject.CompareTag("Player_L2"))
        {
            player = GameObject.Find("Player_L2");
            target = GameObject.Find("Hit_Body_P1");
            prefab = GameObject.Find("Left_Panel");
        }
        #endregion
    }
}