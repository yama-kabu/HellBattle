//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Judgment : MonoBehaviour
{
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

        transform.Translate(0, Shot_Speed, 0);   

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

        if (BD.gameObject.tag == "Player_R1" || BD.gameObject.tag == "Player_R2")
        {

            Destroy(this.gameObject);
        }

    }

//--------------------------------------------------------------------------------------

}
