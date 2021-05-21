using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_R : MonoBehaviour
{
    //private Vector2 player_pos;
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float maxY2 =3.77f, minY2 = -3.77f,maxX2 = 7.26f,minX2 = 2.74f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {

        //もし上矢印キーが押されたら
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Vector3型のplayerPosに現在の位置情報を格納
            Vector3 playerPos = transform.position;
            //y座標にspeedを加算
            playerPos.y += speed * Time.deltaTime;

            //追加
            //もしplayerPosのY座標がmaxY（最大Y座標）より大きくなったら
            if (maxY2 < playerPos.y)
            {
                //PlayerPosのY座標にmaxYを代入
                playerPos.y = maxY2;
            }
            //現在の位置情報に反映させる
            transform.position = playerPos;

        }

        //もし下矢印キーが押されたら
        else if (Input.GetKey(KeyCode.DownArrow))
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

        //もし右矢印キーが押されたら
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Vector3型のplayerPosに現在の位置情報を格納
            Vector3 playerPos = transform.position;
            //y座標にspeedを加算
            playerPos.x += speed * Time.deltaTime;

            //追加
            //もしplayerPosのY座標がmaxY（最大Y座標）より大きくなったら
            if (maxX2 < playerPos.x)
            {
                //PlayerPosのY座標にmaxYを代入
                playerPos.x = maxX2;
            }
            //現在の位置情報に反映させる
            transform.position = playerPos;

        }

        //もし左矢印キーが押されたら
        else if (Input.GetKey(KeyCode.LeftArrow))
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
