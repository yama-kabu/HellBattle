//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Random_Homing : MonoBehaviour
{
    public GameObject Stage;

    //�ǂ�������Ώۂ�Transform
    GameObject enemy;
    //�e��Transform
    private Transform BulletTrans;
    public GameObject Shot01;
//--------------------------------------------------------------------------------------

    private Vector2 lastVelocity;
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Reflect;

//--------------------------------------------------------------------------------------

    //�p�x�i�����_���j
    float rnd;
    //�ŏ��̈ړ��̎���
    float Random_time = 3;
    //������ς��鎞��
    float Random_change = 0.3f;
    //�X�g�b�v�^�C��
    float Stop_time = 5;
    //���̓����Ɉړ����邽�߂̃`�F�b�N
    bool isStop_check = false;

//--------------------------------------------------------------------------------------
 
    //�z�[�~���O����
    float Homing_time = 5;


    //�z�[�~���O���J�n������check
    bool isHoming_check = false;
    //�z�[�~���O�X�s�[�h
    float Homing_Speed = 80;
    //�z�[�~���O�̂ނ���ς��鎞��
    public float Homing_stop_time = 0;
    //�ǂւ̃q�b�g����
    bool isHit_check = false;
    bool omake = false;
//--------------------------------------------------------------------------------------

    void Start()
    {
        //�����蔻��@��
        BoxCollider2D Hit_Wall = Stage.GetComponent<BoxCollider2D>();


        BulletTrans = GetComponent<Transform>();
        //���W�b�h�{�f�B���Q��
        Reflect = this.GetComponent<Rigidbody2D>();
        //�����_���Ɉړ����邽�߂̗͂�������
        Reflect.AddForce(new Vector2(Random.Range(-500f, 500f), Random.Range(-500f, 500f)));
        //�����_���ϐ���ǉ�
        rnd = Random.value * 360;
        //�e�̌����������_���ϐ��œ����l�ɕύX����
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rnd);

//--------------------------------------------------------------------------------------

        //�ǂ�������Ώۂ������Ō��߂�
        if (this.gameObject.CompareTag("Bullet_1"))
        {
            enemy = GameObject.Find("Player_R2");
        }
        else if (this.gameObject.CompareTag("Bullet_2"))
        {
            enemy = GameObject.Find("Player_R1");
        }

        //�z�[�~���O�̏����@0.7�b���ƂɎ��s
        InvokeRepeating("homing", 0.7f, 0.7f);
    }

//--------------------------------------------------------------------------------------

    void Update()
    {

        if (Random_time > 0)
        {
            Random_time -= Time.deltaTime;
            Random_change -= Time.deltaTime;
            if (Random_change < 0)
            {
                Reflect.velocity = Vector2.zero;
                Reflect.AddForce(new Vector2(Random.Range(-500f, 500f), Random.Range(-500f, 500f)));
                Random_change = 0.3f;

//--------------------------------------------------------------------------------------


            }
        }
        else
        {
            //���Ԃ�������ړ�����߁A�F��ύX���ǔ��ɍs����ύX������
            if (!isStop_check)
            {
                Reflect.velocity = Vector2.zero;
                isStop_check = true;
                GetComponent<Renderer>().material.color = Color.green;
            }
            //����̈ړ����鎞�Ԃ�݂���
            else if (Stop_time > 0)
            {
                Stop_time -= Time.deltaTime;
            }
            else 
            {
                isHoming_check = true;
                Homing_time -= Time.deltaTime;
                if(Homing_time < 0)
                {
                    isHit_check = true;
                    Destroy(this.GetComponent<CircleCollider2D>());
                }
            }
        }
    }

//--------------------------------------------------------------------------------------

    void FixedUpdate()
    {
        if (!isStop_check)
        {
            this.lastVelocity = this.Reflect.velocity;
        }
    }

//--------------------------------------------------------------------------------------

    void OnCollisionEnter2D(Collision2D Reflect)
    {
        if (Random_time > 0)
        {
            //���˂���p�x�̌v�Z
            Vector2 refrectVec = Vector2.Reflect(this.lastVelocity, Reflect.contacts[0].normal);
            this.Reflect.velocity = refrectVec;
        }
    }

//--------------------------------------------------------------------------------------

    void OnTriggerEnter2D(Collider2D BD)
    {
        if (isHoming_check)
        {
            if (BD.gameObject.tag == "Player_R1" || BD.gameObject.tag == "Player_R2")
            {

                Destroy(this.gameObject);

            }
        }
    }

//--------------------------------------------------------------------------------------

    void OnTriggerExit2D(Collider2D BD)
    {
        if (BD.gameObject.tag == "BuckStage")
        {
            if (isHit_check == true)
            {
                Destroy(this.gameObject);
                for (int i = 1; i <= 3; i++)
                {
                    float Shot_Angle = i * 120;//�ύX����22.5(�S�����ł͂Ȃ��O�����̏ꍇ)

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

    void homing()
    {
        if (isHoming_check && !isHit_check)
        {
            if (Homing_stop_time > 0)
            {
                Homing_stop_time -= Time.deltaTime;
            }
            else
            {
                //��x���x���O�ɂ���
                Reflect.velocity = Vector2.zero;
                //�e����ǂ�������Ώۂւ̕������v�Z
                Vector3 Distance = enemy.transform.position - BulletTrans.position;
                //�����̒�����1�ɐ��K���A�C�ӂ̗͂�AddForce�ŉ�����
                Reflect.AddForce(Distance.normalized * Homing_Speed * 2);
            }
        }
    }
//--------------------------------------------------------------------------------------

}
