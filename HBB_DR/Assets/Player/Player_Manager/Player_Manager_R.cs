//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager_R : MonoBehaviour
{
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D Player_R;
 
    public float m_Player_MAXHP = 0;
    public float m_Player_HP = 0;


//--------------------------------------------------------------------------------------

    // ゲームのスタート時の処理
    void Start()
    {
        //Rigidbody2D　コンポーネントを取得して変数　Player_R　に格納
        Player_R = GetComponent<Rigidbody2D>();


        m_Player_MAXHP = 100;
        m_Player_HP = 100;

    }

//--------------------------------------------------------------------------------------

    // 繰り返す処理
    void Update()
    {
        //Debug.Log("残りの体力は" + m_Player_HP + "です");
        if (m_Player_HP < 0)
        {
            Destroy(this.gameObject);
        }
    }

//--------------------------------------------------------------------------------------
    public void Damage(float damage)
    {
        m_Player_HP -= damage;
    }


//--------------------------------------------------------------------------------------
}
