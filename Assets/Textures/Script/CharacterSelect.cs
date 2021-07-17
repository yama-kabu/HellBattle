using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterSelect : MonoBehaviour
{
    [SerializeField] GameObject Panel1;
    [SerializeField] GameObject Panel2;
    [SerializeField] GameObject Panel3;
    
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
                DataManager.Character = 1;
            }
        }

        else if (Panel2.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                DataManager.Character = 2;
            }
        }

        else if (Panel3.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                DataManager.Character = 3;
            }
        }
    }
}
