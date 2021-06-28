//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public Event_Manager barrier;
    private void Update()
    {


        if (barrier.Protection == 0)
        {
            //�o���A�Ŏ��񐔂�������
            barrier.Protection = 0;
            //defense��������
            barrier.defense = false;
            //�o���A�I�t
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D BD)
    {
        if (BD.gameObject.tag == "Bullet_1" || BD.gameObject.tag == "Bullet_2" || BD.gameObject.tag == "Bullet_3")
        {
            //Protection�}�C�i�X
            barrier.Protection--;
        }
    }
}
