//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//参照系

    public Text syouhai_text_L1;  //テキストをいじるためにテキストを格納するものだよ
    public Text syouhai_text_L2;  //テキストをいじるためにテキストを格納するものだよ

    public bool syouhai = false;//勝敗が決まったか  false= また終わっていない。 true= 終わった
    public bool WINER;  //L1がかったらtrue、L2がかったらfalse
    bool chack = false; //消す処理や勝敗を表示する処理が行われたかチェック

//--------------------------------------------------------------------------------------
//最初の準備
    void Start()
    {
        Application.targetFrameRate = 240; //FPSを240に設定 
    }

//--------------------------------------------------------------------------------------
//ゲームの勝敗に関する処理と弾の後処理

    private void Update()
    {

        
        if (syouhai)
        {
            if (!chack)//勝敗がついたら消去開始
            {
                zenkesi();

                if (WINER)
                {
                    syouhai_text_L1.text = "WIN";          //表示するよ
                    syouhai_text_L2.text = "LOSE";          //表示するよ
                }
                else
                {
                    syouhai_text_L1.text = "LOSE";          //表示するよ
                    syouhai_text_L2.text = "WIN";          //表示するよ
                }
                chack = true;   //処理が終わったよ
            }
        }
    }
    //消去の中身
    void zenkesi()
    {
        //ありとあらゆる弾を一つにまとめる
        GameObject[] Bullets = GameObject.FindGameObjectsWithTag("Bullet");
        Clean(Bullets);
        Bullets = GameObject.FindGameObjectsWithTag("Bullet_1");
        Clean(Bullets);
        Bullets = GameObject.FindGameObjectsWithTag("Bullet_2");
        Clean(Bullets);
        Bullets = GameObject.FindGameObjectsWithTag("Bullet_3");
        Clean(Bullets);
    }
    //消すぜえええええ
    void Clean(GameObject[] Bullets)
    {
        foreach (GameObject AllBullet in Bullets)
        {
            //ありとあらゆる弾を破壊
            Destroy(AllBullet);
        }
    }
}
