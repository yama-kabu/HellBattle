//��
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn

    public Text syouhai_text_L1;  //�e�L�X�g�������邽�߂Ƀe�L�X�g���i�[������̂���
    public Text syouhai_text_L2;  //�e�L�X�g�������邽�߂Ƀe�L�X�g���i�[������̂���

//--------------------------------------------------------------------------------------
//�ϐ��n

    public bool last_of_agaki_check = false;  //�Ō�̂��������g�������ǂ����`�F�b�N
    public bool syouhai = false;//���s�����܂�����  false= �܂��I����Ă��Ȃ��B true= �I�����
    public bool WINER;  //L1����������true�AL2����������false
    public bool check = false; //���������⏟�s��\�����鏈�����s��ꂽ���`�F�b�N

    //--------------------------------------------------------------------------------------
    //�ŏ��̏���

    void Awake()
    {
        Application.targetFrameRate = 240; //FPS��240�ɐݒ� 
    }

    //--------------------------------------------------------------------------------------
    //�Q�[���̏��s�Ɋւ��鏈���ƒe�̌㏈��

    private void Update()
    {
        if (syouhai)
        {
            if (!check)//���s������������J�n
            {
                zenkesi();

                check = true;   //�������I�������
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");   //�X�y�[�X��������^�C�g����
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
