using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    //スピード
    [SerializeField]
    private float speed = 3;

    [SerializeField]
    public float maxY, maxX, minY, minX;


    private Rigidbody2D rd;

//--------------------------------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        if (this.gameObject.CompareTag("Player_L1"))
        {
            //L1
            maxY = -2.6f; minY = -3.77f; maxX = 7.26f; minX = 2.74f;
        }
        else if (this.gameObject.CompareTag("Player_R2"))
        {
            //R2
            maxY = 3.77f; minY = -3.77f; maxX = 7.26f; minX = 2.74f;
        }

        else if (this.gameObject.CompareTag("Player_L2"))
        {
            //L2
            maxY = 3.74f; minY = 2.6f; maxX = -2.74f; minX = -7.27f;
        }
        else if (this.gameObject.CompareTag("Player_R1"))
        {
            //R1
            maxY = 3.74f; minY = -3.74f; maxX = -2.74f; minX = -7.27f;
        }



    }

//--------------------------------------------------------------------------------------

    void Update()
    {
        if(this.gameObject.CompareTag("Player_L1"))
        {
            MovePlayer_L1();
        }
        else if(this.gameObject.CompareTag("Player_L2"))
        {
            MovePlayer_L2();
        }
        else if(this.gameObject.CompareTag("Player_R1"))
        {
            MovePlayer_R1();
        }
        else if(this.gameObject.CompareTag("Player_R2"))
        {
            MovePlayer_R2();
        }
    }

//--------------------------------------------------------------------------------------

    void MovePlayer_L1()
    {
        //もし上矢印キーが押されたら
        if (Input.GetAxisRaw("Vertical_L1") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3型のplayerPosに現在の位置情報を格納
            playerPos.y += speed * Time.deltaTime; //y座標にspeedを加算

            //追加
            //もしplayerPosのY座標がmaxY（最大Y座標）より大きくなったら
            if (maxY < playerPos.y)
            {
                playerPos.y = maxY; //PlayerPosのY座標にmaxYを代入
            }
            transform.position = playerPos; //現在の位置情報に反映させる

        }
        //もし下矢印キーが押されたら
        else if (Input.GetAxisRaw("Vertical_L1") < 0)　
        {
            Vector3 playerPos = transform.position;
            //通常移動
            playerPos.y -= speed * Time.deltaTime;
            //追加
            if (minY > playerPos.y)
            {
                playerPos.y = minY;
            }
            transform.position = playerPos;
        }

        //もし上矢印キーが押されたら
        if (Input.GetAxisRaw("Horizontal_L1") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3型のplayerPosに現在の位置情報を格納
            //通常移動
            playerPos.x += speed * Time.deltaTime; //y座標にspeedを加算

            //追加
            //もしplayerPosのY座標がmaxY（最大Y座標）より大きくなったら
            if (maxX < playerPos.x)
            {
                playerPos.x = maxX; //PlayerPosのY座標にmaxYを代入
            }
            transform.position = playerPos; //現在の位置情報に反映させる

        }
        else if (Input.GetAxisRaw("Horizontal_L1") < 0)　//もし下矢印キーが押されたら
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

//--------------------------------------------------------------------------------------

    void MovePlayer_L2()
    {
        //もし上矢印キーが押されたら
        if (Input.GetAxisRaw("Vertical_L2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3型のplayerPosに現在の位置情報を格納
            //通常移動
            playerPos.y += speed * Time.deltaTime; //y座標にspeedを加算

            //追加
            //もしplayerPosのY座標がmaxY（最大Y座標）より大きくなったら
            if (maxY < playerPos.y)
            {
                playerPos.y = maxY; //PlayerPosのY座標にmaxYを代入
            }
            transform.position = playerPos; //現在の位置情報に反映させる

        }
        //もし下矢印キーが押されたら
        else if (Input.GetAxisRaw("Vertical_L2") < 0)
        {
            Vector3 playerPos = transform.position;
            //通常移動
            playerPos.y -= speed * Time.deltaTime;

            //追加
            if (minY > playerPos.y)
            {
                playerPos.y = minY;
            }
            transform.position = playerPos;
        }

        //もし上矢印キーが押されたら
        if (Input.GetAxisRaw("Horizontal_L2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3型のplayerPosに現在の位置情報を格納
            //通常移動
            playerPos.x += speed * Time.deltaTime; //y座標にspeedを加算
            
            //追加
            //もしplayerPosのY座標がmaxY（最大Y座標）より大きくなったら
            if (maxX < playerPos.x)
            {
                playerPos.x = maxX; //PlayerPosのY座標にmaxYを代入
            }
            transform.position = playerPos; //現在の位置情報に反映させる

        }
        else if (Input.GetAxisRaw("Horizontal_L2") < 0)　//もし下矢印キーが押されたら
        {
            Vector3 playerPos = transform.position;
            //通常移動
            playerPos.x -= speed * Time.deltaTime;

            //追加
            if (minX > playerPos.x)
            {
                playerPos.x = minX;
            }
            transform.position = playerPos;
        }
    }

//--------------------------------------------------------------------------------------

    void MovePlayer_R1()
    {
        //もし上矢印キーが押されたら
        if (Input.GetAxisRaw("Vertical_R1") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3型のplayerPosに現在の位置情報を格納
            //減速移動
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerPos.y += (speed * 0.4f) * Time.deltaTime; //y座標にspeedを加算
            }
            //通常移動
            else
            {
                playerPos.y += speed * Time.deltaTime; //y座標にspeedを加算
            }

            //追加
            //もしplayerPosのY座標がmaxY（最大Y座標）より大きくなったら
            if (maxY < playerPos.y)
            {
                playerPos.y = maxY; //PlayerPosのY座標にmaxYを代入
            }
            transform.position = playerPos; //現在の位置情報に反映させる

        }
        //もし下矢印キーが押されたら
        else if (Input.GetAxisRaw("Vertical_R1") < 0)
        {
            Vector3 playerPos = transform.position;
            //減速移動
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerPos.y -= (speed * 0.4f) * Time.deltaTime; //y座標にspeedを加算
            }
            //通常移動
            else
            {
                playerPos.y -= speed * Time.deltaTime;
            }
            //追加
            if (minY > playerPos.y)
            {
                playerPos.y = minY;
            }
            transform.position = playerPos;
        }

        //もし上矢印キーが押されたら
        if (Input.GetAxisRaw("Horizontal_R1") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3型のplayerPosに現在の位置情報を格納
            //減速移動
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerPos.x += (speed * 0.4f) * Time.deltaTime; //y座標にspeedを加算
            }
            //通常移動
            else
            {
                playerPos.x += speed * Time.deltaTime; //y座標にspeedを加算
            }
            //追加
            //もしplayerPosのY座標がmaxY（最大Y座標）より大きくなったら
            if (maxX < playerPos.x)
            {
                playerPos.x = maxX; //PlayerPosのY座標にmaxYを代入
            }
            transform.position = playerPos; //現在の位置情報に反映させる

        }
        else if (Input.GetAxisRaw("Horizontal_R1") < 0)　//もし下矢印キーが押されたら
        {
            Vector3 playerPos = transform.position;
            //減速移動
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerPos.x -= (speed * 0.4f) * Time.deltaTime; //y座標にspeedを加算
            }
            //通常移動
            else
            {
                playerPos.x -= speed * Time.deltaTime;
            }
            //追加
            if (minX > playerPos.x)
            {
                playerPos.x = minX;
            }
            transform.position = playerPos;
        }
    }

