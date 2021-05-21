using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_L : MonoBehaviour
{
    //private Vector2 player_pos;
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float maxY = 3.74f, minY = -3.74f,maxX = -2.74f,minX = -7.27f;

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
        if (Input.GetKey(KeyCode.W))
        {
            //Vector3型のplayerPosに現在の位置情報を格納
            Vector3 playerPos = transform.position; 
            //y座標にspeedを加算
            playerPos.y += speed * Time.deltaTime; 

            //追加
            //もしplayerPosのY座標がmaxY（最大Y座標）より大きくなったら
            if (maxY < playerPos.y)
            {
                //PlayerPosのY座標にmaxYを代入
                playerPos.y = maxY; 
            }
            //現在の位置情報に反映させる
            transform.position = playerPos; 

        }

        //もし下矢印キーが押されたら
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 playerPos = transform.position;
            playerPos.y -= speed * Time.deltaTime;

            //追加
            if (minY > playerPos.y)
            {
                playerPos.y = minY;
            }
            transform.position = playerPos;
        }

        //もし右矢印キーが押されたら
        if (Input.GetKey(KeyCode.D))
        {
            //Vector3型のplayerPosに現在の位置情報を格納
            Vector3 playerPos = transform.position; 
            //y座標にspeedを加算
            playerPos.x += speed * Time.deltaTime; 

            //追加
            //もしplayerPosのY座標がmaxY（最大Y座標）より大きくなったら
            if (maxX < playerPos.x)
            {
                //PlayerPosのY座標にmaxYを代入
                playerPos.x = maxX; 
            }
            //現在の位置情報に反映させる
            transform.position = playerPos; 

        }

        //もし左矢印キーが押されたら
        else if (Input.GetKey(KeyCode.A))　
        {
            Vector3 playerPos = transform.position;
            playerPos.x -= speed * Time.deltaTime;

            //追加
            if (minX > playerPos.x)
            {
                playerPos.x = minX;
            }
            transform.position = playerPos;
        }
    }
}
