//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Reflect2: MonoBehaviour
{
    private Vector2 lastVelocity;

    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D Reflect;

    //public GameObject Stage;

    //跳ね返る回数初期化
    int cnt = 0;

    public float Shot_Speed = 8;

    //スタートをplayer位置に
    public GameObject Player;
    //ターゲットを敵の位置に
    public GameObject Target;


    void Start()
    {
        Shot_Speed *= 10;

        Player = GameObject.Find("Player_L");
        Target = GameObject.Find("Temporary_Enemy");

        //ｘとｙを計算
        Vector3 Distance = Target.transform.position - Player.transform.position; 

        //当たり判定　壁
        //BoxCollider2D Hit_Wall = Stage.GetComponent<BoxCollider2D>();

        this.Reflect = this.GetComponent<Rigidbody2D>();
        
        //発射するプログラム　
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
}
