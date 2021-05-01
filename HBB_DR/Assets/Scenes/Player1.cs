using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D P1;
    //���@�̈ړ����x���i�[����ϐ��i�����l�T�j
    public float speed = 5;
    //Player1�v���n�u1
    public GameObject Shot_Z;
    //       �v���n�u2
    public GameObject Shot_X;
    //Normal�e���ˎ���
    float ShotTime_Normal = 0;
    //Way�e���ˎ���
    float ShotTime_Way = 0;
    //�e�ۂ̌o�ߎ���
    public float ElapsedTime = 0;
    //�e�ۑ��x
    public float BulletSpeed = 0;

    public Vector2 PlayerSpeed = new Vector2(0.005f, 0.005f);
//--------------------------------------------------------------------------------------

    // �Q�[���̃X�^�[�g���̏���
    void Start()
    {
        //Rigidbody2D�@�R���|�[�l���g���擾���ĕϐ��@P1�@�Ɋi�[
        P1 = GetComponent<Rigidbody2D>();

    }

//--------------------------------------------------------------------------------------

    // �J��Ԃ�����
    void Update()
    {

        //Z�L�[���͒e�ۂ𔭎�
        Shot_Normal();
        //X�L�[���͂Œe�۔���
        Shot_Way();
        //Normal�e�۔��ˊԊu�v��
        ShotTime_Normal += Time.deltaTime;
        //Way�e�۔��ˊԊu�v��
        ShotTime_Way += Time.deltaTime;

        // �ړ�����
        Move();
    }

//--------------------------------------------------------------------------------------

    //�e�ۂ̏���
    //�V���b�g_Normal
    void Shot_Normal()
    {
        //Z�L�[���������ۂ̔���
        if (Input.GetKey(KeyCode.Z))
        {
            //�o�ߎ���
            if (ShotTime_Normal >= ElapsedTime)
            {
                ShotTime_Normal = 0;
            }
            //�摜�\��
            if (ShotTime_Normal == 0)
            {
                GameObject Circle = Instantiate(Shot_Z);

                Circle.transform.position = this.transform.position;

            }
        }
    }

//--------------------------------------------------------------------------------------

    //�e�ۂ̏���
    //�V���b�g_Way
    void Shot_Way()
    {
        //X�L�[���������ۂ̔���
        if (Input.GetKey(KeyCode.X))
        {
            //�o�ߎ���
            if (ShotTime_Way >= ElapsedTime)
            {
                ShotTime_Way = 0;
            }

            //�摜�\��
            if (ShotTime_Way == 0)
            {

                for (int i = 1; i <= 8; i++)
                {
                    //�e�ۂ̊p�x
                    float ShotAngle = i * 45;  //�ύX����22.5

                    Vector3 Angle = transform.eulerAngles;
                    Angle.x = transform.rotation.x;
                    Angle.y = transform.rotation.y;
                    Angle.z = ShotAngle;

                    //�摜�̌Ăяo��
                    GameObject Circle = Instantiate(Shot_X) as GameObject;
                    //�p�x
                    Shot_X.transform.rotation = Quaternion.Euler(Angle);
                    //�摜�̕\��
                    Shot_X.transform.position = this.transform.position;

                }

            }
        }
    }

//--------------------------------------------------------------------------------------

    // �ړ�
    void Move()
    {
        // ���݈ʒu��Position�ɑ��
        Vector2 Position = transform.position;
        // ���L�[�����������Ă�����
        if (Input.GetKey("a"))
        {
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x -= PlayerSpeed.x;
        }
        else if (Input.GetKey("d"))
        { // �E�L�[�����������Ă�����
          // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x += PlayerSpeed.x;
        }
        else if (Input.GetKey("w"))
        { // ��L�[�����������Ă�����
          // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey("s"))
        { // ���L�[�����������Ă�����
          // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y -= PlayerSpeed.y;
        }
        // ���݂̈ʒu�ɉ��Z���Z���s����Position��������
        transform.position = Position;
    }

//--------------------------------------------------------------------------------------


}
