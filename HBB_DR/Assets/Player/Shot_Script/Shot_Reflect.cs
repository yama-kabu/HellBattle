//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Reflect: MonoBehaviour
{
    private Vector2 lastVelocity;

    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Reflect;

    //public GameObject Stage;

    //���˕Ԃ�񐔏�����
    int cnt = 0;

    //�X�^�[�g��player�ʒu��
    [SerializeField]
    public GameObject Player;
    //�^�[�Q�b�g��G�̈ʒu��
    [SerializeField]
    public GameObject Target;


    void Start()
    {
        float Angle = GetAngle(Player.transform.position, Target.transform.position);
        Debug.Log(Angle);





        //�����蔻��@��
        //BoxCollider2D Hit_Wall = Stage.GetComponent<BoxCollider2D>();

        this.Reflect = this.GetComponent<Rigidbody2D>();
        //Reflect.AddForce(new Vector2(300,500));
          Reflect.AddForce(new Vector2(Angle,Angle));
    }

    void FixedUpdate()
    {
        this.lastVelocity = this.Reflect.velocity;
    }

    void OnCollisionEnter2D(Collision2D Reflect)
    {

        if (cnt <= 4)
        {
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




    float GetAngle(Vector2 Player,Vector2 Target)
    {
        Vector2 Distance = Target - Player;
        float rad = Mathf.Atan2(Distance.y, Distance.x);
        float degree = rad * Mathf.Rad2Deg;
        return degree;
    }


}
