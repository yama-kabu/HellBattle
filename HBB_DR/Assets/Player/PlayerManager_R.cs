using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager_R : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D P2;
    //���@�̈ړ����x���i�[����ϐ��i�����l�T�j
    public float speed = 5;
    
    public int PlayerMAXHP;
    public int PlayerHP;

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
    }

//--------------------------------------------------------------------------------------

    void Move()
    {
        // ���݈ʒu��Position�ɑ��
        Vector2 Position = transform.position;
        // ���L�[�����������Ă�����
        if (Input.GetKey("left"))
        {
            // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x -= PlayerSpeed.x;
        }
        else if (Input.GetKey("right"))
        { // �E�L�[�����������Ă�����
          // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.x += PlayerSpeed.x;
        }
        else if (Input.GetKey("up"))
        { // ��L�[�����������Ă�����
          // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y += PlayerSpeed.y;
        }
        else if (Input.GetKey("down"))
        { // ���L�[�����������Ă�����
          // �������Position�ɑ΂��ĉ��Z���Z���s��
            Position.y -= PlayerSpeed.y;
        }
        // ���݂̈ʒu�ɉ��Z���Z���s����Position��������
        transform.position = Position;
    }
}
