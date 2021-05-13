using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Beem : MonoBehaviour
{
    private Vector2 lastVelocity;
    private Rigidbody2D Beem;
    public float Bullet04;
    public float Reflection_Number = 3;

    public GameObject Stage;
    private void Start()
    {
        //ìñÇΩÇËîªíËÅ@ï«
        BoxCollider2D Hit_Wall = Stage.GetComponent<BoxCollider2D>();

        this.Beem = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        this.lastVelocity = this.Beem.velocity;

        transform.Translate(0, Bullet04, 0);
    }

    void OnCollisionEnter2D(Collision2D BD)
    {
        if (BD.gameObject.tag == "BuckStage")
        {
            Vector2 refrectVec = Vector2.Reflect(this.lastVelocity, BD.contacts[0].normal);
            this.Beem.velocity = refrectVec;
            Destroy(this.gameObject);
        }
    }
  
    void OnTriggerExit2D(Collider2D BD) 
    {
        if (BD.gameObject.tag == "BuckStage")
        {

           // Vector2 refrectVec = Vector2.Reflect(this.lastVelocity, BD.contacts[0].normal);
           // this.Beem.velocity = refrectVec;

        }

    }


}
