//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager_R : MonoBehaviour
{
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D Player_R;
 
    public int Player_MAXHP = 10;
    public int Player_HP = 10;


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
