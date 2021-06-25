//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Manager1 : MonoBehaviour
{

    //Player_Shot プレハブ
    public GameObject Shot01;
    public GameObject Shot02;
    public GameObject Shot03;
    public GameObject Shot04_1;
    public GameObject Shot04_2;
    public GameObject Shot04_3;
    public GameObject Shot05;
    public GameObject Shot06;
    public GameObject Shot07;
    public GameObject Shot08;


//--------------------------------------------------------------------------------------

    //スタートをplayer位置に
    private GameObject Player;
    //ターゲットを敵の位置に
    private GameObject Target;

    Vector3 Distance;
//--------------------------------------------------------------------------------------

    //射撃のクールタイム
    float Shot_Cooltime = 3;//全体のクールタイムを決める

     
    float Shot1_Cooltime_Count = 100;//Shot1用のクールタイムカウンター
    //float Shot2_Cooltime_Count;//Shot2用のクールタイムカウンター
    float Shot3_Cooltime_Count = 100;//Shot3用のクールタイムカウンター
    float Shot4_Cooltime_Count = 100;//Shot4用のクールタイムカウンター
    //float Shot5_Cooltime_Count;//Shot5用のクールタイムカウンター
    float Shot6_Cooltime_Count = 100;//Shot6用のクールタイムカウンター
    float Shot7_Cooltime_Count = 100;//Shot7用のクールタイムカウンター

    float homing_Cooltime = 10;      //ホーミングのクールタイム数 
    float Random_homing_Cooltime = 15;//ランダムホーミングのクールタイム数
    float Explosion_Cooltime =5;   //エクスプロージョンのクールタイム数


    //発射感覚
    float Way_time_count = 0;
    int Way_count = 1;
    //
    float Push_time_count = 0;
    int Push_count = 0;
    bool Is_Attack = false;


    int Spiral_count = 0;
    int Barrage_count = 0;




    //ショット2の類
    //クールタイム調整用
    float Shot_Count_Time_Save = 3;
    //何秒発射されたか
    float Spiral_Duration_time = 3;


    float Barrage_Duration_time = 3;


    //発射しているか否か判定
    bool Spiral_Duration = false;
    bool Barrage_Duration = false;
    //クールタイム中か否か判定
    bool Spiral_Cooltime_check = false;
    bool Barrage_Cooltime_check = false;



    //スパイラルの一度の操作で続ける時間
    int Spiral_Time = 3;
    //バラージの一度の操作で続ける時間
    int Barrage_Time = 3;

    //ショット1の速度
    float Shot01_Speed = 1f;
    //ショット2の速度
    //１０００にすると面白くなる
    float Shot02_mawaru_Speed = 1f;
    //ショット5の速度
    float Shot05_Speed = 1f;

    public float Spiral_kaiten;
    public float Barrage_ryou;





    //曲がる方向を示す　右ならtrue,左ならfalse
    bool Cross_houkou;
    bool Cross_Duration = false;
    bool Cross_Cooltime_check = false;
    float Cross_Duration_time = 3;
    float Cross_time_count = 0;


    bool Explosion_houkou;
//-------------------------------------------------------------------------------------

    void Start()
    {
        //追いかける対象をここで決める
        if (this.gameObject.CompareTag("Player_L1"))
        {
            Player = GameObject.Find("Player_L1");
            Target = GameObject.Find("Player_R2");
        }
        else if (this.gameObject.CompareTag("Player_L2"))
        {
            Player = GameObject.Find("Player_L2");
            Target = GameObject.Find("Player_R1");
        }
        

    }

//--------------------------------------------------------------------------------------
    //8Way

    public void Shot1()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetButtonDown("Button_X1"))
        {
            //攻撃してないのを確認
            if (!Is_Attack)
            {
                //５回まで押されるの許可
                if (Push_count < 5)
                {
                    //押された回数プラス
                    Push_count++;
                }
                else if (Push_count == 5)
                {
                    //５回に達したら攻撃許可
                    Is_Attack = true;
                }
            }
        }
        //２秒計算開始
        if(Push_time_count < 2 && Push_count != 0)
        {
            Push_time_count += Time.deltaTime;
        }
        //２秒たったらチェック
        else if (Push_time_count > 2)
        {
            //攻撃許可
            Is_Attack = true;
        }

        //攻撃開始
        if (Is_Attack)
        {
            //0.5秒計算
            Way_time_count += Time.deltaTime;
            //0,5秒立って、押された回数が０ではなく、ウェイカウントを下回っていたら
            if (Way_time_count > 0.5 && Push_count != 0 && Push_count >= Way_count)
            {
                if (Target != null)
                {
                    //ベクトル計算
                    Distance = Target.transform.position - Player.transform.position;
                }
                else if(Target == null)
                {
                    Distance =  Player.transform.position;
                }
                //カウントが５だった場合
                if (Way_count == 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Way(Distance, Way_count, i);
                    }
                }
                //カウントが４だった場合
                else if (Way_count == 4)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Way(Distance, Way_count, i);
                    }
                }
                //カウントが３だった場合
                else if (Way_count == 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Way(Distance, Way_count, i);
                    }
                }
                //カウントが２だった場合
                else if (Way_count == 2)
                {

                    for (int i = 0; i < 2; i++)
                    {
                        Way(Distance, Way_count, i);
                    }
                }
                //カウントが１だった場合
                else if (Way_count == 1)
                {

                    for (int i = 0; i < 1; i++)
                    {
                        Way(Distance, Way_count, i);
                    }
                }
                //カウント加算
                Way_count++;
                //時間を０に
                Way_time_count = 0;
            }

            //初期化
            if (Push_count < Way_count)
            {
                Way_time_count = 0;
                Push_count = 0;
                Way_count = 1;
                Push_time_count = 0;
                Is_Attack = false;
            }
        }
    }

