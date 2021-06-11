//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Judgment : MonoBehaviour
{
    //�e�̑��x
    public float Shot_Speed = 0;

    public GameObject Stage;


//--------------------------------------------------------------------------------------
    //�_���[�W�v�Z�n��

    //��{�_���[�W
    public float Damage;

//--------------------------------------------------------------------------------------

    void Start()
    {
        //�����蔻��@��
        BoxCollider2D Hit_Wall = Stage.GetComponent<BoxCollider2D>();

    }

//--------------------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, Shot_Speed, 0);   

    }

//--------------------------------------------------------------------------------------

    void OnTriggerExit2D(Collider2D BD) 
    {
        if (BD.gameObject.tag == "BuckStage")
        {

            Destroy(this.gameObject);
        }
    }

//--------------------------------------------------------------------------------------

    void OnTriggerEnter2D(Collider2D BD)
    {

        if (BD.gameObject.tag == "Hit_Body_P1" || BD.gameObject.tag == "Hit_Body_P2")
        {

            Destroy(this.gameObject);
        }
    }

//--------------------------------------------------------------------------------------

}
