//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager_R : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Player_R;
 
    public int Player_MAXHP = 10;
    public int Player_HP = 10;


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
