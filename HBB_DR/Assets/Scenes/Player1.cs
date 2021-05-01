using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D P1;
    //���@�̈ړ����x���i�[����ϐ��i�����l�T�j
    public float speed = 5;
    //Player2Buleet �v���n�u
    public GameObject Bullet_Z;
    public GameObject Bullet_X;
    //Z�e�۔��ˎ���
    float ShotTime_Z = 0;
    //X�e�۔��ˎ���
    float ShotTime_X = 0;
    //�e�ۂ̌o�ߎ���
    public float ElapsedTime = 0;
    //�e�ۑ��x
    public float BulletSpeed = 0;

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
        //���E�̓��͂����ɓn��
        float x = Input.GetAxisRaw("Horizontal");
        //�㉺�̓��͂����ɓn���B
        float y = Input.GetAxisRaw("Vertical");

        //�ړ�������������߂�
        //���Ƃ��̓��͒l�𐳋K�����Adirection�ɓn���B
        Vector2 direction = new Vector2(x, y).normalized;
        //Rigidbody2D�R���|�[�l���g��velocity�ɕ����ƈړ����x���|�����l��n���B
        P1.velocity = direction * speed;

        //Z�L�[���͒e�ۂ𔭎�
        Shot_Z();
        //X�L�[���͂Œe�۔���
        Shot_X();
        //Z�e�۔��ˊԊu�v��
        ShotTime_Z += Time.deltaTime;
        //X�e�۔��ˊԊu�v��
        ShotTime_X += Time.deltaTime;
    }

//--------------------------------------------------------------------------------------

    //�e�ۂ̒��g
    //�V���b�g_Z
    void Shot_Z()
    {
        //Z�L�[���������ۂ̔���
        if (Input.GetKey(KeyCode.Z))
        {
            //�o�ߎ���
            if (ShotTime_Z >= ElapsedTime)
            {
                ShotTime_Z = 0;
            }
            //�摜�\��
            if (ShotTime_Z == 0)
            {
                GameObject Circle = Instantiate(Bullet_Z);

                Circle.transform.position = this.transform.position;

            }
        }
    }

//--------------------------------------------------------------------------------------

    //�e�ۂ̒��g
    //�V���b�g_X
    void Shot_X()
    {
        //X�L�[���������ۂ̔���
        if (Input.GetKey(KeyCode.X))
        {
            //�o�ߎ���
            if (ShotTime_X >= ElapsedTime)
            {
                ShotTime_X = 0;
            }

            //�摜�\��
            if (ShotTime_X == 0)
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
                    GameObject Circle = Instantiate(Bullet_X) as GameObject;
                    //�p�x
                    Bullet_X.transform.rotation = Quaternion.Euler(Angle);
                    //�摜�̕\��
                    Bullet_X.transform.position = this.transform.position;

                }

            }
        }
    }
}
