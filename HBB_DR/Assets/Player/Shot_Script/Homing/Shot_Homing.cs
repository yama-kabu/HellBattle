//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Homing : MonoBehaviour
{

    //弾の速度
    public float Shot_Speed = 0;

    //飛び散る用の弾
    public GameObject Shot01;
    public GameObject Stage;

    //追いかける対象のTransform
    GameObject enemy;
    //弾の制限速度
    [SerializeField] private float limitSpeed;

    //弾のTransform
    private Transform BulletTrans;
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D Homing;

    //追い続ける時間
    public float Homing_Time = 10;


//--------------------------------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {

        Homing = GetComponent<Rigidbody2D>();
        BulletTrans = GetComponent<Transform>();


        //追いかける対象をここで決める
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
                float Shot_Angle = i * 120;//変更時は22.5(全方向ではなく前だけの場合)

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
        //弾から追いかける対象への方向を計算
        Vector3 vector3 = enemy.transform.position - BulletTrans.position;
        //方向の長さを1に正規化、任意の力をAddForceで加える
        Homing.AddForce(vector3.normalized * Shot_Speed);
        //X方向の速度を制限
        float speedXTemp = Mathf.Clamp(Homing.velocity.x, -limitSpeed, limitSpeed);
        //Y方向の速度を制限
        float speedYTemp = Mathf.Clamp(Homing.velocity.y, -limitSpeed, limitSpeed);
        //実際に制限した値を代入
        Homing.velocity = new Vector3(speedXTemp, speedYTemp);
    }

//--------------------------------------------------------------------------------------

}