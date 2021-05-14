using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D Temporary_Enemy;
    //自機の移動速度を格納する変数（初期値５）
    public float Speed = 5;

    public int Enemy_MAXHP;
    public int Enemy_HP;

    //プレイヤー速度
    public Vector2 PlayerSpeed = new Vector2(0.005f, 0.005f);
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2D　コンポーネントを取得して変数　Player_L　に格納
        Temporary_Enemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        // 現在位置をPositionに代入
        Vector2 Position = transform.position;
        //斜め移動
        if (Input.GetKey(KeyCode.LeftArrow) & Input.GetKey(KeyCode.UpArrow))
        {
            //左上を押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.x -= PlayerSpeed.x;
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) & Input.GetKey(KeyCode.DownArrow))
        {
            //左下を押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.x -= PlayerSpeed.x;
            Position.y -= PlayerSpeed.y;
        }
        else if (Input.GetKey(KeyCode.RightArrow) & Input.GetKey(KeyCode.UpArrow))
        {
            //左上を押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.x += PlayerSpeed.x;
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey(KeyCode.RightArrow) & Input.GetKey(KeyCode.DownArrow))
        {
            //左下を押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.x += PlayerSpeed.x;
            Position.y -= PlayerSpeed.y;
        }

        //上下左右移動
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 左キーを押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.x -= PlayerSpeed.x;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // 右キーを押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.x += PlayerSpeed.x;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            // 上キーを押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // 下キーを押し続けていたら
            // 代入したPositionに対して加算減算を行う
            Position.y -= PlayerSpeed.y;
        }
        // 現在の位置に加算減算を行ったPositionを代入する
        transform.position = Position;
    }
}
