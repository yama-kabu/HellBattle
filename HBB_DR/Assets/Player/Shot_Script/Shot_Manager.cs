//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Manager : MonoBehaviour
{
    //Player_Shot �v���n�u
    //public GameObject Shot01;
    public GameObject Shot01;
    public GameObject Shot02;
    public GameObject Shot03;
    public GameObject Shot04_1;
    public GameObject Shot04_2;
    public GameObject Shot04_3;
    //public GameObject Shot05;

//--------------------------------------------------------------------------------------

    //�X�^�[�g��player�ʒu��
    private GameObject Player;
    //�^�[�Q�b�g��G�̈ʒu��
    private GameObject Target;

//--------------------------------------------------------------------------------------

    //�ˌ��̃N�[���^�C��
    public float Shot_Cooltime;//�S�̂̃N�[���^�C�������߂�
    public float homing_Cooltime;

    float Shot1_Cooltime_Count;//Shot2�p�̃N�[���^�C���J�E���^�[
    float Shot2_Cooltime_Count;//Shot3�p�̃N�[���^�C���J�E���^�[
    float Shot3_Cooltime_Count;//Shot4�p�̃N�[���^�C���J�E���^�[
    float Shot4_Cooltime_Count;//Shot5�p�̃N�[���^�C���J�E���^�[
    float Shot5_Cooltime_Count;//Shot5�p�̃N�[���^�C���J�E���^�[

    int Spiral_count = 0;
    int Barrage_count = 0;

    //�V���b�g�R�̗�
    //�N�[���^�C�������p
    float Shot_Count_Time_Save = 3;
    //���b���˂��ꂽ��
    float Spiral_Duration_time = 3;
    float Barrage_Duration_time = 3;
    //���˂��Ă��邩�ۂ�����
    bool Spiral_Duration = false;
    bool Barrage_Duration = false;

    //�N�[���^�C�������ۂ�����
    bool Spiral_Cooltime_check = false;
    bool Barrage_Cooltime_check = false;

    //�X�p�C�����̈�x�̑���ő����鎞��
    public int Spiral_Time;
    //�o���[�W�̈�n���̑���ő����鎞��
    public int Barrage_Time;

    //�V���b�g2�̑��x
    public float Shot02_Speed = 0;
    public float Shot05_Speed = 0;
//--------------------------------------------------------------------------------------

    void Start()
    {
        //�ǂ�������Ώۂ������Ō��߂�
        if (this.gameObject.CompareTag("Player_L1"))
        {
            Player = GameObject.Find("Player_L1");
            Target = GameObject.Find("Player_R2");
        }
        else if (this.gameObject.CompareTag("Player_L2"))
        {
            Player = GameObject.Find("Player_L2");
            Target = GameObject.Find("Player_R1");
        }


    }



    void Update()
    {

    }

//--------------------------------------------------------------------------------------
    //8Way

    public void Shot1()
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
                for (int i = 1; i <= 8; i++)
                {
                    //�ʂ̊p�x
                    float Shot_Angle = i * 45;//�ύX����22.5(�S�����ł͂Ȃ��O�����̏ꍇ)

                    Vector3 Angle = transform.eulerAngles;
                    Angle.x = transform.rotation.x;
                    Angle.y = transform.rotation.y;
                    Angle.z = Shot_Angle;

                    GameObject Shot2 = Instantiate(Shot01) as GameObject;
                    Shot2.transform.rotation = Quaternion.Euler(Angle);
                    Shot2.transform.position = this.transform.position;
                }
            }
        }
    }

    //--------------------------------------------------------------------------------------
    //Spiral

    public void Shot2()
    {

        if (Input.GetKey(KeyCode.X))
        {
            if (Spiral_Cooltime_check == false && Spiral_Duration == false)
            {
                Spiral_Duration = true;
            }
        }
        if (Spiral_Cooltime_check == false && Spiral_Duration == true)
        {
            Spiral_count++;
            //���T�O�̔{���ŏグ�Ă����Əo�鋅�̗ʂ��ς��
            if (Spiral_count % 100 == 0)
            {
                //�������̐�����ς���ƈ�x�ɏo���e�̐���ς�����
                for (int i = 0; i < 1; i++)
                {

                    Vector2 Vec = new Vector2(0.0f, 1.0f);
                    Vec = Quaternion.Euler(0, 0, 5f * Spiral_count) * Vec;
                    Vec.Normalize();                                    //���(0,0,Xf)�Ɖ���(360/X)��X�͍��킹��悤��
                    Vec = Quaternion.Euler(0, 0, (360 / 5) * i) * Vec;
                    Vec *= Shot02_Speed;

                    //���
                    var a = Quaternion.Euler(0, 0, -Mathf.Atan2(Vec.x, Vec.y) * Mathf.Rad2Deg);
                    var b = Instantiate(Shot02, transform.position, a);
                    b.GetComponent<Rigidbody2D>().velocity = Vec;

                    //���
                    var c = Quaternion.Euler(0, 0, -Mathf.Atan2(Vec.x, Vec.y) * Mathf.Rad2Deg + 120);
                    var d = Instantiate(Shot02, transform.position, c);
                    d.GetComponent<Rigidbody2D>().velocity = Vec;
                    //�R��
                    var e = Quaternion.Euler(0, 0, -Mathf.Atan2(Vec.x, Vec.y) * Mathf.Rad2Deg + 240);
                    var f = Instantiate(Shot02, transform.position, e);
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
                Spiral_Duration_time = Spiral_Time;
            }
        }
        else if (Spiral_Cooltime_check == true && Spiral_Duration == false)
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
    //homing

    public void Shot3()
    {
        Shot3_Cooltime_Count += Time.deltaTime;
        if (Input.GetKey(KeyCode.C))
        {
            if (Shot3_Cooltime_Count >= homing_Cooltime)
            {
                Shot3_Cooltime_Count = 0;
            }

            if (Shot3_Cooltime_Count == 0)
            {
                GameObject Shot = Instantiate(Shot03);

                Shot.transform.position = this.transform.position;
            }
        }
    }


//--------------------------------------------------------------------------------------
    //Reflect

    public void Shot4()
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


                GameObject Reflect1 = Instantiate(Shot04_1);//�܂������G�ɔ��ł�
                Reflect1.transform.position = this.transform.position;


                GameObject Reflect2 = Instantiate(Shot04_2);//-45�x��O�ɔ��ł�
                Reflect2.transform.position = this.transform.position;


                GameObject Reflect3 = Instantiate(Shot04_3);//+45�x���ɔ��ł�
                Reflect3.transform.position = this.transform.position;

            }
        }
    }

    //--------------------------------------------------------------------------------------
    //
    public void Shot5()
    {
        /*
        if (Input.GetKey(KeyCode.B))
        {
            if (Barrage_Cooltime_check == false && Barrage_Duration == false)
            {
                Barrage_Duration = true;
            }
        }
        if (Barrage_Cooltime_check == false && Barrage_Duration == true)
        {
            Barrage_count++;
                              //�����̐�����������ƁA���ł����e�̗ʂ𒲐����邱�Ƃ��ł���
        */
    }
        
//--------------------------------------------------------------------------------------


}