//--------------------------------------------------------------------------------------

    void MovePlayer_R2()
    {
        //もし上矢印キーが押されたら
        if (Input.GetAxisRaw("Vertical_R2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3型のplayerPosに現在の位置情報を格納
            //減速移動
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerPos.y += (speed * 0.4f) * Time.deltaTime; //y座標にspeedを加算
            }
            //通常移動
            else
            {
                playerPos.y += speed * Time.deltaTime; //y座標にspeedを加算
            }

            //追加
            //もしplayerPosのY座標がmaxY（最大Y座標）より大きくなったら
            if (maxY < playerPos.y)
            {
                playerPos.y = maxY; //PlayerPosのY座標にmaxYを代入
            }
            transform.position = playerPos; //現在の位置情報に反映させる

        }
        //もし下矢印キーが押されたら
        else if (Input.GetAxisRaw("Vertical_R2") < 0)
        {
            Vector3 playerPos = transform.position;
            //減速移動
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerPos.y -= (speed * 0.4f) * Time.deltaTime; //y座標にspeedを加算
            }
            //通常移動
            else
            {
                playerPos.y -= speed * Time.deltaTime;
            }
            //追加
            if (minY > playerPos.y)
            {
                playerPos.y = minY;
            }
            transform.position = playerPos;
        }

        //もし上矢印キーが押されたら
        if (Input.GetAxisRaw("Horizontal_R2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3型のplayerPosに現在の位置情報を格納
            //減速移動
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerPos.x += (speed * 0.4f) * Time.deltaTime; //y座標にspeedを加算
            }
            //通常移動
            else
            {
                playerPos.x += speed * Time.deltaTime; //y座標にspeedを加算
            }
            //追加
            //もしplayerPosのY座標がmaxY（最大Y座標）より大きくなったら
            if (maxX < playerPos.x)
            {
                playerPos.x = maxX; //PlayerPosのY座標にmaxYを代入
            }
            transform.position = playerPos; //現在の位置情報に反映させる

        }
        else if (Input.GetAxisRaw("Horizontal_R2") < 0)　//もし下矢印キーが押されたら
        {
            Vector3 playerPos = transform.position;
            //減速移動
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerPos.x -= (speed * 0.4f) * Time.deltaTime; //y座標にspeedを加算
            }
            //通常移動
            else
            {
                playerPos.x -= speed * Time.deltaTime;
            }
            //追加
            if (minX > playerPos.x)
            {
                playerPos.x = minX;
            }
            transform.position = playerPos;
        }
    }

//--------------------------------------------------------------------------------------


}



