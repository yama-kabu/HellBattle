using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Way : Shot_Common
{
//--------------------------------------------------------------------------------------
//移動

    void Update()
    {
        transform.Translate(0, bullet_Speed * 0.01f, 0);    //弾を発射するよ
    }
}
