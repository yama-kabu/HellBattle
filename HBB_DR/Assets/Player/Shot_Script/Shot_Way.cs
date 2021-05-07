//Éã
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Way : MonoBehaviour
{
    public float Bullet02;

    public GameObject Stage;
    
    void Start()
    {
        //ìñÇΩÇËîªíËÅ@ï«
        BoxCollider2D Hit_Wall = Stage.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, Bullet02, 0);   

    }
    void OnTriggerExit2D(Collider2D BD) 
    {
        if (BD.gameObject.tag == "BuckStage")
        {
            Destroy(this.gameObject);
        }
    }
}
