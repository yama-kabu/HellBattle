using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Way : Shot_Common
{
//--------------------------------------------------------------------------------------
//�ړ�

    void Update()
    {
        transform.Translate(0, bullet_Speed * 0.01f, 0);    //�e�𔭎˂����
    }
}
