//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager_L2 : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Player_L;

    private Rigidbody2D Reflect;
//--------------------------------------------------------------------------------------

    // �Q�[���̃X�^�[�g���̏���
    void Start()
    {
        //Rigidbody2D�@�R���|�[�l���g���擾���ĕϐ��@Player_L�@�Ɋi�[
        Player_L = GetComponent<Rigidbody2D>();
    }

//--------------------------------------------------------------------------------------

    // �J��Ԃ�����
    void Update()
    {

        Shot_Manager2 s_Manager2 = GetComponent<Shot_Manager2>();
        //s_Manager2.Shot1();//Way
        s_Manager2.Shot2();//spiral
        s_Manager2.Shot3();//Homing
        s_Manager2.Shot4();//Reflect
        s_Manager2.Shot5();//Barrage

        //s_Manager.Shot6();//Random_Homing
        ////////////////////��Shot7���炨�肢���܂�
    }

//--------------------------------------------------------------------------------------

}
