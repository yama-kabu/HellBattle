using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body1 : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D PB;
    //�v���C���[�̗͂̃v���n�u
    public int PlayerHP = 10;




    //���@�̈ړ����x���i�[����ϐ��i�����l�T�j
    public float speed = 5;

    public Vector2 PlayerSpeed = new Vector2(0.005f, 0.005f);
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2D�@�R���|�[�l���g���擾���ĕϐ��@PB�@�Ɋi�[
        PB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
        {
            // �ړ�����
            Move();
        }
        // �ړ�
        void Move()
        {
            // ���݈ʒu��Position�ɑ��
            Vector2 Position = transform.position;
            //�΂�

             if�@�@  (Input.GetKey(KeyCode.RightArrow) & Input.GetKey(KeyCode.UpArrow))
        {   // �E���L�[�����������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x += PlayerSpeed.x;
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) & Input.GetKey(KeyCode.UpArrow))
        {   // �E��L�[�����������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y += PlayerSpeed.y;
            Position.x -= PlayerSpeed.x;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) & Input.GetKey(KeyCode.DownArrow))
        {   //�����L�[�����������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y -= PlayerSpeed.y;
            Position.x -= PlayerSpeed.x;
        }
        else if (Input.GetKey(KeyCode.RightArrow) & Input.GetKey(KeyCode.DownArrow))
        {   // �E���L�[�����������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y -= PlayerSpeed.y;
            Position.x += PlayerSpeed.x;
        }

        //�㉺���E

        // ���L�[�����������Ă�����
        else if (Input.GetKey(KeyCode.LeftArrow))
        {   // ��L�[�����������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x -= PlayerSpeed.x;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        { // �E�L�[�����������Ă�����
          // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x += PlayerSpeed.x;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        { // ��L�[�����������Ă�����
          // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        { // ���L�[�����������Ă�����
          // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y -= PlayerSpeed.y;
        }



            // ���݂̈ʒu�ɉ��Z���Z���s����Position��������
            transform.position = Position;
        }
}
