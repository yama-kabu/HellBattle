using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
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
    




}
