//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager_R : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Player_R;
    //���@�̈ړ����x���i�[����ϐ��i�����l�T�j
    public float Speed = 5;
    
    public int Player_MAXHP;
    public int Player_HP;


//--------------------------------------------------------------------------------------

    // �Q�[���̃X�^�[�g���̏���
    void Start()
    {
        //Rigidbody2D�@�R���|�[�l���g���擾���ĕϐ��@Player_R�@�Ɋi�[
        Player_R = GetComponent<Rigidbody2D>();
    }

//--------------------------------------------------------------------------------------

    // �J��Ԃ�����
    void Update()
    {
     
    }

//--------------------------------------------------------------------------------------

    void Move()
    {

    }

//--------------------------------------------------------------------------------------
}
