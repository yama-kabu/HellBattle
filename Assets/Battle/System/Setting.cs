//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//参照系

    //勝敗が決まったか  false= また終わっていない。 true= 終わった
    public bool syouhai = false;

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
        //勝敗がついたら消去開始
        if (syouhai)
        {
            zenkesi();
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
