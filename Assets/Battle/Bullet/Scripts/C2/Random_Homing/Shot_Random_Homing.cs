//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Random_Homing : Shot_Common
{
//--------------------------------------------------------------------------------------
//�Q�ƌn
    
    private Rigidbody2D rb;    //�e��Rigidbody2D���i�[����ϐ�����
//--------------------------------------------------------------------------------------
//�ϐ��n
   
    public int force_pawer; //�����_���ړ�����ۂ̗͂̐U�ꕝ�����߂���

    float rnd;      //�p�x����
    float random_time = 3;      //�ŏ��̈ړ��̎���
    float random_change = 0.3f;     //������ς��鎞�Ԃ���
    float stop_time = 5;    //�X�g�b�v���鎞�Ԃ���
    float homing_time = 5;  //�z�[�~���O���鎞�Ԃ���
    float homing_stop_time =0;  //�z�[�~���O�̂ނ���ς���܂ł̎��Ԃ���

    bool is_homing_check = false;   //�z�[�~���O���J�n������������`�F�b�N����
    bool is_hit_check = false;  //�ǂɓ����������𒲂ׂ�`�F�b�N����
    bool is_stop_check = false;     //���̓����Ɉړ����邽�߂̃`�F�b�N����

    private Vector2 lastVelocity;   //�p�x��}��Ƃ��Ɏg��Vector2��p�ӂ����
//--------------------------------------------------------------------------------------
//�ŏ��̏���

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();  //�e�ɂ��Ă���Rigidbody2D�������
        rb.AddForce(new Vector2(Random.Range(-force_pawer, force_pawer) * 100f,
                                Random.Range(-force_pawer, force_pawer) * 100f));     //�����_���ȕ����ɗ͂��������
        bullet_position = GetComponent<Transform>(); //�e�ɂ��Ă���ʒu������� 

        rnd = Random.value * 360;   //�����_���ϐ��ɒǉ������
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rnd);    //�e�̌����������_���ϐ��œ����l�ɕύX����
        //�ǂ�������Ώۂ����߂��
        #region �Ώېݒ�
        if (this.gameObject.CompareTag("Bullet_1"))
        {
            target_position = GameObject.Find("Hit_Body_P2");
        }
        else if(this.gameObject.CompareTag("Bullet_2"))
        {
            target_position = GameObject.Find("Hit_Body_P1");
        }
        #endregion
        InvokeRepeating("homing", 0.7f, 0.7f);  //�z�[�~���O�̏����@0.7�b���ƂɎ��s�����
    }

//--------------------------------------------------------------------------------------
//�����_���ړ������ƁA�z�[�~���O����

    void Update()
    {
        if (random_time > 0)
        {
            random_time -= Time.deltaTime;  //�����_���ړ���������܂ł̎��Ԃ��v�Z
            random_change -= Time.deltaTime;    //�����_���Ɉړ�����܂ł̎��Ԃ��v�Z
            if (random_change < 0)
            {
                rb.velocity = Vector2.zero;     //�ړ������~�߂��
                rb.AddForce(new Vector2(Random.Range(-force_pawer, force_pawer) * 100f,
                                        Random.Range(-force_pawer, force_pawer) * 100f));   //�����_���ȕ����Ɉړ������
                random_change = 0.3f;   //�����_���Ɉړ�����܂ł̎��Ԃ�������
            }
        }
        else
        {
            //���Ԃ�������ړ�����߁A�F��ύX���ǔ��ɍs����ύX�����鏈������
            if (!is_stop_check)
            {
                rb.velocity = Vector2.zero;     //�ړ������~�߂��
                is_stop_check = true;   //�����_���ړ����~�߂āA�z�[�~���O�ɐ؂�ւ����
            }
            //����̈ړ����鎞�Ԃ�݂����
            else if (stop_time > 0)
            {
                stop_time -= Time.deltaTime;
            }
            else 
            {
                is_homing_check = true;     //�z�[�~���O�J�n
                homing_time -= Time.deltaTime;
                if(homing_time < 0)
                {
                    is_hit_check = true;    //�����蔻��I���I
                    Destroy(this.GetComponent<CircleCollider2D>());
                }
            }
        }
    }

//--------------------------------------------------------------------------------------
//��ɗ͂����������鏈��

    void FixedUpdate()
    {
        if (!is_stop_check)
        {
            this.lastVelocity = this.rb.velocity;
        }
    }

//--------------------------------------------------------------------------------------
//�����_���ړ����ɃX�e�[�W�̂͂��ɓ��������ꍇ�̏���

    void OnCollisionEnter2D(Collision2D Reflect)
    {
        if (random_time > 0)
        {
            Vector2 refrectVec = Vector2.Reflect(this.lastVelocity, Reflect.contacts[0].normal);    ////���˂���p�x�̌v�Z
            this.rb.velocity = refrectVec;  //�Ԃ����݁[
        }
    }

//--------------------------------------------------------------------------------------
//�z�[�~���O����

    void homing()
    {
        if (is_homing_check && !is_hit_check)
        {
            if (homing_stop_time > 0)
            {
                homing_stop_time -= Time.deltaTime;
            }
            else
            {
                #region ���܂��̎O�����ɔ�΂�����
                bullet_position = GetComponent<Transform>(); //�e�ɂ��Ă���ʒu������� 
                rb.velocity = Vector2.zero;     //��x���x���O�ɂ���
                if (target_position != null)
                {
                    Vector3 vector3 = target_position.transform.position - bullet_position.position;    //�G�ƒe�̈ʒu����p�x���o����
                    rb.AddForce(vector3.normalized * bullet_Speed * 10);     //�����̒�����1�ɐ��K�����āA�C�ӂ̗͂�AddForce�ŉ������
                }
                else if (target_position == null)
                {
                    Vector3 vector3 = bullet_position.position;     //�G�����Ȃ�����Ƃ肠���������̈ʒu���o����
                    rb.AddForce(vector3.normalized * bullet_Speed * 10);     //�����̒�����1�ɐ��K�����āA�C�ӂ̗͂�AddForce�ŉ������
                }
                #endregion
            }
        }
    }

//--------------------------------------------------------------------------------------

}
