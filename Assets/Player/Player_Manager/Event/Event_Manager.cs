//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject Barrier;
    [SerializeField] 
    GameObject Absorption;

    //バリア用
    public bool B_Switch;
    //吸収用
    public bool HPSwitch;

    public bool defense = false;
    //バリアで守る回数
    public int barrie_kaisu;
    //バリアで守る回数を実行する際に使うやつ
    public int Protection;

//--------------------------------------------------------------------------------------
//バリア

    private void Start()
    {
        Protection = barrie_kaisu;
        //初期化
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
                //バリアオフ
                Barrier.SetActive(false);
            }
        }
        else if (B_Switch)
        {
            if (Barrier.activeSelf == false)
            {
                //バリアオン
                Barrier.SetActive(true);
                //バリアで守る回数を設定
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
//吸収
        if (HPSwitch)
        {
            if (Absorption.activeSelf == false)
            {
                //吸収オン
                Absorption.SetActive(true);
            }
        }
        else if (!HPSwitch || Protection == 0)
        {
            if (Absorption.activeSelf == true)
            {
                //吸収オフ
                Absorption.SetActive(false);
            }
        }
    }
}
