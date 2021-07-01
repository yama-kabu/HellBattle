//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject Barrier;
    [SerializeField] 
    GameObject Absorption;

    //�o���A�p
    public bool B_Switch;
    //�z���p
    public bool HPSwitch;

    public bool defense = false;
    //�o���A�Ŏ���
    public int barrie_kaisu;
    //�o���A�Ŏ��񐔂����s����ۂɎg�����
    public int Protection;

//--------------------------------------------------------------------------------------
//�o���A

    private void Start()
    {
        Protection = barrie_kaisu;
        //������
        //Barrier.SetActive(false);
        //Absorption.SetActive(false);
    }

    void Update()
    {
        if(defense == true)
        {
            Debug.Log(Protection);
            if(Protection <= 0)
            {
                //�o���A�I�t
                Barrier.SetActive(false);
            }
        }
        else if (B_Switch)
        {
            if (Barrier.activeSelf == false)
            {
                //�o���A�I��
                Barrier.SetActive(true);
                //�o���A�Ŏ��񐔂�ݒ�
                Protection = barrie_kaisu;
                defense = true;
            }

        }
        else if (!B_Switch)
        {
            if (Barrier.activeSelf == true)
            {
                Barrier.SetActive(false);
            }
        }

//--------------------------------------------------------------------------------------
//�z��
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
