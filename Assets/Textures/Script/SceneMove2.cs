using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove2 : MonoBehaviour
{


    private void Awake()
    {
        DontDestroyOnLoad(this);//アタッチしたやつを消えないようにする
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "CharacterSelectScene2")
        {
            if (Input.GetKey(KeyCode.Z))
            {
                SceneManager.LoadScene("ButtleScene");

            }
            if (Input.GetKey(KeyCode.X))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
        
    }
}
