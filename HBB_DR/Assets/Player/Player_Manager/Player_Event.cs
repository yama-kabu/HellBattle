using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Event : MonoBehaviour
{
    //仮
    public bool B_Switch = false;
    public bool HPSwitch = false;

    private void Update()
    {
        if(B_Switch)
        {
            //バリアオン
            GetComponent<CircleCollider2D>().enabled = true;
        }
        if (!B_Switch)
        {
            //バリアオフ
            GetComponent<CircleCollider2D>().enabled = false;
        }



        if (HPSwitch)
        {
            //吸収オン
            GetComponent<CircleCollider2D>().enabled = true;
        }
        if (!HPSwitch)
        {
            //吸収オフ
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }

}
