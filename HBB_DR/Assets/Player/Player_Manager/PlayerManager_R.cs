//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager_R : MonoBehaviour
{
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D Player_R;
    //自機の移動速度を格納する変数（初期値５）
    public float Speed = 5;
    
    public int Player_MAXHP;
    public int Player_HP;


//--------------------------------------------------------------------------------------

    // ゲームのスタート時の処理
    void Start()
    {
        //Rigidbody2D　コンポーネントを取得して変数　Player_R　に格納
        Player_R = GetComponent<Rigidbody2D>();
    }

//--------------------------------------------------------------------------------------

    // 繰り返す処理
    void Update()
    {
     
    }

//--------------------------------------------------------------------------------------

    void Move()
    {

    }

//--------------------------------------------------------------------------------------
}
