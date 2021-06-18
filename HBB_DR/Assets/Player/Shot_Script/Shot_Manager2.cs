//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Manager2 : MonoBehaviour
{

    //Player_Shot �v���n�u
    //public GameObject Shot01;
    public GameObject Shot01;
    public GameObject Shot02;
    public GameObject Shot03;
    public GameObject Shot04_1;
    public GameObject Shot04_2;
    public GameObject Shot04_3;
    public GameObject Shot05;
    public GameObject Shot06;

//--------------------------------------------------------------------------------------

    //�X�^�[�g��player�ʒu��
    private GameObject Player;
    //�^�[�Q�b�g��G�̈ʒu��
    private GameObject Target;

//--------------------------------------------------------------------------------------

    //�ˌ��̃N�[���^�C��
    float Shot_Cooltime = 3;//�S�̂̃N�[���^�C�������߂�
    float homing_Cooltime = 10;//�z�[�~���O�̃N�[���^�C����
    float Random_homing_Cooltime = 15;//�����_���z�[�~���O�̃N�[���^�C����

    float Shot1_Cooltime_Count = 100;//Shot1�p�̃N�[���^�C���J�E���^�[
    //float Shot2_Cooltime_Count;//Shot2�p�̃N�[���^�C���J�E���^�[
    float Shot3_Cooltime_Count = 100;//Shot3�p�̃N�[���^�C���J�E���^�[
    float Shot4_Cooltime_Count = 100;//Shot4�p�̃N�[���^�C���J�E���^�[
    //float Shot5_Cooltime_Count;//Shot5�p�̃N�[���^�C���J�E���^�[
    float Shot6_Cooltime_Count = 100;//Shot6�p�̃N�[���^�C���J�E���^�[

    int Spiral_count = 0;
    int Barrage_count = 0;

    //�V���b�g2�̗�
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
    int Spiral_Time = 3;
    //�o���[�W�̈�x�̑���ő����鎞��
    int Barrage_Time = 3;

    //�V���b�g2�̑��x
    //�P�O�O�O�ɂ���Ɩʔ����Ȃ�
    float Shot02_mawaru_Speed = 1f;
    //�V���b�g5�̑��x
    float Shot05_Speed = 1f;

    public float Spiral_kaiten;
    public float Barrage_ryou;
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

//--------------------------------------------------------------------------------------
//8Way

    public void Shot1()
    {
        if (Shot1_Cooltime_Count < Shot_Cooltime)
        {
            Shot1_Cooltime_Count += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Z))
        {

            if (Shot1_Cooltime_Count > Shot_Cooltime)
            {
                for (int i = 1; i <= 8; i++)
                {
                    //�ʂ̊p�x
                    float Shot_Angle = i * 45;//�ύX����22.5(�S�����ł͂Ȃ��O�����̏ꍇ)

                    Vector3 Angle = transform.eulerAngles;
                    Angle.x = transform.rotation.x;
                    Angle.y = transform.rotation.y;
                    Angle.z = Shot_Angle;

                    GameObject Shot1 = Instantiate(Shot01) as GameObject;
                    Shot1.transform.rotation = Quaternion.Euler(Angle);
                    Shot1.transform.position = this.transform.position;
                }
                //�N�[���^�C��������
                Shot1_Cooltime_Count = 0;
            }

        }
    }

//--------------------------------------------------------------------------------------
//Spiral

    public void Shot2()
    {

        if (Input.GetKey(KeyCode.Z) || Input.GetButtonDown("Button_A2"))
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
            if (Spiral_count % Spiral_kaiten == 0)
            {
                //�������̐�����ς���ƈ�x�ɏo���e�̐���ς�����
                for (int i = 0; i < 1; i++)
                {

                    Vector2 Vec = new Vector2(0.0f, 10f);
                    Vec = Quaternion.Euler(0, 0, 50f * Spiral_count) * Vec;
                    Vec.Normalize();                                    //���(0,0,Xf)�Ɖ���(360/X)��X�͍��킹��悤��
                    Vec = Quaternion.Euler(0, 0, (360 / 5) * i) * Vec;
                    Vec *= Shot02_mawaru_Speed;

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
        if (Shot3_Cooltime_Count < homing_Cooltime)
        {
            Shot3_Cooltime_Count += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.X) || Input.GetButtonDown("Button_B2"))
        {
            if ((Shot3_Cooltime_Count > homing_Cooltime))
            {
                GameObject Shot = Instantiate(Shot03);

                Shot.transform.position = this.transform.position;

                //�N�[���^�C��������
                Shot3_Cooltime_Count = 0;
            }

        }
    }

//--------------------------------------------------------------------------------------
//Reflect

    public void Shot4()
    {
        Shot4_Cooltime_Count += Time.deltaTime;
        if (Input.GetKey(KeyCode.X) || Input.GetButtonDown("Button_B2"))
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
//Barrage

    public void Shot5()
    {
        if (Input.GetKey(KeyCode.B) || Input.GetButtonDown("Button_A2"))
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
            if (Barrage_count % Barrage_ryou == 0)
            {

                Vector3 Distance = Target.transform.position - Player.transform.position;


                Vector2 vec = new Vector2(0.0f, 1.0f);
                vec = Quaternion.Euler(0, 0, Random.Range(-35f, 35f)) * vec;
                vec *= Shot05_Speed;
                //var q = Quaternion.Euler(0, 0, -Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg);
                var q = Quaternion.Euler(0, 0, -Mathf.Atan2(Distance.x + Random.Range(-400f, 400f), Distance.y + Random.Range(-40f, 40f)) * Mathf.Rad2Deg);
                var t = Instantiate(Shot05, transform.position, q);
                t.GetComponent<Rigidbody2D>().velocity = vec;

            }
        }

        if (Barrage_Duration == true && Barrage_Cooltime_check == false)
        {
            Barrage_Duration_time -= Time.deltaTime;
            if (Barrage_Duration_time <= 0)
            {
                Barrage_Duration = false;
                Barrage_Cooltime_check = true;
                Barrage_Duration_time = Barrage_Time;
            }
        }
        else if (Barrage_Cooltime_check == true && Barrage_Duration == false)
        {
            Shot_Count_Time_Save -= Time.deltaTime;
            if (Shot_Count_Time_Save <= 0)
            {
                Barrage_Cooltime_check = false;
                Shot_Count_Time_Save = 3;
                Barrage_count = 0;
            }
        }
    }

//--------------------------------------------------------------------------------------
//Random_Homing

    public void Shot6()
    {
        Shot6_Cooltime_Count += Time.deltaTime;
        if (Input.GetKey(KeyCode.V) || Input.GetButtonDown("Button_Y2"))
        {
            if (Shot6_Cooltime_Count > Random_homing_Cooltime)
            {
                Shot6_Cooltime_Count = 0;
            }
            if (Shot6_Cooltime_Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject Shot = Instantiate(Shot06);
                    Shot.transform.position = this.transform.position;
                }
            }
        }
    }
}