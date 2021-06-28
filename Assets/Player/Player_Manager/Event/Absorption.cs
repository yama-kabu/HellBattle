//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorption : MonoBehaviour
{
    public GameObject pl;
    //ダメージ変数受け取り
    float damage;
    //ダメージ計算後受け取り
    float ans;
    // Start is called before the first frame update
    void Start()
    {
        //初期化
        damage = 0;
        ans = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

//--------------------------------------------------------------------------------------

    void OnTriggerEnter2D(Collider2D BD)
    {
        //初期化
        ans = 0;
        damage = 0;
        if (BD.gameObject.tag == "Bullet_1" || BD.gameObject.tag == "Bullet_2" || BD.gameObject.tag == "Bullet_3")
        {
            if (BD.gameObject.GetComponent<Shot_Judgment>())
            {
                damage = BD.gameObject.GetComponent<Shot_Judgment>().damage;
            }
            else if (BD.gameObject.GetComponent<Shot_Explosion_ed>())
            {
                damage = BD.gameObject.GetComponent<Shot_Explosion_ed>().damage;
            }
            else if (BD.gameObject.GetComponent<Shot_Homing>())
            {
                damage = BD.gameObject.GetComponent<Shot_Homing>().damage;
            }
            else if (BD.gameObject.GetComponent<Shot_Random_Homing>())
            {
                damage = BD.gameObject.GetComponent<Shot_Random_Homing>().damage;
            }
            else if (BD.gameObject.GetComponent<Shot_ReflectP1>())
            {
                damage = BD.gameObject.GetComponent<Shot_ReflectP1>().damage;
            }
            else if (BD.gameObject.GetComponent<Shot_ReflectP2>())
            {
                damage = BD.gameObject.GetComponent<Shot_ReflectP2>().damage;
            }

//--------------------------------------------------------------------------------------

            //弾のダメージを四分の一に
            ans = (damage / 4);
            //回復
            pl.GetComponent<Player_Manager_R>().m_Player_HP += ans;
        }
    }
}
