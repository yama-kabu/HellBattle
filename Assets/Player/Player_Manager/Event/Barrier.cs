//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public Event_Manager barrier;
    private void Update()
    {


        if (barrier.Protection == 0)
        {
            //バリアで守る回数を初期化
            barrier.Protection = 0;
            //defenseを初期化
            barrier.defense = false;
            //バリアオフ
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D BD)
    {
        if (BD.gameObject.tag == "Bullet_1" || BD.gameObject.tag == "Bullet_2" || BD.gameObject.tag == "Bullet_3")
        {
            //Protectionマイナス
            barrier.Protection--;
        }
    }
}
