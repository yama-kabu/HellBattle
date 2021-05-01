using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D P2;
    //自機の移動速度を格納する変数（初期値５）
    public float speed = 5;
    //Player2プレハブ1
    public GameObject Shot_RightShift;
    //       プレハブ2
    public GameObject Shot_RightControl;
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
        //Rigidbody2D　コンポーネントを取得して変数　P2　に格納
        P2 = GetComponent<Rigidbody2D>();

    }

 //--------------------------------------------------------------------------------------

    // 繰り返す処理
    void Update()
    {

        //右shiftキー入力弾丸を発射
        Shot_Normal();
        //右ctrlキー入力で弾丸発射
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
        if (Input.GetKey(KeyCode.RightShift))
        {
            //経過時間
            if (ShotTime_Normal >= ElapsedTime)
            {
                ShotTime_Normal = 0;
            }
            //画像表示
            if (ShotTime_Normal == 0)
            {
                GameObject Circle = Instantiate(Shot_RightShift);

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
        if (Input.GetKey(KeyCode.RightControl))
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
                    GameObject Circle = Instantiate(Shot_RightControl) as GameObject;
                    //角度
                    Shot_RightControl.transform.rotation = Quaternion.Euler(Angle);
                    //画像の表示
                    Shot_RightControl.transform.position = this.transform.position;

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
        if (Input.GetKey("left"))
        {
            // 代入したPositionに対して加算減算を行う
            Position.x -= PlayerSpeed.x;
        }
        else if (Input.GetKey("right"))
        { // 右キーを押し続けていたら
          // 代入したPositionに対して加算減算を行う
            Position.x += PlayerSpeed.x;
        }
        else if (Input.GetKey("up"))
        { // 上キーを押し続けていたら
          // 代入したPositionに対して加算減算を行う
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey("down"))
        { // 下キーを押し続けていたら
          // 代入したPositionに対して加算減算を行う
            Position.y -= PlayerSpeed.y;
        }
        // 現在の位置に加算減算を行ったPositionを代入する
        transform.position = Position;
    }

//--------------------------------------------------------------------------------------


}
