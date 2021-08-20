//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Manager : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn 

    [SerializeField]
    GameObject Barrier; //�o���A�̃I�u�W�F�N�g�������
    [SerializeField] 
    GameObject Absorption;  //�z���̃I�u�W�F�N�g�������

//--------------------------------------------------------------------------------------
//�ϐ��n

    public int barrier_number;    //�o���A�Ŏ��񐔂��w��ł����
    public int Protection;  //�o���A�Ŏ��񐔂���
    
    public bool B_Switch;   //�o���A���I���ɂȂ��Ă��邩��������
    public bool HPSwitch;   //�z�����I���ɂȂ��Ă��邩��������
    public bool defense = false;    //�o���A���I���ɂ��邩�ǂ����𑀍삷������

//--------------------------------------------------------------------------------------
//�o���A�Ƌz���̃I���I�t�̏���

    void Update()
    {
        //�o���A�Ɋւ��鏈�������Ă����
        if(defense == true)
        {
            if(Protection <= 0)
            {
                Barrier.SetActive(false);   //�o���A���I�t�ɂ����
            }
        }
        else if (B_Switch)
        {
            if (Barrier.activeSelf == false)
            {
                Protection = barrier_number; //barrie_number�ɓ����Ă��鐔���𐳎��Ɏ��񐔂ɂ����
                Barrier.SetActive(true);    //�o���A���I���ɂ����
                defense = true;     //�o���A���I���ɂ����
            }
        }
        else if (!B_Switch)
        {
            if (Barrier.activeSelf == true)
            {
                Barrier.SetActive(false);   //�o���A���I�t�ɂ����
            }
        }
        //�z���Ɋւ��鏈�������Ă����
        if (HPSwitch)
        {
            if (Absorption.activeSelf == false)
            {
                Absorption.SetActive(true); //�z�����I���ɂ����
            }
        }
        else if (!HPSwitch || Protection == 0)  
        {
            if (Absorption.activeSelf == true)
            {
                Absorption.SetActive(false);    //�z�����I�t�ɂ����
            }
        }
    }

//--------------------------------------------------------------------------------------

}
