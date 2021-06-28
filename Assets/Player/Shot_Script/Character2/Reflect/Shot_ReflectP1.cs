//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_ReflectP1 : MonoBehaviour
{
    public float damage;
    private Vector2 lastVelocity;
    Vector3 Distance;
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Reflect;


    //���˕Ԃ�񐔏�����
    int cnt = 0;
    //���x���ψ�ɂ���
    float tyousei = 0.01f;
    public float Shot_Speed = 1000;

    //�X�^�[�g��player�ʒu��
    public GameObject Player;
    //�^�[�Q�b�g��G�̈ʒu��
    public GameObject Target;

//--------------------------------------------------------------------------------------

    void Start()
    {
        Shot_Speed *= 10;


        Player = GameObject.Find("Player_L1");
        Target = GameObject.Find("Hit_Body_P2");

        if (Target != null)
        {
            //���Ƃ����v�Z
            Distance = Target.transform.position - Player.transform.position;
        }
        else if (Target == null)
        {
            //���Ƃ����v�Z
        }

            this.Reflect = this.GetComponent<Rigidbody2D>();

        if (this.gameObject.CompareTag("Bullet_1"))
        {
            //���˂���v���O�����@
            Reflect.AddForce(new Vector2(Distance.x * (Shot_Speed * tyousei), Distance.y * (Shot_Speed * tyousei)));
        }
        else if (this.gameObject.CompareTag("Bullet_2"))
        {

            //���˂���v���O�����@
            Reflect.AddForce(new Vector2((Distance.x * (Shot_Speed * tyousei) + 35000), (Distance.y * (Shot_Speed * tyousei))));

        }
        else if (this.gameObject.CompareTag("Bullet_3"))
        {
            //���˂���v���O�����@
            Reflect.AddForce(new Vector2((Distance.x * (Shot_Speed * tyousei) - 35000), (Distance.y * (Shot_Speed * tyousei))));
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

        if (BD.gameObject.tag == "Hit_Body_P1" || BD.gameObject.tag == "Hit_Body_P2")
        {
            //Player_Manager_R�̒���������
            if (BD.gameObject.GetComponent<Player_Manager_R>())
            {
                //�_���[�W�ϐ��ɒe�������Ă���_���[�W����
                BD.gameObject.GetComponent<Player_Manager_R>().Damage(damage);
            }
            Destroy(this.gameObject);
        }
        if (BD.gameObject.tag == "Barrier")
        {
            Destroy(this.gameObject);
        }
        if (BD.gameObject.tag == "Absorption")
        {
            Destroy(this.gameObject);
        }
    }

//--------------------------------------------------------------------------------------

}

