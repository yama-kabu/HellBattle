using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Explosion_ed : MonoBehaviour
{
    public float damage;

    public GameObject Stage;





    void OnTriggerEnter2D(Collider2D BD)
    {

        if (BD.gameObject.tag == "Hit_Body_P1" || BD.gameObject.tag == "Hit_Body_P2")
        {
            //Player_Manager_R�̒���������
            if (BD.gameObject.GetComponent<Player_Manager_R>())
            {
                //�_���[�W�ϐ��ɒe�������Ă���_���[�W����
                BD.gameObject.GetComponent<Player_Manager_R>().Damage(damage);
            }
            Destroy(this.gameObject);
        }

        if (BD.gameObject.tag == "Barrier")
        {
            Destroy(this.gameObject);
        }
        if (BD.gameObject.tag == "Absorption")
        {
            Destroy(this.gameObject);
        }

    }

    void OnTriggerExit2D(Collider2D BD)
    {
        if (BD.gameObject.tag == "BuckStage")
        {

            Destroy(this.gameObject);
        }
    }
}
