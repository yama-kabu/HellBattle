//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn

    public GameObject em;   //Event_Manager�̒��ɂ���o���A��protection�̐������炷���߂ɎQ�Ƃ����

//--------------------------------------------------------------------------------------
//�o���A�̏���

    private void Update()
    {
        //�o���A�����񐔂�Protection���O��������
        if (em.GetComponent<Event_Manager>().Protection == 0)
        {
            em.GetComponent<Event_Manager>().defense = false;    //�o���A�����������
            this.gameObject.SetActive(false);   //�o���A���I�t�ɂ����
        }
    }

//--------------------------------------------------------------------------------------
//�o���A�̏���

    void OnTriggerEnter2D(Collider2D BD)
    {
        if (BD.gameObject.tag == "Bullet_1" || BD.gameObject.tag == "Bullet_2" || BD.gameObject.tag == "Bullet_3")
        {

            em.GetComponent<Event_Manager>().Protection--;   //Protection�i�c��̎��񐔁j���}�C�i�X
        }
    }

//--------------------------------------------------------------------------------------

}
