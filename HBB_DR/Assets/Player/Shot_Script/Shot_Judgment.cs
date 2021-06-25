//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Judgment : MonoBehaviour
{
    public float damage;

    //弾の速度
    public float Shot_Speed = 0;

    public GameObject Stage;


//--------------------------------------------------------------------------------------

    void Start()
    {
        //当たり判定　壁
        BoxCollider2D Hit_Wall = Stage.GetComponent<BoxCollider2D>();

    }

//--------------------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, Shot_Speed * 0.01f, 0);   

    }

//--------------------------------------------------------------------------------------

    void OnTriggerExit2D(Collider2D BD) 
    {
        if (BD.gameObject.tag == "BuckStage")
        {

            Destroy(this.gameObject);
        }
    }

//--------------------------------------------------------------------------------------

    void OnTriggerEnter2D(Collider2D BD)
    {

        if (BD.gameObject.tag == "Hit_Body_P1" || BD.gameObject.tag == "Hit_Body_P2")
        {
            //Player_Manager_Rの中をさがす
            if (BD.gameObject.GetComponent<Player_Manager_R>())
            {
                //ダメージ変数に弾が持っているダメージを代入
                BD.gameObject.GetComponent<Player_Manager_R>().Damage(damage);
            }
            Destroy(this.gameObject);
        }
        if (BD.gameObject.tag == "Barrier")
        {
            Destroy(this.gameObject);
        }
        if (BD.gameObject.tag == "Absorption")
        {
            Destroy(this.gameObject);
        }

    }
}
