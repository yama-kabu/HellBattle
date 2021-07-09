//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Reflect : Shot_Common
{
//--------------------------------------------------------------------------------------
//�Q�ƌn 
    
    private Rigidbody2D rb; //�e��Rigidbody2D���i�[����ϐ�����
    public  GameObject Player;  //�G�Ƃ̋����𑪂鎞�Ɏg���v���C���[�̈ʒu���i�[����ϐ�����

//--------------------------------------------------------------------------------------
//�ϐ��n

    int cnt = 0;    //���˕Ԃ�񐔂���

    private Vector2 lastVelocity;   //�ŏI�ʒu����

//--------------------------------------------------------------------------------------
//�ŏ��̏���

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();     //�e�ɂ��Ă���Rigidbody2D�������
        rb.AddForce(gameObject.transform.rotation * new Vector3(0, bullet_Speed * 50, 0));
    }

//--------------------------------------------------------------------------------------

    void FixedUpdate()
    {
        this.lastVelocity = this.rb.velocity;   //���݂̈ʒu���Ō�ɂ����ʒu�ɕύX�����
    }

//--------------------------------------------------------------------------------------

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (cnt <= 4)
        {
            Vector2 refrectVec = Vector2.Reflect(this.lastVelocity, collision.contacts[0].normal);  //���˂���p�x�̌v�Z����
            this.rb.velocity = refrectVec;
            if (cnt == 3)
            {
                Destroy(this.GetComponent<CircleCollider2D>());
                Destroy(this.gameObject);
            }
            cnt++;
        }
    }

//--------------------------------------------------------------------------------------

}
