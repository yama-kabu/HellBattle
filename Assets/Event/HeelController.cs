using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeelController : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public int HeelPoint;
    public float FallSpeed;
    private Rigidbody2D rb;

    Player_Manager_R PlayerManager;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        GameObject EMane = GameObject.Find("EventManager");
        Player1 = EMane.GetComponent<EventManager>().Player1;
        Player2 = EMane.GetComponent<EventManager>().Player2;
    }


    void FixedUpdate()
    {
        if(transform.position.x < 0)
        {
            Vector2 Move = new Vector2(0, -FallSpeed);
            rb.velocity = Move;
        }
        else if(transform.position.x >0)
        {
            Vector2 Move = new Vector2(0, FallSpeed);
            rb.velocity = Move;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Player1 || collision.gameObject == Player2)
        {
            GameObject Player = collision.gameObject;
            PlayerManager = Player.GetComponent<Player_Manager_R>();
            
            //体力回復
            PlayerManager.Player_HP += HeelPoint;
            Debug.Log(PlayerManager.Player_HP + "Heel");

            //オーバーしたら
            if (PlayerManager.Player_HP > PlayerManager.Player_MAXHP)
            {
                PlayerManager.Player_HP = PlayerManager.Player_MAXHP;
            }
            Debug.Log("体力は" + PlayerManager.Player_HP);
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
