using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TateScroll : MonoBehaviour
{
    //スクロールスピード
    [SerializeField] float speed = 100;

    void Update()
    {
        //下方向にスクロール
        transform.position -= new Vector3(0, Time.deltaTime * speed);

        //Yが-1699まで来れば、1685まで移動する
        if (transform.position.y <= -1699f)
        {
            transform.position = new Vector2(0, 1685f);
        }

    }
}
