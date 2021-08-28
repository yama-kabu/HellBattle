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

    public static int Player_Number;    //�L�����N�^�[�ԍ�

    // Start is called before the first frame update
    void Start()
    {
        Panel1.SetActive(true);
        Panel2.SetActive(false);
        Panel3.SetActive(false);

        Player_Number = 0;  //������ 
    }

    // Update is called once per frame
    void Update()
    {
        if (Panel1.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Panel1.SetActive(false);
                Panel2.SetActive(true);
            }

            if (Player_Number != 1)
            {
                Player_Number = 1;

            }
        }

        else if (Panel2.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Panel1.SetActive(true);
                Panel2.SetActive(false);
            }

            //if (Input.GetKeyDown(KeyCode.RightArrow))
            //{
            //    Panel2.SetActive(false);
            //    Panel3.SetActive(true);
            //}

            if (Player_Number != 2)
                Player_Number = 2;
        }

        //else if (Panel3.activeSelf)
        //{
        //    if (Input.GetKeyDown(KeyCode.LeftArrow))
        //    {
        //        Panel2.SetActive(true);
        //        Panel3.SetActive(false);
        //    }

        //    if (Player_Number != 3)
        //        Player_Number = 3;
        //}
    }
    public static int getA()
    {
        return Player_Number;
    }
}
