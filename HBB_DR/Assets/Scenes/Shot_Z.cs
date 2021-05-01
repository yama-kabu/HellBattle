using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Z : MonoBehaviour
{
    public float BulletSpeed;

    public GameObject HitZone;
    
    void Start()
    {
        //当たり判定　壁
        BoxCollider2D HitWall = HitZone.GetComponent<BoxCollider2D>();
    }

//--------------------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, BulletSpeed, 0);    
    }

//--------------------------------------------------------------------------------------

    void OnTriggerExit2D(Collider2D BulletDestroy) 
    {
        //画面外に出た場合削除の判定
        if (BulletDestroy.gameObject.name == "PlayerZone2")
        {
            //オブジェクトの削除
            Destroy(this.gameObject);

        }

    }
}
