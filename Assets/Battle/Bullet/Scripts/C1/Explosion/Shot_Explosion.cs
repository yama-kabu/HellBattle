//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Explosion : Shot_Common
{
//--------------------------------------------------------------------------------------
//�Q�ƌn

    private Rigidbody2D rb;  //�e��Rigidbody2D���i�[����ϐ�����
    GameObject enemy_position;   //�G�Ƃ̋����𑪂鎞�Ɏg���G�̈ʒu���i�[����ϐ�����
    public  GameObject bullet_burst;    //�Ō�ɔ�юU�鏈��������Ƃ��Ɏg���e���i�[����ϐ����邾��

//--------------------------------------------------------------------------------------
//�ϐ��n

    public float burst_speed = 0 * 0.01f;  //�y�􂷂�e�̑��x����
    int check = 0;      //�e�̌���������ϐ�����B�O�`�S�@�Ő����ɂ���ďo�鐔���ς���
    int time_count = 0;     //�e�̏o�鎞�Ԃ�}�鎞�Ɏg����

    Vector3 vector3;    //�p�x��}��Ƃ��Ɏg��Vector3��p�ӂ����

//--------------------------------------------------------------------------------------
//�ŏ��̏���

    void Start()
    {

        //�����̈ʒu�𒲂ׂ��
        #region �Ώېݒ�
        if (this.gameObject.CompareTag("Bullet_1"))
        {
            target_position = GameObject.Find("Explosion_TargetP1");
            enemy_position = GameObject.Find("Player_R2");
        }
        else if (this.gameObject.CompareTag("Bullet_2"))
        {
            target_position = GameObject.Find("Explosion_TargetP2");
            enemy_position = GameObject.Find("Player_R1");
        }
        #endregion
        rb = this.GetComponent<Rigidbody2D>();   //�e�ɂ��Ă���Rigidbody2D�������
        bullet_position = GetComponent<Transform>();    //�e�ɂ��Ă���ʒu�������
        //�G�����邩�̃`�F�b�N�������
        #region �G�Ƃ̋����v�Z
        if (target_position != null)
        {
            //�e����ǂ�������Ώۂւ̕������v�Z
            vector3 = target_position.transform.position - bullet_position.position;     //�G�ƒe�̈ʒu����p�x���o����
        }
        else if (target_position == null)
        {
            //�G�����Ȃ������牽�����Ȃ���
        }
        #endregion
        rb.AddForce(vector3.normalized * bullet_Speed, 
        (ForceMode2D)ForceMode.Impulse);      //�����̒�����1�ɐ��K�����āA�C�ӂ̗͂�AddForce�ŉ������
    }

//--------------------------------------------------------------------------------------
//���ˏ���

    void Update()
    {
        #region ���ˏ���
        //�S�ȏォ�ǂ����������
        if (check < 4)
        {
            if (time_count % 100 == 0)
            {
                switch (check)
                {
                    case 3:
                        for (int i = 0; i < 10; i++)
                        {
                            Exp(i);
                        }
                        check++;    //���̃t�F�[�Y�Ɉړ������
                        Destroy(this.gameObject);
                        break;
                    case 2:
                        for (int i = 0; i < 20; i++)
                        {
                            Exp(i);
                        }
                        check++;    //���̃t�F�[�Y�Ɉړ������
                        break;
                    case 1:
                        for (int i = 0; i < 30; i++)
                        {
                            Exp(i);
                        }
                        check++;    //���̃t�F�[�Y�Ɉړ������
                        break;
                    default:
                        break;
                }
            }
            time_count++;
        }
        #endregion
    }

    //--------------------------------------------------------------------------------------
    //�e�̐�������

    void Exp(int i)
    {
        Vector2 vec = enemy_position.transform.position - bullet_position.position;     //�G�ƒe�̈ʒu����p�x���o����
        vec.Normalize();
        #region �e���w��̊p�x���Ƃɏo������
        if (check == 1)
        {
            vec = Quaternion.Euler(0, 0, (360 / 10) * i) * vec;     //�R�U�x���o����
        }
        else if (check == 2)
        {
            vec = Quaternion.Euler(0, 0, (360 / 20) * i) * vec;     //�P�W�x���o����
        }
        if (check == 3)
        {
            vec = Quaternion.Euler(0, 0, (360 / 10) * i) * vec;     //�R�U�x���o����
        }
        #endregion
        vec *= burst_speed;
        var q = Quaternion.Euler(0, 0, -Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg);     //�G�Ƃ̊p�x���������
        var t = Instantiate(bullet_burst, transform.position, q);   //�e�ɏ����������
        t.GetComponent<Rigidbody2D>().velocity = vec;   //���˂��I

    }

//--------------------------------------------------------------------------------------

    void OnTriggerEnter2D(Collider2D BD)
    {
        //�O���ǂ��������
        if (check == 0)
        {
            if (BD.gameObject.name == "Explosion_TargetP1" || BD.gameObject.name == "Explosion_TargetP2")
            {
                rb.velocity = Vector3.zero;  //���x���O�ɂ����

                check = 1;  //�P�ɂ��đS�̂ւ̍U�����J�n�I
            }
        }  
    }
}
