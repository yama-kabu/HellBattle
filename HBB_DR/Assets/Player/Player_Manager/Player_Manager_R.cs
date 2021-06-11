//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager_R : MonoBehaviour
{
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D Player_R;
 
    public float m_Player_MAXHP;
    public float m_Player_HP;


//--------------------------------------------------------------------------------------

    // ゲームのスタート時の処理
    void Start()
    {
        //Rigidbody2D　コンポーネントを取得して変数　Player_R　に格納
        Player_R = GetComponent<Rigidbody2D>();
        m_Player_MAXHP = 100;
        m_Player_HP = m_Player_MAXHP;

    }

    //--------------------------------------------------------------------------------------
    public void Damage(float damage)
    {
        //現在の体力からダメージを引く
        m_Player_HP -= damage;
        Debug.Log(damage + "ダメージを受けて残り" + m_Player_HP + "です");
        //体力が０以下の場合
        if (m_Player_HP < 0)
        {
            m_Player_HP = 0; 
            //Destroy(this.gameObject);
        }
    }
//--------------------------------------------------------------------------------------



//--------------------------------------------------------------------------------------
}
