//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager_L : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Player_L;
    //���@�̈ړ����x���i�[����ϐ��i�����l�T�j
    public float Speed = 5;
    //Player_Shot �v���n�u
    public GameObject Shot01;
    public GameObject Shot02;
    public GameObject Shot03;
    public GameObject Shot04;

    int count = 0;

    //�ˌ��̃N�[���^�C��
    public float Shot_Cooltime;//�S�̂̃N�[���^�C�������߂�
    float Shot1_Cooltime_Count;//Shot1�p�̃N�[���^�C���J�E���^�[
    float Shot2_Cooltime_Count;//Shot2�p�̃N�[���^�C���J�E���^�[
    float Shot3_Cooltime_Count;//Shot3�p�̃N�[���^�C���J�E���^�[
    float Shot4_Cooltime_Count;//Shot4�p�̃N�[���^�C���J�E���^�[

    float Velocity_0, theta;



    //�V���b�g�R�̃N�[���^�C���Ǝ������˂ɂ��񂷂���
    //float Shot3_Count_Time = 3;
    float Shot_Count_Time_Save = 3;
    bool Spiral_Duration = false;
    float Spiral_Duration_time;
    bool Spiral_Cooltime_check = false;

    //�V���b�g1�̑��x
    public float Shot01_Speed = 0;
    //�V���b�g2�̑��x
    public float Shot02_Speed = 0;
    //�V���b�g3�̑��x
    public float Shot03_Speed = 0;
    //�V���b�g4�̑��x
    public float Shot04_Speed = 0;


    //�v���C���[���x
    public Vector2 PlayerSpeed = new Vector2(0.005f, 0.005f);

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
        Move();
        Shot1();
        Shot2();
        Shot3();
        Shot4();
    }

//--------------------------------------------------------------------------------------

    //Normal
    void Shot1()
    {
        Shot1_Cooltime_Count += Time.deltaTime;
        if (Input.GetKey(KeyCode.Z))
        {
            if (Shot1_Cooltime_Count >= Shot_Cooltime)
            {
                Shot1_Cooltime_Count = 0;
            }

            if (Shot1_Cooltime_Count == 0)
            {
                GameObject Shot = Instantiate(Shot01);

                Shot.transform.position = this.transform.position;
            }
        }
    }

//--------------------------------------------------------------------------------------

    //8Way
    void Shot2()
    {
        Shot2_Cooltime_Count += Time.deltaTime;
        if (Input.GetKey(KeyCode.X))
        {
            if (Shot2_Cooltime_Count >= Shot_Cooltime)
            {
                Shot2_Cooltime_Count = 0;
            }

            if (Shot2_Cooltime_Count == 0)
            {
                for (int i = 1; i <= 8; i++)
                {
                    //�ʂ̊p�x
                    float Shot_Angle = i * 45;//�ύX����22.5(�S�����ł͂Ȃ��O�����̏ꍇ)

                    Vector3 Angle = transform.eulerAngles;
                    Angle.x = transform.rotation.x;
                    Angle.y = transform.rotation.y;
                    Angle.z = Shot_Angle;
                    
                    GameObject Shot2 = Instantiate(Shot02) as GameObject;
                    Shot2.transform.rotation = Quaternion.Euler(Angle);
                    Shot2.transform.position = this.transform.position;
                }
            }
        }
    }

