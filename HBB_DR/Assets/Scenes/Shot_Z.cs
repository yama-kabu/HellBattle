using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Z : MonoBehaviour
{
    public float BulletSpeed;

    public GameObject HitZone;
    
    void Start()
    {
        //�����蔻��@��
        BoxCollider2D HitWall = HitZone.GetComponent<BoxCollider2D>();
    }

//--------------------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, BulletSpeed, 0);    
    }

//--------------------------------------------------------------------------------------

    void OnTriggerExit2D(Collider2D BulletDestroy) 
    {
        //��ʊO�ɏo���ꍇ�폜�̔���
        if (BulletDestroy.gameObject.name == "PlayerZone2")
        {
            //�I�u�W�F�N�g�̍폜
            Destroy(this.gameObject);

        }

    }
}
