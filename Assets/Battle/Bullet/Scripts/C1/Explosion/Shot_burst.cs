using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_burst : Shot_Common
{
    void Update()
    {
        transform.Translate(0, bullet_Speed * 0.01f, 0);    //�e�𔭎˂����
    }
}
