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
    [SerializeField] private Transform EnemyTrans;
    //�e�̐������x
    [SerializeField] private float limitSpeed;

    //�e��Transform
    private Transform BulletTrans;                 
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Homing;

    //�ǂ������鎞��
    float Homing_Time;

    // Start is called before the first frame update
    void Start()
    {
        //�����蔻��@��
        BoxCollider2D Hit_Wall = Stage.GetComponent<BoxCollider2D>();
        Homing = GetComponent<Rigidbody2D>();
        BulletTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
   /*
    void Update()
    {

        transform.Translate(0, Shot_Speed, 0);

    }
   */
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
        Vector3 vector3 = EnemyTrans.position - BulletTrans.position;
        //�����̒�����1�ɐ��K���A�C�ӂ̗͂�AddForce�ŉ�����
        Homing.AddForce(vector3.normalized * Shot_Speed);
        //X�����̑��x�𐧌�
        float speedXTemp = Mathf.Clamp(Homing.velocity.x, -limitSpeed, limitSpeed);
        //Y�����̑��x�𐧌�
        float speedYTemp = Mathf.Clamp(Homing.velocity.y, -limitSpeed, limitSpeed);
        //���ۂɐ��������l����
        Homing.velocity = new Vector3(speedXTemp, speedYTemp);�@�@�@�@�@�@�@�@�@�@�@
    }



}
