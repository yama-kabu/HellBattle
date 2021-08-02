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
    public bool agaki = false;  //���������g���邩�ǂ����𔻒肷���
    public bool used_agaki = false; //�L�����N�^�[���A�K�L���g�������ǂ���

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
    [SerializeField]
    Last_Agaki s_Agaki;
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
                    if (used_agaki == false)
                    {
                        //�P�ځ@����L�[�FZ�@�b�@����{�^���FA
                        s_Cross.Shot8();//Cross
                        //�Q�ځ@����L�[�FX�@�b�@����{�^���FB
                        s_Homing.Shot3();//Homing
                        //�R�ځ@����L�[�FC�@�b�@����{�^���FX
                        s_Explosion.Shot7();//Explosion
                        //�S�ځ@����L�[�FV�@�b�@����{�^���FY
                        s_Barrage.Shot5();//Barrage
                    }
                    //�K�E�Z
                    if (agaki == true)
                    {
                        s_Agaki.Shot_agaki();
                    }
                }
                else if (Character == 2)
                {
                    //�L�����N�^�[���g����S�̒e
                    if (used_agaki == false)
                    {
                        //�P�ځ@����L�[�FZ�@�b�@����{�^���FA
                        s_Spiral.Shot2();//spiral
                        //�Q�ځ@����L�[�FX�@�b�@����{�^���FB
                        s_Reflect.Shot4();//Reflect
                        //�R�ځ@����L�[�FC�@�b�@����{�^���FX
                        s_Way.Shot1();//Way
                        //�S�ځ@����L�[�FV�@�b�@����{�^���FY
                        s_Random_Homing.Shot6();//Random_Homing
                    }
                    //�K�E�Z
                    if (agaki == true)
                    {
                        s_Agaki.Shot_agaki();
                    }
                }

                else if (Character == 3)
                {
                    //�P�ځ@����L�[�FZ�@�b�@����{�^���FA
                    s_Cross.Shot8();//Cross
                                    //�Q�ځ@����L�[�FX�@�b�@����{�^���FB
                    s_Homing.Shot3();//Homing
                                     //�R�ځ@����L�[�FC�@�b�@����{�^���FX
                    s_Explosion.Shot7();//Explosion
                                        //�S�ځ@����L�[�FV�@�b�@����{�^���FY
                    s_Barrage.Shot5();//Barrage
                }
                //�K�E�Z
                if (agaki == true)
                {
                    s_Agaki.Shot_agaki();
                }

            }
            //�v���C���[�Q�������ꍇ
            else if (this.gameObject.CompareTag("Player_L2"))
            {
                if (Character == 1)
                {
                    //�L�����N�^�[���g����S�̒e
                    if (used_agaki == false)
                    {
                        //�P�ځ@����L�[�FZ�@�b�@����{�^���FA
                        s_Cross.Shot8();//Cross
                        //�Q�ځ@����L�[�FX�@�b�@����{�^���FB
                        s_Homing.Shot3();//Homing
                        //�R�ځ@����L�[�FC�@�b�@����{�^���FX
                        s_Explosion.Shot7();//Explosion
                        //�S�ځ@����L�[�FV�@�b�@����{�^���FY
                        s_Barrage.Shot5();//Barrage
                    }
                    //�K�E�Z
                    if (agaki == true)
                    {
                        s_Agaki.Shot_agaki();
                    }
                }
                else if (Character == 2)
                {
                    //�L�����N�^�[���g����S�̒e
                    if (used_agaki == false)
                    {
                        //�P�ځ@����L�[�FZ�@�b�@����{�^���FA
                        s_Spiral.Shot2();//spiral
                        //�Q�ځ@����L�[�FX�@�b�@����{�^���FB
                        s_Reflect.Shot4();//Reflect
                        //�R�ځ@����L�[�FC�@�b�@����{�^���FX
                        s_Way.Shot1();//Way
                        //�S�ځ@����L�[�FV�@�b�@����{�^���FY
                        s_Random_Homing.Shot6();//Random_Homing
                    }
                    //�K�E�Z
                    if (agaki == true)
                    {
                        s_Agaki.Shot_agaki();
                    }
                }

                else if (Character == 3)
                {
                    //�L�����N�^�[���g����S�̒e
                    if (used_agaki == false)
                    {
                        //�P�ځ@����L�[�FZ�@�b�@����{�^���FA
                        s_Cross.Shot8();//Cross
                        //�Q�ځ@����L�[�FX�@�b�@����{�^���FB
                        s_Homing.Shot3();//Homing
                        //�R�ځ@����L�[�FC�@�b�@����{�^���FX
                        s_Explosion.Shot7();//Explosion
                        //�S�ځ@����L�[�FV�@�b�@����{�^���FY
                        s_Barrage.Shot5();//Barrage
                    }
                    //�K�E�Z
                    if (agaki == true)
                    {
                        s_Agaki.Shot_agaki();
                    }
                }

            }
        }
    }
//--------------------------------------------------------------------------------------
}