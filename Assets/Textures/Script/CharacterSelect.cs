using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] GameObject Panel1;
    [SerializeField] GameObject Panel2;
    [SerializeField] GameObject Panel3;

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Panel1.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                
            }
        }

        else if (Panel2.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                
            }
        }

        else if (Panel3.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                
            }
        }
    }
}
