using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Temporary_Enemy;
    //���@�̈ړ����x���i�[����ϐ��i�����l�T�j
    public float Speed = 5;

    public int Enemy_MAXHP;
    public int Enemy_HP;

    //�v���C���[���x
    public Vector2 PlayerSpeed = new Vector2(0.005f, 0.005f);
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2D�@�R���|�[�l���g���擾���ĕϐ��@Player_L�@�Ɋi�[
        Temporary_Enemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        // ���݈ʒu��Position�ɑ��
        Vector2 Position = transform.position;
        //�΂߈ړ�
        if (Input.GetKey(KeyCode.LeftArrow) & Input.GetKey(KeyCode.UpArrow))
        {
            //��������������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x -= PlayerSpeed.x;
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) & Input.GetKey(KeyCode.DownArrow))
        {
            //���������������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x -= PlayerSpeed.x;
            Position.y -= PlayerSpeed.y;
        }
        else if (Input.GetKey(KeyCode.RightArrow) & Input.GetKey(KeyCode.UpArrow))
        {
            //��������������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x += PlayerSpeed.x;
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey(KeyCode.RightArrow) & Input.GetKey(KeyCode.DownArrow))
        {
            //���������������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x += PlayerSpeed.x;
            Position.y -= PlayerSpeed.y;
        }

        //�㉺���E�ړ�
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // ���L�[�����������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x -= PlayerSpeed.x;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // �E�L�[�����������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x += PlayerSpeed.x;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            // ��L�[�����������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // ���L�[�����������Ă�����
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y -= PlayerSpeed.y;
        }
        // ���݂̈ʒu�ɉ��Z���Z���s����Position��������
        transform.position = Position;
    }
}
