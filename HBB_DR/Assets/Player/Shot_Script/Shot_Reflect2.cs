//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Reflect2: MonoBehaviour
{
    private Vector2 lastVelocity;

    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Reflect;

    //public GameObject Stage;

    //���˕Ԃ�񐔏�����
    int cnt = 0;

    public float Shot_Speed = 8;

    //�X�^�[�g��player�ʒu��
    public GameObject Player;
    //�^�[�Q�b�g��G�̈ʒu��
    public GameObject Target;


    void Start()
    {
        Shot_Speed *= 10;

        Player = GameObject.Find("Player_L");
        Target = GameObject.Find("Temporary_Enemy");

        //���Ƃ����v�Z
        Vector3 Distance = Target.transform.position - Player.transform.position; 

        //�����蔻��@��
        //BoxCollider2D Hit_Wall = Stage.GetComponent<BoxCollider2D>();

        this.Reflect = this.GetComponent<Rigidbody2D>();
        
        //���˂���v���O�����@
          Reflect.AddForce(new Vector2(Distance.x* Shot_Speed, Distance.y* Shot_Speed));
    }

    void FixedUpdate()
    {
        this.lastVelocity = this.Reflect.velocity;
    }

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
}
