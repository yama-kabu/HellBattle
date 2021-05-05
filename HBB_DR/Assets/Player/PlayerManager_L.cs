using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager_L : MonoBehaviour
{
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D P2;
    //自機の移動速度を格納する変数（初期値５）
    public float speed = 5;
    //Player2Buleet プレハブ
    public GameObject Bullet1;
    public GameObject Bullet2;

    //射撃のクールタイム
    public float ShotCoolTime;//全体のクールタイムを決める
    float Shot1cool;//Shot1用のクールタイムカウンター
    float Shot2cool;//Shot2用のクールタイムカウンター
    
    //弾の速度
    public float balletSpeed = 0;

    //プレイヤー速度
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
        Move();
        Shot();
        Shot2();
    }

//--------------------------------------------------------------------------------------

    //玉の中身
    //ショット１
    void Shot()
    {
        Shot1cool += Time.deltaTime;
        if (Input.GetKey(KeyCode.Z))
        {
            if (Shot1cool >= ShotCoolTime)
            {
                Shot1cool = 0;
            }

            if (Shot1cool == 0)
            {
                GameObject Shot = Instantiate(Bullet1);

                Shot.transform.position = this.transform.position;
            }
        }
    }

    //--------------------------------------------------------------------------------------

    void Shot2()
    {
        Shot2cool += Time.deltaTime;
        if (Input.GetKey(KeyCode.X))
        {
            if (Shot2cool >= ShotCoolTime)
            {
                Shot2cool = 0;
            }

            if (Shot2cool == 0)
            {
                for (int i = 1; i <= 8; i++)
                {
                    //玉の角度
                    float Ag = i * 45;//変更時は22.5(全方向ではなく前だけの場合)

                    Vector3 Angle = transform.eulerAngles;
                    Angle.x = transform.rotation.x;
                    Angle.y = transform.rotation.y;
                    Angle.z = Ag;
                    
                    GameObject Shot2 = Instantiate(Bullet2) as GameObject;
                    Shot2.transform.rotation = Quaternion.Euler(Angle);
                    Shot2.transform.position = this.transform.position;
                }
            }
        }
    }

    //--------------------------------------------------------------------------------------

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
}
