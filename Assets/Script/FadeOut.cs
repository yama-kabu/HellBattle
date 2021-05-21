using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    float alfa;
    public float speed = 1f;
    [SerializeField]
    GameObject Fade;
    float red, green, blue;

    // Start is called before the first frame update
    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        alfa = 0;
        Fade.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "TitleScene")
        {
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                Fade.SetActive(true);
                GetComponent<Image>().color = new Color(red, green, blue, alfa);

                alfa += speed;
            }
        }
    }
}
