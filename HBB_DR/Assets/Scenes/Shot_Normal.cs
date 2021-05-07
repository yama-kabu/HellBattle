using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Normal : MonoBehaviour
{
    public float BulletSpeed;

    //�����蔻��Ώ�
    public GameObject HitZone1;
    public GameObject HitZone2;

    void Start()
    {
        //�����蔻��@��
        BoxCollider2D HitWall1 = HitZone1.GetComponent<BoxCollider2D>();
        //�����蔻��@��
        BoxCollider2D HitWall2 = HitZone2.GetComponent<BoxCollider2D>();
    }

//--------------------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, BulletSpeed, 0);    
    }

//--------------------------------------------------------------------------------------
    //��ʊO�ō폜����
    void OnTriggerExit2D(Collider2D BulletDestroy) 
    {
        //��ʊO�ɏo���ꍇ�폜�̔���
        if (BulletDestroy.gameObject.name == "PlayerZone1")
        {
            //�I�u�W�F�N�g�̍폜
            Destroy(this.gameObject);

        }
        //��ʊO�ɏo���ꍇ�폜�̔���
        if (BulletDestroy.gameObject.name == "PlayerZone2")
        {
            //�I�u�W�F�N�g�̍폜
            Destroy(this.gameObject);

        }

    }

//--------------------------------------------------------------------------------------


}
