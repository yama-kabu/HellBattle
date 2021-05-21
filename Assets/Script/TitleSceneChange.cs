using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneChange : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       TitleChange();
    }

    public void TitleChange()
    {
        if (Input.GetKey(KeyCode.A))
        {
            SceneManager.LoadScene("CharacterSelectScene1");
        }
    }
}
