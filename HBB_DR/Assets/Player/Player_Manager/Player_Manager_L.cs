//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager_L : MonoBehaviour
{
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D Player_L;
    private Rigidbody2D Reflect;

    //キャラクター選択　仮置き
    public int Character;
    
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
        Shot_Manager2 s_Manager2 = GetComponent<Shot_Manager2>();

        //プレイヤー１だった場合
        if (this.gameObject.CompareTag("Player_L1"))
        {
            if (Character == 1)
            {
                //キャラクターが使える４つの弾
                //１つ目　操作キー：Z　｜　操作ボタン：A
                s_Manager1.Shot8();//Cross
                //２つ目　操作キー：X　｜　操作ボタン：B
                s_Manager1.Shot3();//Homing
                //３つ目　操作キー：C　｜　操作ボタン：X
                s_Manager1.Shot7();//Explosion
                //４つ目　操作キー：V　｜　操作ボタン：Y
                s_Manager1.Shot5();//Barrage

                //テスト



                //必殺技

            }
            else if (Character == 2)
            {
                //キャラクターが使える４つの弾
                //１つ目　操作キー：Z　｜　操作ボタン：A
                s_Manager1.Shot2();//spiral
                //２つ目　操作キー：X　｜　操作ボタン：B
                s_Manager1.Shot4();//Reflect
                //３つ目　操作キー：C　｜　操作ボタン：X
                s_Manager1.Shot1();//Way
                //４つ目　操作キー：V　｜　操作ボタン：Y
                s_Manager1.Shot6();//Random_Homing


                //必殺技

            }
            /*
            else if (Character == 3)
            {
                //キャラクターが使える４つの弾
                //１つ目　操作キー：Z　｜　操作ボタン：A

                //２つ目　操作キー：X　｜　操作ボタン：B

                //３つ目　操作キー：C　｜　操作ボタン：X
                
                //４つ目　操作キー：V　｜　操作ボタン：Y
                


                //必殺技

            }
            */
        }
        //プレイヤー２だった場合
        else if (this.gameObject.CompareTag("Player_L2"))
        {
            if (Character == 1)
            {
                //キャラクターが使える４つの弾
                //１つ目　操作キー：Z　｜　操作ボタン：A
                s_Manager2.Shot8();//Cross
                //２つ目　操作キー：X　｜　操作ボタン：B
                s_Manager2.Shot3();//Homing
                //３つ目　操作キー：C　｜　操作ボタン：X
                s_Manager2.Shot7();//Explosion
                //４つ目　操作キー：V　｜　操作ボタン：Y
                s_Manager2.Shot5();//Barrage

                //テスト



                //必殺技

            }
            else if (Character == 2)
            {
                //キャラクターが使える４つの弾
                //１つ目　操作キー：Z　｜　操作ボタン：A
                s_Manager2.Shot2();//spiral
                //２つ目　操作キー：X　｜　操作ボタン：B
                s_Manager2.Shot4();//Reflect
                //３つ目　操作キー：C　｜　操作ボタン：X
                s_Manager2.Shot1();//Way
                //４つ目　操作キー：V　｜　操作ボタン：Y
                s_Manager2.Shot6();//Random_Homing


                //必殺技

            }
            /*
            else if (Character == 3)
            {
                //キャラクターが使える４つの弾
                //１つ目　操作キー：Z　｜　操作ボタン：A

                //２つ目　操作キー：X　｜　操作ボタン：B

                //３つ目　操作キー：C　｜　操作ボタン：X
                
                //４つ目　操作キー：V　｜　操作ボタン：Y
                


                //必殺技

            }
            */
        }
        //--------------------------------------------------------------------------------------

        //保留
        //

    }

    //--------------------------------------------------------------------------------------

}
