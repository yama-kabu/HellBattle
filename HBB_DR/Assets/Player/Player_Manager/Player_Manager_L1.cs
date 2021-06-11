//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager_L1 : MonoBehaviour
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
        Shot_Manager1 s_Manager1 = GetComponent<Shot_Manager1>();
        //s_Manager1.Shot1();//Way
        s_Manager1.Shot2();//spiral
        s_Manager1.Shot3();//Homing
        s_Manager1.Shot4();//Reflect
        s_Manager1.Shot5();//Barrage


        s_Manager1.Shot6();//Random_Homing
        ////////////////////↓Shot7からお願いします
    }

//--------------------------------------------------------------------------------------

}