//--------------------------------------------------------------------------------------

    //Way処理の中身
    public void Way(Vector3 Distance,int Way_count,int i)
    {

        Vector2 vec = new Vector2(0.0f, 1.0f);
        vec = Quaternion.Euler(0, 0, 0) * vec;
        vec *= Shot01_Speed;

        //初期化
        var q = Quaternion.Euler(0, 0, 0);
        if (Way_count == 1)
        {
            q = Quaternion.Euler(0, 0, (-Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg));
        }
        else if(Way_count == 2)
        {
            q = Quaternion.Euler(0, 0, (-Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg) + (-3 + (6 * i)));
        }
        else if (Way_count == 3)
        {
            q = Quaternion.Euler(0, 0, (-Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg) + (-4 + (4 * i)));
        }
        else if(Way_count == 4)
        {
            q = Quaternion.Euler(0, 0, (-Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg) + (-6 + (4 * i)));
        }
        else if (Way_count == 5)
        {
            q = Quaternion.Euler(0, 0, (-Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg) + (-10 + (5 * i)));
        }
        var t = Instantiate(Shot01, transform.position, q);
        t.GetComponent<Rigidbody2D>().velocity = vec;
    }
//--------------------------------------------------------------------------------------
    //Spiral

    public void Shot2()
        {

            if (Input.GetKey(KeyCode.Z) || Input.GetButtonDown("Button_A1"))
            {
                if (Spiral_Cooltime_check == false && Spiral_Duration == false)
                {
                    Spiral_Duration = true;
                }
            }
            if (Spiral_Cooltime_check == false && Spiral_Duration == true)
            {
                Spiral_count++;
                //↓５０の倍数で上げていくと出る球の量が変わる
                if (Spiral_count % Spiral_kaiten == 0)
                {
                    //↓ここの数字を変えると一度に出す弾の数を変えられる
                    for (int i = 0; i < 1; i++)
                    {

                        Vector2 Vec = new Vector2(0.0f, 10f);
                        Vec = Quaternion.Euler(0, 0, 50f * Spiral_count) * Vec;
                        Vec.Normalize();                                    //上の(0,0,Xf)と下の(360/X)のXは合わせるように
                        Vec = Quaternion.Euler(0, 0, (360 / 5) * i) * Vec;
                        Vec *= Shot02_mawaru_Speed;

                        //一つ目
                        var a = Quaternion.Euler(0, 0, -Mathf.Atan2(Vec.x, Vec.y) * Mathf.Rad2Deg);
                        var b = Instantiate(Shot02, transform.position, a);
                        b.GetComponent<Rigidbody2D>().velocity = Vec;

                        //二つ目
                        var c = Quaternion.Euler(0, 0, -Mathf.Atan2(Vec.x, Vec.y) * Mathf.Rad2Deg + 120);
                        var d = Instantiate(Shot02, transform.position, c);
                        d.GetComponent<Rigidbody2D>().velocity = Vec;
                        //３つ目
                        var e = Quaternion.Euler(0, 0, -Mathf.Atan2(Vec.x, Vec.y) * Mathf.Rad2Deg + 240);
                        var f = Instantiate(Shot02, transform.position, e);
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

    public void Shot3()
    {
        if (Shot3_Cooltime_Count < homing_Cooltime)
        {
            Shot3_Cooltime_Count += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.X) || Input.GetButtonDown("Button_B1"))
        {
            if ((Shot3_Cooltime_Count > homing_Cooltime))
            {
                GameObject Shot = Instantiate(Shot03);

                Shot.transform.position = this.transform.position;

                //クールタイム初期化
                Shot3_Cooltime_Count = 0;
            }
            
        }
    }

//--------------------------------------------------------------------------------------
    //Reflect

    public void Shot4()
    {
        Shot4_Cooltime_Count += Time.deltaTime;
        if (Input.GetKey(KeyCode.X) || Input.GetButtonDown("Button_B1"))
        {

            if (Shot4_Cooltime_Count >= Shot_Cooltime)
            {
                Shot4_Cooltime_Count = 0;
            }

            if (Shot4_Cooltime_Count == 0)
            {


                GameObject Reflect1 = Instantiate(Shot04_1);//まっすぐ敵に飛んでく
                Reflect1.transform.position = this.transform.position;


                GameObject Reflect2 = Instantiate(Shot04_2);//-45度手前に飛んでく
                Reflect2.transform.position = this.transform.position;


                GameObject Reflect3 = Instantiate(Shot04_3);//+45度奥に飛んでく
                Reflect3.transform.position = this.transform.position;

            }
        }
    }

//--------------------------------------------------------------------------------------
    //Barrage

    public void Shot5()
    {
        if (Input.GetKey(KeyCode.V) || Input.GetButtonDown("Button_Y1"))
        {
            if (Barrage_Cooltime_check == false && Barrage_Duration == false)
            {
                Barrage_Duration = true;
            }
        }

        if (Barrage_Cooltime_check == false && Barrage_Duration == true)
        {
            Barrage_count++;
            //ここの数字をいじると、飛んでいく弾の量を調整することができる
            if (Barrage_count % Barrage_ryou == 0)
            {

                if (Target != null)
                {
                    //ベクトル計算
                    Distance = Target.transform.position - Player.transform.position;
                }
                else if (Target == null)
                {
                    Distance = Player.transform.position;
                }


                Vector2 vec = new Vector2(0.0f, 1.0f);
                vec = Quaternion.Euler(0, 0, Random.Range(-35f, 35f)) * vec;
                vec *= Shot05_Speed;
                //var q = Quaternion.Euler(0, 0, -Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg);
                var q = Quaternion.Euler(0, 0, -Mathf.Atan2(Distance.x +Random.Range(-400f, 400f), Distance.y + Random.Range(-40f, 40f)) * Mathf.Rad2Deg);
                var t = Instantiate(Shot05, transform.position, q);
                t.GetComponent<Rigidbody2D>().velocity = vec;

            }
        }

        if (Barrage_Duration == true && Barrage_Cooltime_check == false)
        {
            Barrage_Duration_time -= Time.deltaTime;
            if (Barrage_Duration_time <= 0)
            {
                Barrage_Duration = false;
                Barrage_Cooltime_check = true;
                Barrage_Duration_time = Barrage_Time;
            }
        }
        else if (Barrage_Cooltime_check == true && Barrage_Duration == false)
        {
            Shot_Count_Time_Save -= Time.deltaTime;
            if (Shot_Count_Time_Save <= 0)
            {
                Barrage_Cooltime_check = false;
                Shot_Count_Time_Save = 3;
                Barrage_count = 0;
            }
        }
    }

 //--------------------------------------------------------------------------------------
    //Random_Homing

    public void Shot6()
    {
        Shot6_Cooltime_Count += Time.deltaTime;
        if (Input.GetKey(KeyCode.V) || Input.GetButtonDown("Button_Y1"))
        {
            if (Shot6_Cooltime_Count > Random_homing_Cooltime)
            {
                Shot6_Cooltime_Count = 0;
            }
            if (Shot6_Cooltime_Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject Shot = Instantiate(Shot06);
                    Shot.transform.position = this.transform.position;
                }
            }
        }
    }

//--------------------------------------------------------------------------------------
    //Explosion

    public void Shot7()
    {
        Shot7_Cooltime_Count += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.C) || Input.GetButtonDown("Button_X1"))
        {
            if (Shot7_Cooltime_Count > Explosion_Cooltime)
            {
                Shot7_Cooltime_Count = 0;
            }
            if (Shot7_Cooltime_Count == 0)
            {
                GameObject Shot = Instantiate(Shot07);
                Shot.transform.position = this.transform.position;
            }
        }
    }

