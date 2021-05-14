//ル
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Homing : MonoBehaviour
{
    //弾の速度
    public float Shot_Speed = 0;

    public GameObject Stage;

    //追いかける対象のTransform
    [SerializeField] private Transform EnemyTrans;
    //弾の制限速度
    [SerializeField] private float limitSpeed;

    //弾のTransform
    private Transform BulletTrans;                 
    //Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D Homing;

    //追い続ける時間
    float Homing_Time;

    // Start is called before the first frame update
    void Start()
    {
        //当たり判定　壁
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
        //弾から追いかける対象への方向を計算
        Vector3 vector3 = EnemyTrans.position - BulletTrans.position;
        //方向の長さを1に正規化、任意の力をAddForceで加える
        Homing.AddForce(vector3.normalized * Shot_Speed);
        //X方向の速度を制限
        float speedXTemp = Mathf.Clamp(Homing.velocity.x, -limitSpeed, limitSpeed);
        //Y方向の速度を制限
        float speedYTemp = Mathf.Clamp(Homing.velocity.y, -limitSpeed, limitSpeed);
        //実際に制限した値を代入
        Homing.velocity = new Vector3(speedXTemp, speedYTemp);　　　　　　　　　　　
    }



}
