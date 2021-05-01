using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D P1;
    //自機の移動速度を格納する変数（初期値５）
    public float speed = 5;
    //Player1プレハブ1
    public GameObject Shot_Z;
    //       プレハブ2
    public GameObject Shot_X;
    //Normal弾発射時間
    float ShotTime_Normal = 0;
    //Way弾発射時間
    float ShotTime_Way = 0;
    //弾丸の経過時間
    public float ElapsedTime = 0;
    //弾丸速度
    public float BulletSpeed = 0;

    public Vector2 PlayerSpeed = new Vector2(0.005f, 0.005f);
//--------------------------------------------------------------------------------------

    // ゲームのスタート時の処理
    void Start()
    {
        //Rigidbody2D　コンポーネントを取得して変数　P1　に格納
        P1 = GetComponent<Rigidbody2D>();

    }

//--------------------------------------------------------------------------------------

    // 繰り返す処理
    void Update()
    {

        //Zキー入力弾丸を発射
        Shot_Normal();
        //Xキー入力で弾丸発射
        Shot_Way();
        //Normal弾丸発射間隔計測
        ShotTime_Normal += Time.deltaTime;
        //Way弾丸発射間隔計測
        ShotTime_Way += Time.deltaTime;

        // 移動処理
        Move();
    }

//--------------------------------------------------------------------------------------

    //弾丸の処理
    //ショット_Normal
    void Shot_Normal()
    {
        //Zキーを押した際の判定
        if (Input.GetKey(KeyCode.Z))
        {
            //経過時間
            if (ShotTime_Normal >= ElapsedTime)
            {
                ShotTime_Normal = 0;
            }
            //画像表示
            if (ShotTime_Normal == 0)
            {
                GameObject Circle = Instantiate(Shot_Z);

                Circle.transform.position = this.transform.position;

            }
        }
    }

//--------------------------------------------------------------------------------------

    //弾丸の処理
    //ショット_Way
    void Shot_Way()
    {
        //Xキーを押した際の判定
        if (Input.GetKey(KeyCode.X))
        {
            //経過時間
            if (ShotTime_Way >= ElapsedTime)
            {
                ShotTime_Way = 0;
            }

            //画像表示
            if (ShotTime_Way == 0)
            {

                for (int i = 1; i <= 8; i++)
                {
                    //弾丸の角度
                    float ShotAngle = i * 45;  //変更時は22.5

                    Vector3 Angle = transform.eulerAngles;
                    Angle.x = transform.rotation.x;
                    Angle.y = transform.rotation.y;
                    Angle.z = ShotAngle;

                    //画像の呼び出し
                    GameObject Circle = Instantiate(Shot_X) as GameObject;
                    //角度
                    Shot_X.transform.rotation = Quaternion.Euler(Angle);
                    //画像の表示
                    Shot_X.transform.position = this.transform.position;

                }

            }
        }
    }

//--------------------------------------------------------------------------------------

    // 移動
    void Move()
    {
        // 現在位置をPositionに代入
        Vector2 Position = transform.position;
        // 左キーを押し続けていたら
        if (Input.GetKey("a"))
        {
            // 代入したPositionに対して加算減算を行う
            Position.x -= PlayerSpeed.x;
        }
        else if (Input.GetKey("d"))
        { // 右キーを押し続けていたら
          // 代入したPositionに対して加算減算を行う
            Position.x += PlayerSpeed.x;
        }
        else if (Input.GetKey("w"))
        { // 上キーを押し続けていたら
          // 代入したPositionに対して加算減算を行う
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey("s"))
        { // 下キーを押し続けていたら
          // 代入したPositionに対して加算減算を行う
            Position.y -= PlayerSpeed.y;
        }
        // 現在の位置に加算減算を行ったPositionを代入する
        transform.position = Position;
    }

//--------------------------------------------------------------------------------------


}
