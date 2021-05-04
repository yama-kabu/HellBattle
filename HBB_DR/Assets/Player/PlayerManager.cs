using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
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


    public float balletSpeed = 0;

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
        //���E�̓��͂����ɓn��
        float x = Input.GetAxisRaw("Horizontal");
        //�㉺�̓��͂����ɓn���B
        float y = Input.GetAxisRaw("Vertical");

        //�ړ�������������߂�
        //���Ƃ��̓��͒l�𐳋K�����Adirection�ɓn���B
        Vector2 direction = new Vector2(x, y).normalized;
        //Rigidbody2D�R���|�[�l���g��velocity�ɕ����ƈړ����x���|�����l��n���B
        P2.velocity = direction * speed;
        
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
    




}
