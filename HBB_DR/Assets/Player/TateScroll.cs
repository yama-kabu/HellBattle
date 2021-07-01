using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TateScroll : MonoBehaviour
{
    //スクロールスピード
    [SerializeField] float speed = 1;

    void Update()
    {
        //下方向にスクロール
        transform.position -= new Vector3(0, Time.deltaTime * speed);

        //Yが-2089まで来れば、4196まで移動する
        if (transform.position.y <= -2089f)
        {
            transform.position = new Vector2(0, 4196);
        }
    }
}