//--------------------------------------------------------------------------------------

    //Spiral
    void Shot3()
    {

            if (Input.GetKey(KeyCode.C))
            {
                if (Spiral_Cooltime_check == false && Spiral_Duration == false)
                {
                    Spiral_Duration = true;
                }
            }
        if (Spiral_Cooltime_check == false && Spiral_Duration == true)
        {
            count++;
            if (count % 50 == 0)
            {
                //�������̐�����ς���ƈ�x�ɏo���e�̐���ς�����
                for (int i = 0; i < 1; i++)
                {
                    Vector2 Vec = new Vector2(0.0f, 1.0f);
                    Vec = Quaternion.Euler(0, 0, 5f * count) * Vec;
                    Vec.Normalize();                                    //���(0,0,Xf)�Ɖ���(360/X)��X�͍��킹��悤��
                    Vec = Quaternion.Euler(0, 0, (360 / 5) * i) * Vec;
                    Vec *= Shot03_Speed;
                    //���
                    var a = Quaternion.Euler(0, 0, -Mathf.Atan2(Vec.x, Vec.y) * Mathf.Rad2Deg);
                    var b = Instantiate(Shot03, transform.position, a);
                    b.GetComponent<Rigidbody2D>().velocity = Vec;

                    //���
                    var c = Quaternion.Euler(0, 0, -Mathf.Atan2(Vec.x, Vec.y) * Mathf.Rad2Deg + 120);
                    var d = Instantiate(Shot03, transform.position, c);
                    d.GetComponent<Rigidbody2D>().velocity = Vec;
                    //�R��
                    var e = Quaternion.Euler(0, 0, -Mathf.Atan2(Vec.x, Vec.y) * Mathf.Rad2Deg + 240);
                    var f = Instantiate(Shot03, transform.position, e);
                    f.GetComponent<Rigidbody2D>().velocity = Vec;
                }


            }
        }
        if (Spiral_Duration == true && Spiral_Cooltime_check == false)
        {
            Spiral_Duration_time -= Time.deltaTime;
            if (Spiral_Duration_time <= 0)
            {
                Spiral_Duration = false;
                Spiral_Cooltime_check = true;
                Spiral_Duration_time = 3;
            }
        }
        if (Spiral_Cooltime_check == true && Spiral_Cooltime_check == true)
        {
            Shot_Count_Time_Save -= Time.deltaTime;
            if (Shot_Count_Time_Save <= 0)
            {
                Spiral_Cooltime_check = false;
                Shot_Count_Time_Save = 3;
            }
        }


            

    }
//--------------------------------------------------------------------------------------

    void Shot4()
    {
        Shot4_Cooltime_Count += Time.deltaTime;
        if (Input.GetKey(KeyCode.V))
        {
            if (Shot4_Cooltime_Count >= Shot_Cooltime)
            {
                Shot4_Cooltime_Count = 0;
            }

            if (Shot4_Cooltime_Count == 0)
            {
                GameObject Shot = Instantiate(Shot04);

                Shot.transform.position = this.transform.position;
            }
        }
    }

//--------------------------------------------------------------------------------------
    //�ړ�
    void Move()
    {
        // ���݈ʒu��Position�ɑ��
        Vector2 Position = transform.position;
        //�΂߈ړ�
        if(Input.GetKey("a") & Input.GetKey("w"))
        {
            //��������������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x -= PlayerSpeed.x;
            Position.y += PlayerSpeed.y;
        }
        else if(Input.GetKey("a") & Input.GetKey("s"))
        {
            //���������������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x -= PlayerSpeed.x;
            Position.y -= PlayerSpeed.y;
        }
        else if (Input.GetKey("d") & Input.GetKey("w"))
        {
            //��������������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x += PlayerSpeed.x;
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey("d") & Input.GetKey("s"))
        {
            //���������������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x += PlayerSpeed.x;
            Position.y -= PlayerSpeed.y;
        }

        //�㉺���E�ړ�
        else if (Input.GetKey("a"))
        {
            // ���L�[�����������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x -= PlayerSpeed.x;
        }
        else if (Input.GetKey("d"))
        { 
            // �E�L�[�����������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x += PlayerSpeed.x;
        }
        else if (Input.GetKey("w"))
        { 
            // ��L�[�����������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey("s"))
        { 
            // ���L�[�����������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y -= PlayerSpeed.y;
        }
        // ���݂̈ʒu�ɉ��Z���Z���s����Position��������
        transform.position = Position;
    }
    






}
