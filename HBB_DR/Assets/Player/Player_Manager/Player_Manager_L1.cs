//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager_L1 : MonoBehaviour
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
        Shot_Manager1 s_Manager1 = GetComponent<Shot_Manager1>();
        //s_Manager1.Shot1();//Way
        s_Manager1.Shot2();//spiral
        s_Manager1.Shot3();//Homing
        s_Manager1.Shot4();//Reflect
        s_Manager1.Shot5();//Barrage


        //s_Manager.Shot6();//Random_Homing
        ////////////////////��Shot7���炨�肢���܂�
    }

//--------------------------------------------------------------------------------------

}
