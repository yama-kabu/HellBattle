//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Homing : Shot_Common
{
//--------------------------------------------------------------------------------------
//�Q�ƌn
    
    Shot_Manager s_Manager;   //Shot_Manager���Ăяo�����߂̂��̂���
    private Rigidbody2D rb; //�e��Rigidbody2D���i�[����ϐ�����

//--------------------------------------------------------------------------------------
//�ϐ��n
    
    [SerializeField] private float limitSpeed;  //�e�̑��x�Ɋւ��鐧���l����

    public float Homing_Time = 10;  //�ǂ������鎞�Ԃ���

    //--------------------------------------------------------------------------------------
    //�ŏ��̏���

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //�e�ɂ��Ă���Rigidbody2D�������
        bullet_position = GetComponent<Transform>(); //�e�ɂ��Ă���ʒu������� 

        //�����̈ʒu�𒲂ׂ��
        #region �Ώېݒ�
        if (this.gameObject.CompareTag("Bullet_1"))
        {
            target_position = GameObject.Find("Hit_Body_P2");
        }
        else if (this.gameObject.CompareTag("Bullet_2"))
        {
            target_position = GameObject.Find("Hit_Body_P1");
        }
        #endregion
    }

//--------------------------------------------------------------------------------------
//�ǂ������鎞�ԂƂ��̌�̏���

    void Update()
    {
        Homing_Time -= Time.deltaTime;  //�ǂ������鎞�Ԃ��v�Z�����
        //�ǂ������鎞�Ԃ��O�ɂȂ�����s����������
        if (Homing_Time <= 0)
        {
            rb.velocity = new Vector3(0f, 0f);  //�ړ�����U��~�������
            Destroy(this.gameObject);
            #region �R�����ɒe���o������
            for (int i = 1; i <= 3; i++)
            {
                float Shot_Angle = i * 120;     //�P�Q�O�x���Ƃɒe���o����
                Vector3 Angle = transform.eulerAngles;  //���̊p�x�������
                Angle.x = transform.rotation.x;     //�����������
                Angle.y = transform.rotation.y;     //�����������
                Angle.z = Shot_Angle;   //�����������
                GameObject Bullet = Instantiate(bullet_normal) as GameObject;   //�o���e���w�肷���
                Bullet.transform.rotation = Quaternion.Euler(Angle);    //�p�x���������
                Bullet.transform.position = this.transform.position;    //���˂��I
            }
            #endregion
        }
    }

//--------------------------------------------------------------------------------------
//�ǂ������鏈��

    private void FixedUpdate()
    {
        bullet_position = GetComponent<Transform>(); //�e�ɂ��Ă���ʒu������� 
        #region �G�����邩�̃`�F�b�N�������
        if (target_position != null)
        {
            Vector3 vector3 = target_position.transform.position - bullet_position.position;    //�G�ƒe�̈ʒu����p�x���o����
            rb.AddForce(vector3.normalized * bullet_Speed);     //�����̒�����1�ɐ��K�����āA�C�ӂ̗͂�AddForce�ŉ������
        }
        else if (target_position == null)
        {
            Vector3 vector3 = bullet_position.position;     //�G�����Ȃ�����Ƃ肠���������̈ʒu���o����
            rb.AddForce(vector3.normalized * bullet_Speed);     //�����̒�����1�ɐ��K�����āA�C�ӂ̗͂�AddForce�ŉ������
        }
        #endregion
        #region ���x����
        float speedXTemp = Mathf.Clamp(rb.velocity.x, -limitSpeed, limitSpeed);     //X�����̑��x�𐧌������
        float speedYTemp = Mathf.Clamp(rb.velocity.y, -limitSpeed, limitSpeed);     //Y�����̑��x�𐧌������
        rb.velocity = new Vector3(speedXTemp, speedYTemp);      //���ۂɐ��������l����
        #endregion
    }

    //--------------------------------------------------------------------------------------

}