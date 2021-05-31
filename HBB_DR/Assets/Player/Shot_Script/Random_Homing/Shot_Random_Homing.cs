//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Random_Homing : MonoBehaviour
{
    public GameObject Stage;

    //追いかける対象のTransform
    GameObject enemy;
    //弾のTransform
    private Transform BulletTrans;
    public GameObject Shot01;
//--------------------------------------------------------------------------------------

    private Vector2 lastVelocity;
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D Reflect;

//--------------------------------------------------------------------------------------

    //角度（ランダム）
    float rnd;
    //最初の移動の時間
    float Random_time = 3;
    //方向を変える時間
    float Random_change = 0.3f;
    //ストップタイム
    float Stop_time = 5;
    //次の動きに移動するためのチェック
    bool isStop_check = false;

//--------------------------------------------------------------------------------------
 
    //ホーミング時間
    float Homing_time = 5;


    //ホーミングを開始したかcheck
    bool isHoming_check = false;
    //ホーミングスピード
    float Homing_Speed = 80;
    //ホーミングのむきを変える時間
    public float Homing_stop_time = 0;
    //壁へのヒット判定
    bool isHit_check = false;
    bool omake = false;
//--------------------------------------------------------------------------------------

    void Start()
    {
        //当たり判定　壁
        BoxCollider2D Hit_Wall = Stage.GetComponent<BoxCollider2D>();


        BulletTrans = GetComponent<Transform>();
        //リジッドボディを参照
        Reflect = this.GetComponent<Rigidbody2D>();
        //ランダムに移動するための力を加える
        Reflect.AddForce(new Vector2(Random.Range(-500f, 500f), Random.Range(-500f, 500f)));
        //ランダム変数を追加
        rnd = Random.value * 360;
        //弾の向きをランダム変数で得た値に変更する
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rnd);

//--------------------------------------------------------------------------------------

        //追いかける対象をここで決める
        if (this.gameObject.CompareTag("Bullet_1"))
        {
            enemy = GameObject.Find("Player_R2");
        }
        else if (this.gameObject.CompareTag("Bullet_2"))
        {
            enemy = GameObject.Find("Player_R1");
        }

        //ホーミングの処理　0.7秒ごとに実行
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
            //時間が来たら移動をやめ、色を変更→追尾に行動を変更させる
            if (!isStop_check)
            {
                Reflect.velocity = Vector2.zero;
                isStop_check = true;
                GetComponent<Renderer>().material.color = Color.green;
            }
            //相手の移動する時間を設ける
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
            //反射する角度の計算
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
                    float Shot_Angle = i * 120;//変更時は22.5(全方向ではなく前だけの場合)

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
                //一度速度を０にする
                Reflect.velocity = Vector2.zero;
                //弾から追いかける対象への方向を計算
                Vector3 Distance = enemy.transform.position - BulletTrans.position;
                //方向の長さを1に正規化、任意の力をAddForceで加える
                Reflect.AddForce(Distance.normalized * Homing_Speed * 2);
            }
        }
    }
//--------------------------------------------------------------------------------------

}
