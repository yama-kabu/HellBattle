//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_ReflectP2: MonoBehaviour
{
    private Vector2 lastVelocity;

    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Reflect;

    //public GameObject Stage;

    //���˕Ԃ�񐔏�����
    int cnt = 0;

    public float Shot_Speed = 5;

    //�X�^�[�g��player�ʒu��
    public GameObject Player;
    //�^�[�Q�b�g��G�̈ʒu��
    public GameObject Target;

//--------------------------------------------------------------------------------------

    void Start()
    {
        Shot_Speed *= 10;


        Player = GameObject.Find("Player_L2");
        Target = GameObject.Find("Player_R1");

        //���Ƃ����v�Z
        Vector3 Distance = Target.transform.position - Player.transform.position; 

        this.Reflect = this.GetComponent<Rigidbody2D>();

        if (this.gameObject.CompareTag("Bullet_1"))
        {
            //���˂���v���O�����@
            Reflect.AddForce(new Vector2(Distance.x * Shot_Speed, Distance.y * Shot_Speed));
        }
        else if (this.gameObject.CompareTag("Bullet_2"))
        {
            if (180 > Distance.x && Distance.x > 45 || 315 > Distance.x && Distance.x > 225)
            {
                //���˂���v���O�����@
                Reflect.AddForce(new Vector2((Distance.x * Shot_Speed), (Distance.y * Shot_Speed) + 45));
            }
            else
            {
                //���˂���v���O�����@
                Reflect.AddForce(new Vector2((Distance.x * Shot_Speed) + 45, (Distance.y * Shot_Speed)));
            }
        }
        else if (this.gameObject.CompareTag("Bullet_3"))
        {
            this.Reflect = this.GetComponent<Rigidbody2D>();
            if ((180 > Distance.x) && (Distance.x > 45) || (315 > Distance.x) && (Distance.x > 225))
            {
                //���˂���v���O�����@
                Reflect.AddForce(new Vector2((Distance.x * Shot_Speed), (Distance.y * Shot_Speed) - 45));
            }
            else
            {
                //���˂���v���O�����@
                Reflect.AddForce(new Vector2((Distance.x * Shot_Speed) - 45, (Distance.y * Shot_Speed)));
            }
        }
    }

//--------------------------------------------------------------------------------------

    void FixedUpdate()
    {
        this.lastVelocity = this.Reflect.velocity;
    }

//--------------------------------------------------------------------------------------

    void OnCollisionEnter2D(Collision2D Reflect)
    {

        if (cnt <= 4)
        {
            //���˂���p�x�̌v�Z
            Vector2 refrectVec = Vector2.Reflect(this.lastVelocity, Reflect.contacts[0].normal);
            this.Reflect.velocity = refrectVec;
            if (cnt == 3)
            {
                Destroy(this.GetComponent<CircleCollider2D>());
                Destroy(this.gameObject);
            }
            cnt++;
        }
    }

    //--------------------------------------------------------------------------------------

    void OnTriggerEnter2D(Collider2D BD)
    {

        if (BD.gameObject.tag == "Player_R1" || BD.gameObject.tag == "Player_R2")
        {

            Destroy(this.gameObject);
        }

    }

    //--------------------------------------------------------------------------------------

}

