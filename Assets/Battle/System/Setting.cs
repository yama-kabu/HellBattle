//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn

    public Text syouhai_text_L1;  //�e�L�X�g�������邽�߂Ƀe�L�X�g���i�[������̂���
    public Text syouhai_text_L2;  //�e�L�X�g�������邽�߂Ƀe�L�X�g���i�[������̂���

    public bool syouhai = false;//���s�����܂�����  false= �܂��I����Ă��Ȃ��B true= �I�����
    public bool WINER;  //L1����������true�AL2����������false
    bool chack = false; //���������⏟�s��\�����鏈�����s��ꂽ���`�F�b�N

//--------------------------------------------------------------------------------------
//�ŏ��̏���
    void Start()
    {
        Application.targetFrameRate = 240; //FPS��240�ɐݒ� 
    }

//--------------------------------------------------------------------------------------
//�Q�[���̏��s�Ɋւ��鏈���ƒe�̌㏈��

    private void Update()
    {

        
        if (syouhai)
        {
            if (!chack)//���s������������J�n
            {
                zenkesi();

                if (WINER)
                {
                    syouhai_text_L1.text = "WIN";          //�\�������
                    syouhai_text_L2.text = "LOSE";          //�\�������
                }
                else
                {
                    syouhai_text_L1.text = "LOSE";          //�\�������
                    syouhai_text_L2.text = "WIN";          //�\�������
                }
                chack = true;   //�������I�������
            }
        }
    }
    //�����̒��g
    void zenkesi()
    {
        //����Ƃ�����e����ɂ܂Ƃ߂�
        GameObject[] Bullets = GameObject.FindGameObjectsWithTag("Bullet");
        Clean(Bullets);
        Bullets = GameObject.FindGameObjectsWithTag("Bullet_1");
        Clean(Bullets);
        Bullets = GameObject.FindGameObjectsWithTag("Bullet_2");
        Clean(Bullets);
        Bullets = GameObject.FindGameObjectsWithTag("Bullet_3");
        Clean(Bullets);
    }
    //����������������
    void Clean(GameObject[] Bullets)
    {
        foreach (GameObject AllBullet in Bullets)
        {
            //����Ƃ�����e��j��
            Destroy(AllBullet);
        }
    }
}
