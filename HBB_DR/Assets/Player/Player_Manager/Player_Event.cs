using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Event : MonoBehaviour
{
    //��
    public bool B_Switch = false;
    public bool HPSwitch = false;

    private void Update()
    {
        if(B_Switch)
        {
            //�o���A�I��
            GetComponent<CircleCollider2D>().enabled = true;
        }
        if (!B_Switch)
        {
            //�o���A�I�t
            GetComponent<CircleCollider2D>().enabled = false;
        }



        if (HPSwitch)
        {
            //�z���I��
            GetComponent<CircleCollider2D>().enabled = true;
        }
        if (!HPSwitch)
        {
            //�z���I�t
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }

}
