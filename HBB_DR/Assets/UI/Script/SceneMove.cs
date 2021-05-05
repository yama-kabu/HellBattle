using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            SceneManager.LoadScene("GameScene");
        }
        if(Input.GetKey(KeyCode.X))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
