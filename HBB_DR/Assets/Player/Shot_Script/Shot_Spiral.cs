//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Spiral : MonoBehaviour
{
    public float Bullet03;

    public GameObject Stage;
    // Start is called before the first frame update
    void Start()
    {
        //�����蔻��@��
        BoxCollider2D Hit_Wall = Stage.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, Bullet03, 0);
    }
    void OnTriggerExit2D(Collider2D BD)
    {
        if (BD.gameObject.tag == "BuckStage")
        {
            Destroy(this.gameObject);
        }

    }
}
