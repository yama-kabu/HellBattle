using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D P2;
    //自機の移動速度を格納する変数（初期値５）
    public float speed = 5;
    //Player2Buleet プレハブ
    public GameObject Circle1;
    //時間間隔
    float Times = 0;

    public float Timed = 0;

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
        if(Input.GetKey(KeyCode.Z))
        {
            Shot();
        }

        Times += Time.deltaTime;
    }

//--------------------------------------------------------------------------------------

    //玉の中身
    void Shot()
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
