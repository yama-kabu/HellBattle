using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D P2;
    //���@�̈ړ����x���i�[����ϐ��i�����l�T�j
    public float speed = 5;
    //Player2Buleet �v���n�u
    public GameObject Circle1;
    //���ԊԊu
    float Times = 0;

    public float Timed = 0;

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

        //Z�L�[���͂ŋʂ𔭎�
        if(Input.GetKey(KeyCode.Z))
        {
            Shot();
        }

        Times += Time.deltaTime;
    }

//--------------------------------------------------------------------------------------

    //�ʂ̒��g
    void Shot()
    {

        if (Times >= Timed)
        {
            Times = 0;
        }

        if (Times == 0)
        {
            GameObject Circle = Instantiate(Circle1);

            Circle.transform.position = this.transform.position;
 
        }



        
    }


}
