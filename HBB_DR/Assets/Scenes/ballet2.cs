using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballet2 : MonoBehaviour
{
    public float ballet02;

    public GameObject Stage;
    
    void Start()
    {
        //ìñÇΩÇËîªíËÅ@ï«
        BoxCollider2D BOX1 = Stage.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, ballet02, 0); 
        

        
    }
    void OnTriggerExit2D(Collider2D BD) 
    {
        if (BD.gameObject.name == "Square2")
        {
            Destroy(this.gameObject);
        }
    }
}
