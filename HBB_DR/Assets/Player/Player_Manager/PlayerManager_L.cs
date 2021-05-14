//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager_L : MonoBehaviour
{
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D Player_L;
    //自機の移動速度を格納する変数（初期値５）
    public float Speed = 5;
    //Player_Shot プレハブ
    public GameObject Shot01;
    public GameObject Shot02;
    public GameObject Shot03;
    public GameObject Shot04;

    int count = 0;

    //射撃のクールタイム
    public float Shot_Cooltime;//全体のクールタイムを決める
    float Shot1_Cooltime_Count;//Shot1用のクールタイムカウンター
    float Shot2_Cooltime_Count;//Shot2用のクールタイムカウンター
    float Shot3_Cooltime_Count;//Shot3用のクールタイムカウンター
    float Shot4_Cooltime_Count;//Shot4用のクールタイムカウンター

    float Velocity_0, theta;



    //ショット３のクールタイムと自動発射にかんするやつ
    //float Shot3_Count_Time = 3;
    float Shot_Count_Time_Save = 3;
    bool Spiral_Duration = false;
    float Spiral_Duration_time;
    bool Spiral_Cooltime_check = false;

    //ショット1の速度
    public float Shot01_Speed = 0;
    //ショット2の速度
    public float Shot02_Speed = 0;
    //ショット3の速度
    public float Shot03_Speed = 0;
    //ショット4の速度
    public float Shot04_Speed = 0;


    //プレイヤー速度
    public Vector2 PlayerSpeed = new Vector2(0.005f, 0.005f);

//--------------------------------------------------------------------------------------

    // ゲームのスタート時の処理
    void Start()
    {
        //Rigidbody2D　コンポーネントを取得して変数　Player_L　に格納
        Player_L = GetComponent<Rigidbody2D>();

    }

//--------------------------------------------------------------------------------------

    // 繰り返す処理
    void Update()
    {
        Move();
        Shot1();
        Shot2();
        Shot3();
        Shot4();
    }

//--------------------------------------------------------------------------------------

    //Normal
    void Shot1()
    {
        Shot1_Cooltime_Count += Time.deltaTime;
        if (Input.GetKey(KeyCode.Z))
        {
            if (Shot1_Cooltime_Count >= Shot_Cooltime)
            {
                Shot1_Cooltime_Count = 0;
            }

            if (Shot1_Cooltime_Count == 0)
            {
                GameObject Shot = Instantiate(Shot01);

                Shot.transform.position = this.transform.position;
            }
        }
    }

//--------------------------------------------------------------------------------------

    //8Way
    void Shot2()
    {
        Shot2_Cooltime_Count += Time.deltaTime;
        if (Input.GetKey(KeyCode.X))
        {
            if (Shot2_Cooltime_Count >= Shot_Cooltime)
            {
                Shot2_Cooltime_Count = 0;
            }

            if (Shot2_Cooltime_Count == 0)
            {
                for (int i = 1; i <= 8; i++)
                {
                    //玉の角度
                    float Shot_Angle = i * 45;//変更時は22.5(全方向ではなく前だけの場合)

                    Vector3 Angle = transform.eulerAngles;
                    Angle.x = transform.rotation.x;
                    Angle.y = transform.rotation.y;
                    Angle.z = Shot_Angle;
                    
                    GameObject Shot2 = Instantiate(Shot02) as GameObject;
                    Shot2.transform.rotation = Quaternion.Euler(Angle);
                    Shot2.transform.position = this.transform.position;
                }
            }
        }
    }

//--------------------------------------------------------------------------------------

    //Spiral
    void Shot3()
    {

            if (Input.GetKey(KeyCode.C))
            {
                if (Spiral_Cooltime_check == false && Spiral_Duration == false)
                {
                    Spiral_Duration = true;
                }
            }
        if (Spiral_Cooltime_check == false && Spiral_Duration == true)
        {
            count++;
            if (count % 50 == 0)
            {
                //↓ここの数字を変えると一度に出す弾の数を変えられる
                for (int i = 0; i < 1; i++)
                {
                    Vector2 Vec = new Vector2(0.0f, 1.0f);
                    Vec = Quaternion.Euler(0, 0, 5f * count) * Vec;
                    Vec.Normalize();                                    //上の(0,0,Xf)と下の(360/X)のXは合わせるように
                    Vec = Quaternion.Euler(0, 0, (360 / 5) * i) * Vec;
                    Vec *= Shot03_Speed;
                    //一つ目
                    var a = Quaternion.Euler(0, 0, -Mathf.Atan2(Vec.x, Vec.y) * Mathf.Rad2Deg);
                    var b = Instantiate(Shot03, transform.position, a);
                    b.GetComponent<Rigidbody2D>().velocity = Vec;

                    //二つ目
                    var c = Quaternion.Euler(0, 0, -Mathf.Atan2(Vec.x, Vec.y) * Mathf.Rad2Deg + 120);
                    var d = Instantiate(Shot03, transform.position, c);
                    d.GetComponent<Rigidbody2D>().velocity = Vec;
                    //３つ目
                    var e = Quaternion.Euler(0, 0, -Mathf.Atan2(Vec.x, Vec.y) * Mathf.Rad2Deg + 240);
                    var f = Instantiate(Shot03, transform.position, e);
                    f.GetComponent<Rigidbody2D>().velocity = Vec;
                }


            }
        }
        if (Spiral_Duration == true && Spiral_Cooltime_check == false)
        {
            Spiral_Duration_time -= Time.deltaTime;
            if (Spiral_Duration_time <= 0)
            {
                Spiral_Duration = false;
                Spiral_Cooltime_check = true;
                Spiral_Duration_time = 3;
            }
        }
        if (Spiral_Cooltime_check == true && Spiral_Cooltime_check == true)
        {
            Shot_Count_Time_Save -= Time.deltaTime;
            if (Shot_Count_Time_Save <= 0)
            {
                Spiral_Cooltime_check = false;
                Shot_Count_Time_Save = 3;
            }
        }


            

    }
//--------------------------------------------------------------------------------------

    void Shot4()
    {
        Shot4_Cooltime_Count += Time.deltaTime;
        if (Input.GetKey(KeyCode.V))
        {
            if (Shot4_Cooltime_Count >= Shot_Cooltime)
            {
                Shot4_Cooltime_Count = 0;
            }

            if (Shot4_Cooltime_Count == 0)
            {
                GameObject Shot = Instantiate(Shot04);

                Shot.transform.position = this.transform.position;
            }
        }
    }

//--------------------------------------------------------------------------------------
    //移動
    void Move()
    {
        // 現在位置をPositionに代入
        Vector2 Position = transform.position;
        //斜め移動
        if(Input.GetKey("a") & Input.GetKey("w"))
        {
            //左上を押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.x -= PlayerSpeed.x;
            Position.y += PlayerSpeed.y;
        }
        else if(Input.GetKey("a") & Input.GetKey("s"))
        {
            //左下を押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.x -= PlayerSpeed.x;
            Position.y -= PlayerSpeed.y;
        }
        else if (Input.GetKey("d") & Input.GetKey("w"))
        {
            //左上を押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.x += PlayerSpeed.x;
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey("d") & Input.GetKey("s"))
        {
            //左下を押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.x += PlayerSpeed.x;
            Position.y -= PlayerSpeed.y;
        }

        //上下左右移動
        else if (Input.GetKey("a"))
        {
            // 左キーを押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.x -= PlayerSpeed.x;
        }
        else if (Input.GetKey("d"))
        { 
            // 右キーを押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.x += PlayerSpeed.x;
        }
        else if (Input.GetKey("w"))
        { 
            // 上キーを押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey("s"))
        { 
            // 下キーを押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.y -= PlayerSpeed.y;
        }
        // 現在の位置に加算減算を行ったPositionを代入する
        transform.position = Position;
    }
    






}
