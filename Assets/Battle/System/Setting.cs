//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn

    //���s�����܂�����  false= �܂��I����Ă��Ȃ��B true= �I�����
    public bool syouhai = false;

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
        //���s������������J�n
        if (syouhai)
        {
            zenkesi();
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
