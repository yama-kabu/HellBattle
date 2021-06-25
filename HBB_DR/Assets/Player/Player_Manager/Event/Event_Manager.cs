using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject Barrier;
    [SerializeField] 
    GameObject Absorption;

    public bool B_Switch = false;
    public bool HPSwitch = false;

    public int barrie_kaisu;
    int Protection;

    private void Start()
    {
        //������
        Barrier.SetActive(false);
        Absorption.SetActive(false);
        

    }

    void Update()
    {
        if (B_Switch)
        {
            if (Barrier.activeSelf == false)
            {
                //�o���A�I��
                Barrier.SetActive(true);
                Protection = barrie_kaisu;
            }

        }
        else if (!B_Switch || Protection == 0)
        {
            if (Barrier.activeSelf == true)
            {
                //�o���A�I�t
                Barrier.SetActive(false);
            }
        }



        if (HPSwitch)
        {
            if (Absorption.activeSelf == false)
            {
                //�z���I��
                Absorption.SetActive(true);
            }
        }
        else if (!HPSwitch || Protection == 0)
        {
            if (Absorption.activeSelf == true)
            {
                //�z���I�t
                Absorption.SetActive(false);
            }
        }
    }
}
