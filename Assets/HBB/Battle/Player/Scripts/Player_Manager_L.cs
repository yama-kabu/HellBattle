//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager_L : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn

    
    private Rigidbody2D Player_L;   //Rigidbody2D �R���|�[�l���g���i�[����ϐ�����
    private Rigidbody2D Reflect;    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�����
    GameObject System;//���s�����߂�ϐ��A�X�^�[�g���Ă��邩�����߂�ϐ���������̂���

//--------------------------------------------------------------------------------------
//�ϐ��n

    public int Character; //�L�����N�^�[�I������@�P�C�Q�C�R���Ή����Ă����
    public float AttackPower_percent = 1;//�L�����N�^�[�̍U����[%]

    [SerializeField]
    Way s_Way;
    [SerializeField]
    Spiral s_Spiral;
    [SerializeField]
    Homing s_Homing;
    [SerializeField]
    Reflect s_Reflect;
    [SerializeField]
    Barrage s_Barrage;
    [SerializeField]
    Random_Homing s_Random_Homing;
    [SerializeField]
    Explosion s_Explosion;
    [SerializeField]
    Cross s_Cross;
 
//--------------------------------------------------------------------------------------
//�Q�[���̃X�^�[�g���̏���

    void Start()
    {
        //Rigidbody2D�@�R���|�[�l���g���擾���ĕϐ��@Player_L�@�Ɋi�[
        Player_L = GetComponent<Rigidbody2D>();
        //���sBool�擾
        System = GameObject.Find("Game_Setting");
    }

//--------------------------------------------------------------------------------------
// �J��Ԃ�����

    void Update()
    {

        //�Q�[�����X�^�[�g���Ă��āA���s�����Ă��Ȃ������ꍇ�e��ł��Ƃ�����
        if (System.GetComponent<Start_Timer>().is_start_chack && !System.GetComponent<Setting>().syouhai)
        {
            //�v���C���[�P�������ꍇ
            if (this.gameObject.CompareTag("Player_L1"))
            {
                if (Character == 1)
                {
                    //�L�����N�^�[���g����S�̒e
                    //�P�ځ@����L�[�FZ�@�b�@����{�^���FA
                    s_Cross.Shot8();//Cross
                    //�Q�ځ@����L�[�FX�@�b�@����{�^���FB
                    s_Homing.Shot3();//Homing
                    //�R�ځ@����L�[�FC�@�b�@����{�^���FX
                    s_Explosion.Shot7();//Explosion
                    //�S�ځ@����L�[�FV�@�b�@����{�^���FY
                    s_Barrage.Shot5();//Barrage
                    //�e�X�g

                    //�K�E�Z

                }
                else if (Character == 2)
                {
                    //�L�����N�^�[���g����S�̒e
                    //�P�ځ@����L�[�FZ�@�b�@����{�^���FA
                    s_Spiral.Shot2();//spiral
                    //�Q�ځ@����L�[�FX�@�b�@����{�^���FB
                    s_Reflect.Shot4();//Reflect
                    //�R�ځ@����L�[�FC�@�b�@����{�^���FX
                    s_Way.Shot1();//Way
                    //�S�ځ@����L�[�FV�@�b�@����{�^���FY
                    s_Random_Homing.Shot6();//Random_Homing


                    //�K�E�Z

                }
                /*
                else if (Character == 3)
                {
                    //�L�����N�^�[���g����S�̒e
                    //�P�ځ@����L�[�FZ�@�b�@����{�^���FA

                    //�Q�ځ@����L�[�FX�@�b�@����{�^���FB

                    //�R�ځ@����L�[�FC�@�b�@����{�^���FX

                    //�S�ځ@����L�[�FV�@�b�@����{�^���FY



                    //�K�E�Z

                }
                */
            }
            //�v���C���[�Q�������ꍇ
            else if (this.gameObject.CompareTag("Player_L2"))
            {
                if (Character == 1)
                {
                    //�L�����N�^�[���g����S�̒e
                    //�P�ځ@����L�[�FZ�@�b�@����{�^���FA
                    s_Cross.Shot8();//Cross
                    //�Q�ځ@����L�[�FX�@�b�@����{�^���FB
                    s_Homing.Shot3();//Homing
                    //�R�ځ@����L�[�FC�@�b�@����{�^���FX
                    s_Explosion.Shot7();//Explosion
                    //�S�ځ@����L�[�FV�@�b�@����{�^���FY
                    s_Barrage.Shot5();//Barrage

                    //�e�X�g


                    //�K�E�Z

                }
                else if (Character == 2)
                {
                    //�L�����N�^�[���g����S�̒e
                    //�P�ځ@����L�[�FZ�@�b�@����{�^���FA
                    s_Spiral.Shot2();//spiral
                    //�Q�ځ@����L�[�FX�@�b�@����{�^���FB
                    s_Reflect.Shot4();//Reflect
                    //�R�ځ@����L�[�FC�@�b�@����{�^���FX
                    s_Way.Shot1();//Way
                    //�S�ځ@����L�[�FV�@�b�@����{�^���FY
                    s_Random_Homing.Shot6();//Random_Homing


                    //�K�E�Z

                }
                /*
                else if (Character == 3)
                {
                    //�L�����N�^�[���g����S�̒e
                    //�P�ځ@����L�[�FZ�@�b�@����{�^���FA

                    //�Q�ځ@����L�[�FX�@�b�@����{�^���FB

                    //�R�ځ@����L�[�FC�@�b�@����{�^���FX

                    //�S�ځ@����L�[�FV�@�b�@����{�^���FY

                    //�K�E�Z

                }
                */
            }
        }
    }
//--------------------------------------------------------------------------------------
}