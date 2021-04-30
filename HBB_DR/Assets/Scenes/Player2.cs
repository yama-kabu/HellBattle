using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D P2;
    //自機の移動速度を格納する変数（初期値５）
    public float speed = 5;
    //Player2Buleet プレハブ
    public GameObject Circle1;
    public GameObject Circle2;
    //時間間隔
    float Times = 0;

    public float Timed = 0;

    public float balletSpeed = 0;

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
        //左右の入力をｘに渡す
        float x = Input.GetAxisRaw("Horizontal");
        //上下の入力をｙに渡す。
        float y = Input.GetAxisRaw("Vertical");

        //移動する向きを求める
        //ｘとｙの入力値を正規化し、directionに渡す。
        Vector2 direction = new Vector2(x, y).normalized;
        //Rigidbody2Dコンポーネントのvelocityに方向と移動速度を掛けた値を渡す。
        P2.velocity = direction * speed;

        //Zキー入力で玉を発射
     
        Shot();

        Shot2();

        Times += Time.deltaTime;
    }

//--------------------------------------------------------------------------------------

    //玉の中身
    //ショット１
    void Shot()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (Times >= Timed)
            {
                Times = 0;
            }

            if (Times == 0)
            {
                GameObject Circle = Instantiate(Circle1);

                Circle.transform.position = this.transform.position;

            }
        }
    }

    void Shot2()
    {
        if (Input.GetKey(KeyCode.X))
        {
            if (Times >= Timed)
            {
                Times = 0;
            }

            if (Times == 0)
            {
                for (int i = 1; i <= 8; i++)
                {
                    //玉の角度
                    float Ag = i * 45;  //変更時は22.5

                    Vector3 Angle01 = transform.eulerAngles;
                    Angle01.x = transform.rotation.x;
                    Angle01.y = transform.rotation.y;
                    Angle01.z = Ag;


                    GameObject Circle = Instantiate(Circle2)as GameObject;

                    Circle2.transform.rotation = Quaternion.Euler(Angle01);

                    Circle2.transform.position = this.transform.position;

                    
                }

            }
        }
    }
    




}
