using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SceneManager.LoadScene("CharacterSelectScene1");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SceneManager.LoadScene("CharacterSelectScene3");
        }
    }
}