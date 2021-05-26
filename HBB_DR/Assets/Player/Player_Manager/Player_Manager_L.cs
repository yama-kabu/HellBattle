//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager_L : MonoBehaviour
{
    private Rigidbody2D Reflect;

    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D Player_L;






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
        Shot_Manager s_Manager = GetComponent<Shot_Manager>();
        s_Manager.Shot2();
        s_Manager.Shot3();
        s_Manager.Shot4();
        s_Manager.Shot5();
    }

//--------------------------------------------------------------------------------------

}
