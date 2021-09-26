using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_notation : MonoBehaviour
{
    public Text count_text;  //�e�L�X�g�������邽�߂Ƀe�L�X�g���i�[������̂���
    public GameObject Start_Timer;  //�^�C�}�[�̎c�莞�Ԃ��Q�Ƃ�����̂���

    void Start()
    {
        if (this.CompareTag("Player_L1"))
        {
            count_text.text = "P1";
        }
        else if (this.CompareTag("Player_L2"))
        {
            count_text.text = "P2";
        }
    }


    void Update()
    {
        if (Start_Timer.GetComponent<Start_Timer>().count_down <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}