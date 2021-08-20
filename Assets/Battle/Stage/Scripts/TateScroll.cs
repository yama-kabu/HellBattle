using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TateScroll : MonoBehaviour
{
    //�X�N���[���X�s�[�h
    [SerializeField] float speed = 100;
    public bool field_direction;   //false�Ȃ獶,true�Ȃ�E
    void Update()
    {
        //�������ɃX�N���[��
        transform.position -= new Vector3(0, Time.deltaTime * speed);
        if (!field_direction)
        {
            //Y��-1699�܂ŗ���΁A1685�܂ňړ�����
            if (transform.position.y <= -1699f)
            {
                transform.position = new Vector2(-898f, 1685f);
            }
        }
        if (field_direction)
        {
            //Y��1685�܂ŗ���΁A-1699�܂ňړ�����
            if (transform.position.y <= -1699f)
            {
                transform.position = new Vector2(898f, 1685f);
            }
        }


    }
}
