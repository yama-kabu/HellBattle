//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_ReflectP1 : MonoBehaviour
{
    public float damage;
    private Vector2 lastVelocity;
    Vector3 Distance;
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D Reflect;


    //跳ね返る回数初期化
    int cnt = 0;
    //速度を均一にする
    float tyousei = 0.01f;
    public float Shot_Speed = 1000;

    //スタートをplayer位置に
    public GameObject Player;
    //ターゲットを敵の位置に
    public GameObject Target;

//--------------------------------------------------------------------------------------

    void Start()
    {
        Shot_Speed *= 10;


        Player = GameObject.Find("Player_L1");
        Target = GameObject.Find("Hit_Body_P2");

        if (Target != null)
        {
            //ｘとｙを計算
            Distance = Target.transform.position - Player.transform.position;
        }
        else if (Target == null)
        {
            //ｘとｙを計算
        }

            this.Reflect = this.GetComponent<Rigidbody2D>();

        if (this.gameObject.CompareTag("Bullet_1"))
        {
            //発射するプログラム　
            Reflect.AddForce(new Vector2(Distance.x * (Shot_Speed * tyousei), Distance.y * (Shot_Speed * tyousei)));
        }
        else if (this.gameObject.CompareTag("Bullet_2"))
        {

            //発射するプログラム　
            Reflect.AddForce(new Vector2((Distance.x * (Shot_Speed * tyousei) + 35000), (Distance.y * (Shot_Speed * tyousei))));

        }
        else if (this.gameObject.CompareTag("Bullet_3"))
        {
            //発射するプログラム　
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
            //反射する角度の計算
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
            //Player_Manager_Rの中をさがす
            if (BD.gameObject.GetComponent<Player_Manager_R>())
            {
                //ダメージ変数に弾が持っているダメージを代入
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

