//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager_L : MonoBehaviour
{
    private Rigidbody2D Reflect;

    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Player_L;

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
        Shot_Manager s_Manager = GetComponent<Shot_Manager>();
        s_Manager.Shot1();//Way
        s_Manager.Shot2();//spiral
        s_Manager.Shot3();//Homing
        s_Manager.Shot4();//Reflect
        //s_Manager.Shot5();//Barrage
        ////////////////////��Shot6���炨�肢���܂�
    }

//--------------------------------------------------------------------------------------

}