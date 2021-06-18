using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeelController : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject StageL;
    public GameObject StageR;
    public int HeelPoint;
    public float FallSpeed;
    private Rigidbody2D rb;

    Player_Manager_R PlayerManager;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x , -FallSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Player1 || collision.gameObject == Player2)
        {
            GameObject Player = collision.gameObject;
            PlayerManager = Player.GetComponent<Player_Manager_R>();
            
            //体力回復
            PlayerManager.Player_HP += HeelPoint;
            Debug.Log(PlayerManager.Player_HP);

            //オーバーしたら
            if (PlayerManager.Player_HP > PlayerManager.Player_MAXHP)
            {
                PlayerManager.Player_HP = PlayerManager.Player_MAXHP;
            }
            Debug.Log(PlayerManager.Player_HP);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D colision)
    {
        
    }

}
