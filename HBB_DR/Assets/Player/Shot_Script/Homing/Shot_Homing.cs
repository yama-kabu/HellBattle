//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Homing : MonoBehaviour
{

    //�e�̑��x
    public float Shot_Speed = 0;

    //��юU��p�̒e
    public GameObject Shot01;
    public GameObject Stage;

    //�ǂ�������Ώۂ�Transform
    GameObject enemy;
    //�e�̐������x
    [SerializeField] private float limitSpeed;

    //�e��Transform
    private Transform BulletTrans;
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Homing;

    //�ǂ������鎞��
    public float Homing_Time = 10;


//--------------------------------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {

        Homing = GetComponent<Rigidbody2D>();
        BulletTrans = GetComponent<Transform>();


        //�ǂ�������Ώۂ������Ō��߂�
        if (this.gameObject.CompareTag("Bullet_1"))
        {
            enemy = GameObject.Find("Player_R2");
        }
        else if(this.gameObject.CompareTag("Bullet_2"))
        {
            enemy = GameObject.Find("Player_R1");
        }
    }

//--------------------------------------------------------------------------------------

    // Update is called once per frame
    void Update()
    {
        Homing_Time -= Time.deltaTime;
        if (Homing_Time <= 0)
        {
            Homing.velocity = new Vector3(0f, 0f);
            Destroy(this.gameObject);

            for (int i = 1; i <= 3; i++)
            {
                float Shot_Angle = i * 120;//�ύX����22.5(�S�����ł͂Ȃ��O�����̏ꍇ)

                Vector3 Angle = transform.eulerAngles;
                Angle.x = transform.rotation.x;
                Angle.y = transform.rotation.y;
                Angle.z = Shot_Angle;

                GameObject Shot2 = Instantiate(Shot01) as GameObject;
                Shot2.transform.rotation = Quaternion.Euler(Angle);
                Shot2.transform.position = this.transform.position;
            }
        }
    }

//--------------------------------------------------------------------------------------

    void OnTriggerEnter2D(Collider2D BD)
    {

        if (BD.gameObject.tag == "Player_R1" || BD.gameObject.tag == "Player_R2")
        {

            Destroy(this.gameObject);
        }
    }

//--------------------------------------------------------------------------------------

    private void FixedUpdate()
    {
        //�e����ǂ�������Ώۂւ̕������v�Z
        Vector3 vector3 = enemy.transform.position - BulletTrans.position;
        //�����̒�����1�ɐ��K���A�C�ӂ̗͂�AddForce�ŉ�����
        Homing.AddForce(vector3.normalized * Shot_Speed);
        //X�����̑��x�𐧌�
        float speedXTemp = Mathf.Clamp(Homing.velocity.x, -limitSpeed, limitSpeed);
        //Y�����̑��x�𐧌�
        float speedYTemp = Mathf.Clamp(Homing.velocity.y, -limitSpeed, limitSpeed);
        //���ۂɐ��������l����
        Homing.velocity = new Vector3(speedXTemp, speedYTemp);
    }

//--------------------------------------------------------------------------------------

}