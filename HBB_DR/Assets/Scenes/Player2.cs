using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D P2;
    //���@�̈ړ����x���i�[����ϐ��i�����l�T�j
    public float speed = 5;
    //Player2Buleet �v���n�u
    public GameObject Circle1;
    public GameObject Circle2;
    //���ԊԊu
    float Times = 0;

    public float Timed = 0;

    public float balletSpeed = 0;

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
        //���E�̓��͂����ɓn��
        float x = Input.GetAxisRaw("Horizontal");
        //�㉺�̓��͂����ɓn���B
        float y = Input.GetAxisRaw("Vertical");

        //�ړ�������������߂�
        //���Ƃ��̓��͒l�𐳋K�����Adirection�ɓn���B
        Vector2 direction = new Vector2(x, y).normalized;
        //Rigidbody2D�R���|�[�l���g��velocity�ɕ����ƈړ����x���|�����l��n���B
        P2.velocity = direction * speed;

        //Z�L�[���͂ŋʂ𔭎�
     
        Shot();

        Shot2();

        Times += Time.deltaTime;
    }

//--------------------------------------------------------------------------------------

    //�ʂ̒��g
    //�V���b�g�P
    void Shot()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (Times >= Timed)
            {
                Times = 0;
            }

            if (Times == 0)
            {
                GameObject Circle = Instantiate(Circle1);

                Circle.transform.position = this.transform.position;

            }
        }
    }

    void Shot2()
    {
        if (Input.GetKey(KeyCode.X))
        {
            if (Times >= Timed)
            {
                Times = 0;
            }

            if (Times == 0)
            {
                for (int i = 1; i <= 8; i++)
                {
                    //�ʂ̊p�x
                    float Ag = i * 45;  //�ύX����22.5

                    Vector3 Angle01 = transform.eulerAngles;
                    Angle01.x = transform.rotation.x;
                    Angle01.y = transform.rotation.y;
                    Angle01.z = Ag;


                    GameObject Circle = Instantiate(Circle2)as GameObject;

                    Circle2.transform.rotation = Quaternion.Euler(Angle01);

                    Circle2.transform.position = this.transform.position;

                    
                }

            }
        }
    }
    




}
