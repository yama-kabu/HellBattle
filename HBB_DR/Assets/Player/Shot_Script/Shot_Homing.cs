//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Homing : MonoBehaviour
{
    //�e�̑��x
    public float Shot_Speed = 0;

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
    public float Homing_Time = 0;

    // Start is called before the first frame update
    void Start()
    {
        //�����蔻��@��
        BoxCollider2D Hit_Wall = Stage.GetComponent<BoxCollider2D>();
        Homing = GetComponent<Rigidbody2D>();
        BulletTrans = GetComponent<Transform>();

        //                    �ǂ�������Ώۂ������Ō��߂�
        enemy = GameObject.Find("Temporary_Enemy");

    }

    // Update is called once per frame

    void Update()
    {

        Homing_Time += Time.deltaTime;
        if (Homing_Time >= 10)
        {
            Destroy(this.gameObject);
        }

    }

    void OnTriggerExit2D(Collider2D BD)
    {

        if (BD.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

    }

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
}