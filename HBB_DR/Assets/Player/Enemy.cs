using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D Temporary_Enemy;
    //���@�̈ړ����x���i�[����ϐ��i�����l�T�j
    public float Speed = 5;

    public int Enemy_MAXHP;
    public int Enemy_HP;

    //�v���C���[���x
    public Vector2 PlayerSpeed = new Vector2(0.005f, 0.005f);
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2D�@�R���|�[�l���g���擾���ĕϐ��@Player_L�@�Ɋi�[
        Temporary_Enemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }


}
