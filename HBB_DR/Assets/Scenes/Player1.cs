using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D P1;
    //自機の移動速度を格納する変数（初期値５）
    public float speed = 5;
    //Player2Buleet プレハブ
    public GameObject Bullet_Z;
    public GameObject Bullet_X;
    //Z弾丸発射時間
    float ShotTime_Z = 0;
    //X弾丸発射時間
    float ShotTime_X = 0;
    //弾丸の経過時間
    public float ElapsedTime = 0;
    //弾丸速度
    public float BulletSpeed = 0;

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
        //左右の入力をｘに渡す
        float x = Input.GetAxisRaw("Horizontal");
        //上下の入力をｙに渡す。
        float y = Input.GetAxisRaw("Vertical");

        //移動する向きを求める
        //ｘとｙの入力値を正規化し、directionに渡す。
        Vector2 direction = new Vector2(x, y).normalized;
        //Rigidbody2Dコンポーネントのvelocityに方向と移動速度を掛けた値を渡す。
        P1.velocity = direction * speed;

        //Zキー入力弾丸を発射
        Shot_Z();
        //Xキー入力で弾丸発射
        Shot_X();
        //Z弾丸発射間隔計測
        ShotTime_Z += Time.deltaTime;
        //X弾丸発射間隔計測
        ShotTime_X += Time.deltaTime;
    }

//--------------------------------------------------------------------------------------

    //弾丸の中身
    //ショット_Z
    void Shot_Z()
    {
        //Zキーを押した際の判定
        if (Input.GetKey(KeyCode.Z))
        {
            //経過時間
            if (ShotTime_Z >= ElapsedTime)
            {
                ShotTime_Z = 0;
            }
            //画像表示
            if (ShotTime_Z == 0)
            {
                GameObject Circle = Instantiate(Bullet_Z);

                Circle.transform.position = this.transform.position;

            }
        }
    }

//--------------------------------------------------------------------------------------

    //弾丸の中身
    //ショット_X
    void Shot_X()
    {
        //Xキーを押した際の判定
        if (Input.GetKey(KeyCode.X))
        {
            //経過時間
            if (ShotTime_X >= ElapsedTime)
            {
                ShotTime_X = 0;
            }

            //画像表示
            if (ShotTime_X == 0)
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
                    GameObject Circle = Instantiate(Bullet_X) as GameObject;
                    //角度
                    Bullet_X.transform.rotation = Quaternion.Euler(Angle);
                    //画像の表示
                    Bullet_X.transform.position = this.transform.position;

                }

            }
        }
    }
}