//--------------------------------------------------------------------------------------
    //Cross

    public void Shot8()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("Button_A1"))
        {
            if (Cross_Cooltime_check == false && Cross_Duration == false)
            {
                Cross_Duration = true;
            }
        }
        if (Cross_Cooltime_check == false && Cross_Duration == true)
        {
            Cross_time_count ++;
            if (Cross_time_count % 120 == 0)
            {
                for (int i = 0; i < 8; i++)
                {

                    // 左
                    {
                        //玉の角度
                        float Shot_Angle = i * 45;//変更時は22.5(全方向ではなく前だけの場合)

                        Vector3 Angle = transform.eulerAngles;
                        Angle.x = transform.rotation.x;
                        Angle.y = transform.rotation.y;
                        Angle.z = Shot_Angle;

                        GameObject Shot7 = Instantiate(Shot08) as GameObject;
                        Shot7.transform.rotation = Quaternion.Euler(Angle);
                        Shot7.transform.position = this.transform.position;
                        Cross_houkou = true;
                        Shot08.GetComponent<Shot_Cross>().houkou = Cross_houkou;
                    }
                    // 右
                    {
                        //玉の角度
                        float Shot_Angle = i * 45;//変更時は22.5(全方向ではなく前だけの場合)

                        Vector3 Angle = transform.eulerAngles;
                        Angle.x = transform.rotation.x;
                        Angle.y = transform.rotation.y;
                        Angle.z = Shot_Angle;

                        GameObject ShotShot_test_cross = Instantiate(Shot08) as GameObject;
                        ShotShot_test_cross.transform.rotation = Quaternion.Euler(Angle);
                        ShotShot_test_cross.transform.position = this.transform.position;
                        Cross_houkou = false;
                        Shot08.GetComponent<Shot_Cross>().houkou = Cross_houkou;
                    }
                }
            }
        }
        if (Cross_Duration == true && Cross_Cooltime_check == false)
        {
            Cross_Duration_time -= Time.deltaTime;
            if (Cross_Duration_time <= 0)
            {
                Cross_Duration = false;
                Cross_Cooltime_check = true;
                Cross_Duration_time = Spiral_Time;
            }
        }
        else if (Cross_Cooltime_check == true && Cross_Duration == false)
        {
            Shot_Count_Time_Save -= Time.deltaTime;
            if (Shot_Count_Time_Save <= 0)
            {
                Cross_Cooltime_check = false;
                Shot_Count_Time_Save = 3;
                
            }
        }
    }


//--------------------------------------------------------------------------------------
    //

 //--------------------------------------------------------------------------------------
    //名前
}






