//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager_L : MonoBehaviour
{
    private Rigidbody2D Reflect;

    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D Player_L;
    //自機の移動速度を格納する変数（初期値５）
    public float Speed = 5;
    //Player_Shot プレハブ
    public GameObject Shot01;
    public GameObject Shot02;
    public GameObject Shot03;
    public GameObject Shot04;
    public GameObject Shot05;


    int count = 0;

    //射撃のクールタイム
    public float Shot_Cooltime;//全体のクールタイムを決める
    public float homing_Cooltime;
    //float Shot1_Cooltime_Count;//Shot1用のクールタイムカウンター
    float Shot2_Cooltime_Count;//Shot2用のクールタイムカウンター
    float Shot3_Cooltime_Count;//Shot3用のクールタイムカウンター
    public float Shot4_Cooltime_Count;//Shot4用のクールタイムカウンター
    float Shot5_Cooltime_Count;//Shot5用のクールタイムカウンター
    



    //ショット３の類
    //クールタイム調整用
    float Shot_Count_Time_Save = 3;
    //何秒発射されたか
    float Spiral_Duration_time = 3;
    //発射しているか否か判定
    bool Spiral_Duration = false;
    //クールタイム中か否か判定
    bool Spiral_Cooltime_check = false;

    //スパイラルの一度の操作で続ける時間
    public int Spiral_Time;

    //ショット3の速度
    public float Shot03_Speed = 0;



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
        //Shot1();
        Shot2();
        Shot3();
        Shot4();
        Shot5();
    }

//--------------------------------------------------------------------------------------
/*
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
*/
//--------------------------------------------------------------------------------------

    //8Way
    void Shot2()
    {
        Shot2_Cooltime_Count += Time.deltaTime;
        if (Input.GetKey(KeyCode.Z))
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

        if (Input.GetKey(KeyCode.X))
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
                Spiral_Duration_time = Spiral_Time;
            }
        }
       else if (Spiral_Cooltime_check == true && Spiral_Duration == false)
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
//homing
    void Shot4()
    {
        Shot4_Cooltime_Count += Time.deltaTime;
        if (Input.GetKey(KeyCode.C))
        {
            if (Shot4_Cooltime_Count >= homing_Cooltime)
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

    //Reflect
    void Shot5()
    {
        Shot5_Cooltime_Count += Time.deltaTime;
        if (Input.GetKey(KeyCode.V))
        {
            if (Shot5_Cooltime_Count >= Shot_Cooltime)
            {
                Shot5_Cooltime_Count = 0;
            }

            if (Shot5_Cooltime_Count == 0)
            {
                
                //GameObject Reflect1 = Instantiate(Shot05);//-45度手前に飛んでく
                //Reflect1.transform.position = this.transform.position;


                GameObject Reflect2 = Instantiate(Shot05);//まっすぐ敵に飛んでく
                Reflect2.transform.position = this.transform.position;


                //GameObject Reflect3 = Instantiate(Shot05);//+45度奥に飛んでく
                //Reflect3.transform.position = this.transform.position;



            }
        }
    }






//--------------------------------------------------------------------------------------



//--------------------------------------------------------------------------------------





}
