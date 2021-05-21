using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelSwitch : MonoBehaviour
{
    [SerializeField] GameObject Panel1;
    [SerializeField] GameObject Panel2;
    [SerializeField] GameObject Panel3;

    // Start is called before the first frame update
    void Start()
    {
        Panel1.SetActive(true);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Panel1.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Panel1.SetActive(false);
                Panel2.SetActive(true);
            }
        }

        else if(Panel2.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Panel1.SetActive(true);
                Panel2.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Panel2.SetActive(false);
                Panel3.SetActive(true);
            }
        }

        else if(Panel3.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Panel2.SetActive(true);
                Panel3.SetActive(false);
            }
        }
    }
   
}
