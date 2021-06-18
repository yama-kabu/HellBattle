using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Cross : MonoBehaviour
{
    public bool houkou = false;
    // Update is called once per frame
    void Update()
    {
        
        {
            var vec = GetComponent<Rigidbody2D>().velocity;
            if (houkou)
            {
                vec = Quaternion.Euler(0, 0, 100) * vec;
            }
            else if (!houkou)
            {
                vec = Quaternion.Euler(0, 0, -100) * vec;
            }
            GetComponent<Rigidbody2D>().velocity = vec;
        }
        //var q = Quaternion.Euler(0, 0, -Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg);
        //transform.rotation = q;
    }
}
