//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager_L2 : MonoBehaviour
{
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D Player_L;

    private Rigidbody2D Reflect;
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

        Shot_Manager2 s_Manager2 = GetComponent<Shot_Manager2>();
        //s_Manager2.Shot1();//Way
        s_Manager2.Shot2();//spiral
        s_Manager2.Shot3();//Homing
        s_Manager2.Shot4();//Reflect
        s_Manager2.Shot5();//Barrage

        //s_Manager.Shot6();//Random_Homing
        ////////////////////↓Shot7からお願いします
    }

//--------------------------------------------------------------------------------------

}
