using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Manager_R>())
        {
            //�^����_���[�W���L��
            collision.gameObject.GetComponent<Player_Manager_R>().Damage(1);
        }
    }
}
