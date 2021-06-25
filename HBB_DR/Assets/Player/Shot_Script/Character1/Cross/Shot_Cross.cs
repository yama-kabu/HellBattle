using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Cross : MonoBehaviour
{
    public bool houkou;
    public float kaiten = 0.4f;

    // Update is called once per frame
    void Update()
    {
        

        // 指定された方向に向きを変える
        {

            if (houkou)
            {
                transform.Rotate(new Vector3(0, 0, kaiten));
            }
            else if (!houkou)
            {
                transform.Rotate(new Vector3(0, 0, -kaiten));

            }
            
        }
    }
}
