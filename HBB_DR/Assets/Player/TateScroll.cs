using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TateScroll : MonoBehaviour
{
    //�X�N���[���X�s�[�h
    [SerializeField] float speed = 100;

    void Update()
    {
        //�������ɃX�N���[��
        transform.position -= new Vector3(0, Time.deltaTime * speed);

        //Y��-1699�܂ŗ���΁A1685�܂ňړ�����
        if (transform.position.y <= -1699f)
        {
            transform.position = new Vector2(0, 1685f);
        }

    }
}
