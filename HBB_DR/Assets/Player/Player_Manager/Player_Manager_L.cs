//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager_L : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Player_L;
    private Rigidbody2D Reflect;

    //�L�����N�^�[�I���@���u��
    public int Character;
    
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
        Shot_Manager2 s_Manager2 = GetComponent<Shot_Manager2>();

        //�v���C���[�P�������ꍇ
        if (this.gameObject.CompareTag("Player_L1"))
        {
            if (Character == 1)
            {
                //�L�����N�^�[���g����S�̒e
                //�P�ځ@����L�[�FZ�@�b�@����{�^���FA
                s_Manager1.Shot8();//Cross
                //�Q�ځ@����L�[�FX�@�b�@����{�^���FB
                s_Manager1.Shot3();//Homing
                //�R�ځ@����L�[�FC�@�b�@����{�^���FX
                s_Manager1.Shot7();//Explosion
                //�S�ځ@����L�[�FV�@�b�@����{�^���FY
                s_Manager1.Shot5();//Barrage

                //�e�X�g



                //�K�E�Z

            }
            else if (Character == 2)
            {
                //�L�����N�^�[���g����S�̒e
                //�P�ځ@����L�[�FZ�@�b�@����{�^���FA
                s_Manager1.Shot2();//spiral
                //�Q�ځ@����L�[�FX�@�b�@����{�^���FB
                s_Manager1.Shot4();//Reflect
                //�R�ځ@����L�[�FC�@�b�@����{�^���FX
                s_Manager1.Shot1();//Way
                //�S�ځ@����L�[�FV�@�b�@����{�^���FY
                s_Manager1.Shot6();//Random_Homing


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
                s_Manager2.Shot8();//Cross
                //�Q�ځ@����L�[�FX�@�b�@����{�^���FB
                s_Manager2.Shot3();//Homing
                //�R�ځ@����L�[�FC�@�b�@����{�^���FX
                s_Manager2.Shot7();//Explosion
                //�S�ځ@����L�[�FV�@�b�@����{�^���FY
                s_Manager2.Shot5();//Barrage

                //�e�X�g



                //�K�E�Z

            }
            else if (Character == 2)
            {
                //�L�����N�^�[���g����S�̒e
                //�P�ځ@����L�[�FZ�@�b�@����{�^���FA
                s_Manager2.Shot2();//spiral
                //�Q�ځ@����L�[�FX�@�b�@����{�^���FB
                s_Manager2.Shot4();//Reflect
                //�R�ځ@����L�[�FC�@�b�@����{�^���FX
                s_Manager2.Shot1();//Way
                //�S�ځ@����L�[�FV�@�b�@����{�^���FY
                s_Manager2.Shot6();//Random_Homing


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
        //--------------------------------------------------------------------------------------

        //�ۗ�
        //

    }

    //--------------------------------------------------------------------------------------

}
