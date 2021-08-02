using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_Timer : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn

    public Text count_text_L1;  //�e�L�X�g�������邽�߂Ƀe�L�X�g���i�[������̂���
    public Text count_text_L2;  //�e�L�X�g�������邽�߂Ƀe�L�X�g���i�[������̂���

//--------------------------------------------------------------------------------------
//�ϐ��n

    public float count_down = 4f;  //�J�E���g�_�E�����鎞�Ԃ���
    int count;  //�����ɒ���������������ϐ�����

    public bool is_start_chack = false;    //�Q�[���̊J�n���邩�����
    bool chack = false; //�������s��ꂽ���`�F�b�N
//--------------------------------------------------------------------------------------
//�J�E���g�_�E���̏���

    void Update()
    {
        if(count_down >= 0)
        {
            count_down -= Time.deltaTime;
            count = (int)count_down;   //�����ɒ�����
        //--------------------------------------------------------------------------------------
            count_text_L1.text = 
                (count != 0) ? count.ToString(): //�\�������
                               "Start";          //�\�������
            count_text_L2.text =
                (count != 0) ? count.ToString(): //�\�������
                               "Start";          //�\�������
        //--------------------------------------------------------------------------------------
        }
        if (count_down <= 0 && !chack)
        {
            count_text_L1.text = "";    //�e�L�X�g��������
            count_text_L2.text = "";    //�e�L�X�g��������
            is_start_chack = true;     //�Q�[���̊J�n���I
            chack = true;
        }
    }
}
