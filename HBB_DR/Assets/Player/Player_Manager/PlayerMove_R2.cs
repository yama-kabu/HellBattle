using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_R2 : MonoBehaviour
{
    //private Vector2 player_pos;
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float maxY2 = 3.77f, minY2 = -3.77f, maxX2 = 7.26f, minX2 = 2.74f;
    private Rigidbody2D rd;

    //--------------------------------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    //--------------------------------------------------------------------------------------

    //左のキャラクター専用
    // Update is called once per frame
    void Update()
    {
        MovePlayer_R2();
    }
    void MovePlayer_R2()
    {
        //もし上矢印キーが押されたら
        if (Input.GetAxisRaw("Vertical_R2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3型のplayerPosに現在の位置情報を格納
            playerPos.y += speed * Time.deltaTime; //y座標にspeedを加算

            //追加
            //もしplayerPosのY座標がmaxY（最大Y座標）より大きくなったら
            if (maxY2 < playerPos.y)
            {
                playerPos.y = maxY2; //PlayerPosのY座標にmaxYを代入
            }
            transform.position = playerPos; //現在の位置情報に反映させる

        }
        else if (Input.GetAxisRaw("Vertical_R2") < 0) //もし下矢印キーが押されたら
        {
            Vector3 playerPos = transform.position;
            playerPos.y -= speed * Time.deltaTime;

            //追加
            if (minY2 > playerPos.y)
            {
                playerPos.y = minY2;
            }
            transform.position = playerPos;
        }

        //もし上矢印キーが押されたら
        if (Input.GetAxisRaw("Horizontal_R2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3型のplayerPosに現在の位置情報を格納
            playerPos.x += speed * Time.deltaTime; //y座標にspeedを加算

            //追加
            //もしplayerPosのY座標がmaxY（最大Y座標）より大きくなったら
            if (maxX2 < playerPos.x)
            {
                playerPos.x = maxX2; //PlayerPosのY座標にmaxYを代入
            }
            transform.position = playerPos; //現在の位置情報に反映させる

        }
        else if (Input.GetAxisRaw("Horizontal_R2") < 0) //もし下矢印キーが押されたら
        {
            Vector3 playerPos = transform.position;
            playerPos.x -= speed * Time.deltaTime;

            //追加
            if (minX2 > playerPos.x)
            {
                playerPos.x = minX2;
            }
            transform.position = playerPos;
        }
    }
}

