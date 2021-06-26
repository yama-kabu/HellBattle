using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Explosion : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Explosion;
    //stage�̐^�񒆎Q��
    public GameObject Target;
    //�e��Transform
    public Transform BulletTrans;
    //�^�[�Q�b�g��G�̈ʒu��
    private GameObject Enemy;
    //��������e����
    public GameObject Shot1;

//--------------------------------------------------------------------------------------

    //�O�Ȃ�ړ����A�P�Ȃ甚�����A�Q�Ȃ甚���I��
    int check = 0;

    public int sakuretu = 60;

    public float Shot_Speed = 1000;
    public float Shot_Ex = 200;
    int time_count = 0;
//--------------------------------------------------------------------------------------

    void Start()
    {

        //�����̈ʒu�𒲂ׂ��
        if (this.gameObject.CompareTag("Bullet_1"))
        {
            Target = GameObject.Find("Explosion_TargetP1");
            Enemy = GameObject.Find("Player_R2");
        }
        else if (this.gameObject.CompareTag("Bullet_2"))
        {
            Target = GameObject.Find("Explosion_TargetP2");
            Enemy = GameObject.Find("Player_R1");
        }

        BulletTrans = GetComponent<Transform>();
        //���W�b�h�{�f�B���Q��
        Explosion = this.GetComponent<Rigidbody2D>();
        //�e����ǂ�������Ώۂւ̕������v�Z
        Vector3 vector3 = Target.transform.position - BulletTrans.position;
        //�����̒�����1�ɐ��K���A�C�ӂ̗͂�AddForce�ŉ�����
        Explosion.AddForce(vector3.normalized * Shot_Speed, (ForceMode2D)ForceMode.Impulse);
    }

//--------------------------------------------------------------------------------------

    void Update()
    {
        if (check < 4)
        {
            if (time_count % 100 == 0)
                if (check == 3)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Exp(i);
                    }
                    check++;
                    Destroy(this.gameObject);
                }
                else if (check == 2)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Exp(i);
                    }
                    check++;
                }
                else if (check == 1)
                {
                    for (int i = 0; i < 30; i++)
                    {
                        Exp(i);
                    }
                    check++;
                }
            time_count++;
        }
    }
    void Exp(int i)
    {
        Vector2 vec = Enemy.transform.position - BulletTrans.position;
        vec.Normalize();
        if (check == 1)
        {
            vec = Quaternion.Euler(0, 0, (360 / 10) * i) * vec;
        }
        else if (check == 2)
        {
            vec = Quaternion.Euler(0, 0, (360 / 20) * i) * vec;
        }
        if (check == 3)
        {
            vec = Quaternion.Euler(0, 0, (360 / 10) * i) * vec;
        }
        vec *= Shot_Ex;
        var q = Quaternion.Euler(0, 0, -Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg);
        var t = Instantiate(Shot1, transform.position, q);
        t.GetComponent<Rigidbody2D>().velocity = vec;

    }

//--------------------------------------------------------------------------------------

    void OnTriggerEnter2D(Collider2D BD)
    {
        if (check == 0)
        {
            if (BD.gameObject.name == "Explosion_TargetP1" || BD.gameObject.name == "Explosion_TargetP2")
            {
                Explosion.velocity = Vector3.zero;

                check = 1;
            }
        }  
    }
}
