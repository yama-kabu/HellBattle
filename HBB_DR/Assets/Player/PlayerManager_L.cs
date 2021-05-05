using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager_L : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D P2;
    //���@�̈ړ����x���i�[����ϐ��i�����l�T�j
    public float speed = 5;
    //Player2Buleet �v���n�u
    public GameObject Bullet1;
    public GameObject Bullet2;

    //�ˌ��̃N�[���^�C��
    public float ShotCoolTime;//�S�̂̃N�[���^�C�������߂�
    float Shot1cool;//Shot1�p�̃N�[���^�C���J�E���^�[
    float Shot2cool;//Shot2�p�̃N�[���^�C���J�E���^�[
    
    //�e�̑��x
    public float balletSpeed = 0;

    //�v���C���[���x
    public Vector2 PlayerSpeed = new Vector2(0.005f, 0.005f);

    //--------------------------------------------------------------------------------------

    // �Q�[���̃X�^�[�g���̏���
    void Start()
    {
        //Rigidbody2D�@�R���|�[�l���g���擾���ĕϐ��@P2�@�Ɋi�[
        P2 = GetComponent<Rigidbody2D>();
    }

//--------------------------------------------------------------------------------------

    // �J��Ԃ�����
    void Update()
    {
        Move();
        Shot();
        Shot2();
    }

//--------------------------------------------------------------------------------------

    //�ʂ̒��g
    //�V���b�g�P
    void Shot()
    {
        Shot1cool += Time.deltaTime;
        if (Input.GetKey(KeyCode.Z))
        {
            if (Shot1cool >= ShotCoolTime)
            {
                Shot1cool = 0;
            }

            if (Shot1cool == 0)
            {
                GameObject Shot = Instantiate(Bullet1);

                Shot.transform.position = this.transform.position;
            }
        }
    }

    //--------------------------------------------------------------------------------------

    void Shot2()
    {
        Shot2cool += Time.deltaTime;
        if (Input.GetKey(KeyCode.X))
        {
            if (Shot2cool >= ShotCoolTime)
            {
                Shot2cool = 0;
            }

            if (Shot2cool == 0)
            {
                for (int i = 1; i <= 8; i++)
                {
                    //�ʂ̊p�x
                    float Ag = i * 45;//�ύX����22.5(�S�����ł͂Ȃ��O�����̏ꍇ)

                    Vector3 Angle = transform.eulerAngles;
                    Angle.x = transform.rotation.x;
                    Angle.y = transform.rotation.y;
                    Angle.z = Ag;
                    
                    GameObject Shot2 = Instantiate(Bullet2) as GameObject;
                    Shot2.transform.rotation = Quaternion.Euler(Angle);
                    Shot2.transform.position = this.transform.position;
                }
            }
        }
    }

    //--------------------------------------------------------------------------------------

    void Move()
    {
        // ���݈ʒu��Position�ɑ��
        Vector2 Position = transform.position;
        // ���L�[�����������Ă�����
        if (Input.GetKey("a"))
        {
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x -= PlayerSpeed.x;
        }
        else if (Input.GetKey("d"))
        { // �E�L�[�����������Ă�����
          // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x += PlayerSpeed.x;
        }
        else if (Input.GetKey("w"))
        { // ��L�[�����������Ă�����
          // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey("s"))
        { // ���L�[�����������Ă�����
          // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y -= PlayerSpeed.y;
        }
        // ���݂̈ʒu�ɉ��Z���Z���s����Position��������
        transform.position = Position;
    }
}
