using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D P2;
    //���@�̈ړ����x���i�[����ϐ��i�����l�T�j
    public float speed = 5;
    //Player2�v���n�u1
    public GameObject Shot_RightShift;
    //       �v���n�u2
    public GameObject Shot_RightControl;
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
        //Rigidbody2D�@�R���|�[�l���g���擾���ĕϐ��@P2�@�Ɋi�[
        P2 = GetComponent<Rigidbody2D>();

    }

 //--------------------------------------------------------------------------------------

    // �J��Ԃ�����
    void Update()
    {

        //�Eshift�L�[���͒e�ۂ𔭎�
        Shot_Normal();
        //�Ectrl�L�[���͂Œe�۔���
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
        //RightShift�L�[���������ۂ̔���
        if (Input.GetKey(KeyCode.RightShift))
        {
            //�o�ߎ���
            if (ShotTime_Normal >= ElapsedTime)
            {
                ShotTime_Normal = 0;
            }
            //�摜�\��
            if (ShotTime_Normal == 0)
            {
                GameObject Circle = Instantiate(Shot_RightShift);

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
        if (Input.GetKey(KeyCode.RightControl))
        {
            //�o�ߎ���
            if (ShotTime_Way >= ElapsedTime)
            {
                ShotTime_Way = 0;
            }

            //�摜�\��
            if (ShotTime_Way == 0)
            {

                for (int i = 0; i <= 7; i++)
                {
                   
                    //�e�ۂ̊p�x
                    float ShotAngle = i * 45;  //�ύX����22.5

                    Vector3 Angle = transform.eulerAngles;
                    Angle.x = transform.rotation.x;
                    Angle.y = transform.rotation.y;
                    Angle.z = ShotAngle;

                    //�p�x
                    Shot_RightControl.transform.rotation = Quaternion.Euler(Angle);
                    //�摜�̏ꏊ�Ăяo��
                    Shot_RightControl.transform.position = this.transform.position;
                    //�摜�̕\��
                    GameObject Circle = Instantiate(Shot_RightControl) as GameObject;

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
        if (Input.GetKey("left"))
        {
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x -= PlayerSpeed.x;
        }
        else if (Input.GetKey("right"))
        { // �E�L�[�����������Ă�����
          // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x += PlayerSpeed.x;
        }
        else if (Input.GetKey("up"))
        { // ��L�[�����������Ă�����
          // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey("down"))
        { // ���L�[�����������Ă�����
          // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y -= PlayerSpeed.y;
        }
        // ���݂̈ʒu�ɉ��Z���Z���s����Position��������
        transform.position = Position;
    }

//--------------------------------------------------------------------------------------


}
