using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Normal : MonoBehaviour
{
    public float BulletSpeed;

    //当たり判定対象
    public GameObject HitZone1;
    public GameObject HitZone2;

    void Start()
    {
        //当たり判定　壁
        BoxCollider2D HitWall1 = HitZone1.GetComponent<BoxCollider2D>();
        //当たり判定　壁
        BoxCollider2D HitWall2 = HitZone2.GetComponent<BoxCollider2D>();
    }

//--------------------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, BulletSpeed, 0);    
    }

//--------------------------------------------------------------------------------------
    //画面外で削除処理
    void OnTriggerExit2D(Collider2D BulletDestroy) 
    {
        //画面外に出た場合削除の判定
        if (BulletDestroy.gameObject.name == "PlayerZone1")
        {
            //オブジェクトの削除
            Destroy(this.gameObject);

        }
        //画面外に出た場合削除の判定
        if (BulletDestroy.gameObject.name == "PlayerZone2")
        {
            //オブジェクトの削除
            Destroy(this.gameObject);

        }

    }

//--------------------------------------------------------------------------------------


}
