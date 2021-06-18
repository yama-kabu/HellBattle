//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Manager1 : MonoBehaviour
{

    //Player_Shot プレハブ
    //public GameObject Shot01;
    public GameObject Shot01;
    public GameObject Shot02;
    public GameObject Shot03;
    public GameObject Shot04_1;
    public GameObject Shot04_2;
    public GameObject Shot04_3;
    public GameObject Shot05;
    public GameObject Shot06;
    public GameObject Shot07;

//--------------------------------------------------------------------------------------

    //スタートをplayer位置に
    private GameObject Player;
    //ターゲットを敵の位置に
    private GameObject Target;

//--------------------------------------------------------------------------------------

    //射撃のクールタイム
    float Shot_Cooltime = 3;//全体のクールタイムを決める
    float homing_Cooltime = 10;//ホーミングのクールタイム数
    float Random_homing_Cooltime = 15;//ランダムホーミングのクールタイム数

    float Shot1_Cooltime_Count = 100;//Shot1用のクールタイムカウンター
    //float Shot2_Cooltime_Count;//Shot2用のクールタイムカウンター
    float Shot3_Cooltime_Count = 100;//Shot3用のクールタイムカウンター
    float Shot4_Cooltime_Count = 100;//Shot4用のクールタイムカウンター
    //float Shot5_Cooltime_Count;//Shot5用のクールタイムカウンター
    float Shot6_Cooltime_Count = 100;//Shot6用のクールタイムカウンター

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
//--------------------------------------------------------------------------------------

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

    //public void Shot1()
    //{

    //    if (Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("Button_A1"))
    //    {
    //        Vector3 Distance = Target.transform.position - Player.transform.position;

    //        if (Way_count == 5)
    //        {
    //            for (int i = 0; i < 5; i++)
    //            {
    //                Vector2 vec = new Vector2(0.0f, 1.0f);
    //                vec = Quaternion.Euler(0, 0, 0) * vec;
    //                vec *= Shot01_Speed;
    //                var q = Quaternion.Euler(0, 0, (-Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg) + (-10 + (5 * i)));
    //                var t = Instantiate(Shot01, transform.position, q);
    //                t.GetComponent<Rigidbody2D>().velocity = vec;
    //                Way_count--;
    //            }
    //            Way_time = 0.5f;
    //        }
    //        else if (Way_count == 4)
    //        {
    //            for (int i = 0; i < 4; i++)
    //            {

    //                Vector2 vec = new Vector2(0.0f, 1.0f);
    //                vec = Quaternion.Euler(0, 0, 0) * vec;
    //                vec *= Shot01_Speed;
    //                var q = Quaternion.Euler(0, 0, (-Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg) + (-6 + (4 * i)));
    //                var t = Instantiate(Shot01, transform.position, q);
    //                t.GetComponent<Rigidbody2D>().velocity = vec;
    //                Way_count--;
    //            }
    //            Way_time = 0.5f;
    //        }
    //        else if (Way_count == 3)
    //        {

    //            for (int i = 0; i < 3; i++)
    //            {
    //                Vector2 vec = new Vector2(0.0f, 1.0f);
    //                vec = Quaternion.Euler(0, 0, 0) * vec;
    //                vec *= Shot01_Speed;
    //                var q = Quaternion.Euler(0, 0, (-Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg) + (-5 + (10 * i)));
    //                var t = Instantiate(Shot01, transform.position, q);
    //                t.GetComponent<Rigidbody2D>().velocity = vec;
    //                Way_count--;
    //            }
    //            Way_time = 0.5f;
    //        }
    //        else if (Way_count == 2)
    //        {

    //            for (int i = 0; i < 2; i++)
    //            {
    //                Vector2 vec = new Vector2(0.0f, 1.0f);
    //                vec = Quaternion.Euler(0, 0, 0) * vec;
    //                vec *= Shot01_Speed;
    //                var q = Quaternion.Euler(0, 0, (-Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg) + (-3 + (6 * i)));
    //                var t = Instantiate(Shot01, transform.position, q);
    //                t.GetComponent<Rigidbody2D>().velocity = vec;
    //                Way_count--;
    //            }
    //            Way_time = 0.5f;
    //        }
    //        else if (Way_count == 1)
    //        {

    //            for (int i = 0; i < 1; i++)
    //            {
    //                Vector2 vec = new Vector2(0.0f, 1.0f);
    //                vec = Quaternion.Euler(0, 0, 0) * vec;
    //                vec *= Shot01_Speed;
    //                var q = Quaternion.Euler(0, 0, (-Mathf.Atan2(Distance.x, Distance.y) * Mathf.Rad2Deg));
    //                var t = Instantiate(Shot01, transform.position, q);
    //                t.GetComponent<Rigidbody2D>().velocity = vec;
    //                Way_count--;
    //            }
    //        }

    //    }
    //}
        
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
        if (Input.GetKey(KeyCode.X) || Input.GetButtonDown("Button_A1"))
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

                Vector3 Distance = Target.transform.position - Player.transform.position;


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


 //--------------------------------------------------------------------------------------
    //名前
}





//Cross
/*
public void Shot99()
{
    if (Input.GetKey(KeyCode.M) || Input.GetButtonDown("Button_B1"))
    {
        if (Cross_Cooltime_check == false && Cross_Duration == false)
        {
            Cross_Duration = true;
        }
    }
    if (Cross_Cooltime_check == false && Cross_Duration == true)
    {
        //↓５０の倍数で上げていくと出る球の量が変わる
        if (Cross_count % Cross_ryou == 0)
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

                    GameObject Shot7 = Instantiate(Shot07) as GameObject;
                    Shot7.transform.rotation = Quaternion.Euler(Angle);
                    Shot7.transform.position = this.transform.position;
                    SC.houkou = true;
                }
                // 右
                {
                    //玉の角度
                    float Shot_Angle = i * 45;//変更時は22.5(全方向ではなく前だけの場合)

                    Vector3 Angle = transform.eulerAngles;
                    Angle.x = transform.rotation.x;
                    Angle.y = transform.rotation.y;
                    Angle.z = Shot_Angle;

                    GameObject Shot7 = Instantiate(Shot07) as GameObject;
                    Shot7.transform.rotation = Quaternion.Euler(Angle);
                    Shot7.transform.position = this.transform.position;
                    SC.houkou = false;
                }
            }
        }
        Cross_count++;
    }

    if (Cross_Duration == true && Cross_Cooltime_check == false)
    {
        Cross_Duration_time -= Time.deltaTime;
        if (Cross_Duration_time <= 0)
        {
            Cross_Duration = false;
            Cross_Cooltime_check = true;
            Cross_Duration_time = Cross_Time;
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













public void Shot1()
    {
        if (Shot1_Cooltime_Count < Shot_Cooltime)
        {
            Shot1_Cooltime_Count += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Z) )
        {

            if (Shot1_Cooltime_Count > Shot_Cooltime)
            {
                for (int i = 1; i <= 8; i++)
                {
                    //玉の角度
                    float Shot_Angle = i * 45;//変更時は22.5(全方向ではなく前だけの場合)

                    Vector3 Angle = transform.eulerAngles;
                    Angle.x = transform.rotation.x;
                    Angle.y = transform.rotation.y;
                    Angle.z = Shot_Angle;

                    GameObject Shot1 = Instantiate(Shot01) as GameObject;
                    Shot1.transform.rotation = Quaternion.Euler(Angle);
                    Shot1.transform.position = this.transform.position;
                }
                //クールタイム初期化
                Shot1_Cooltime_Count = 0;
            }
           
        }
    }
*/