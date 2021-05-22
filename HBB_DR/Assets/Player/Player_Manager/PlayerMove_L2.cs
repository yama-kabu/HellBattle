using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_L2 : MonoBehaviour
{
    //private Vector2 player_pos;
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float maxY = 3.74f, minY = -3.74f, maxX = -2.74f, minX = -7.27f;
    private Rigidbody2D rd;

    //--------------------------------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    //--------------------------------------------------------------------------------------

    //�E�̃L�����N�^�[��p
    // Update is called once per frame
    void Update()
    {
        MovePlayer_L2();
    }
    void MovePlayer_L2()
    {
        //��������L�[�������ꂽ��
        if (Input.GetAxisRaw("Vertical_L2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            playerPos.y += speed * Time.deltaTime; //y���W��speed�����Z

            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxY < playerPos.y)
            {
                playerPos.y = maxY; //PlayerPos��Y���W��maxY����
            }
            transform.position = playerPos; //���݂̈ʒu���ɔ��f������

        }
        else if (Input.GetAxisRaw("Vertical_L2") < 0)�@//���������L�[�������ꂽ��
        {
            Vector3 playerPos = transform.position;
            playerPos.y -= speed * Time.deltaTime;

            //�ǉ�
            if (minY > playerPos.y)
            {
                playerPos.y = minY;
            }
            transform.position = playerPos;
        }

        //��������L�[�������ꂽ��
        if (Input.GetAxisRaw("Horizontal_L2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            playerPos.x += speed * Time.deltaTime; //y���W��speed�����Z

            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxX < playerPos.x)
            {
                playerPos.x = maxX; //PlayerPos��Y���W��maxY����
            }
            transform.position = playerPos; //���݂̈ʒu���ɔ��f������

        }
        else if (Input.GetAxisRaw("Horizontal_L2") < 0)�@//���������L�[�������ꂽ��
        {
            Vector3 playerPos = transform.position;
            playerPos.x -= speed * Time.deltaTime;

            //�ǉ�
            if (minX > playerPos.x)
            {
                playerPos.x = minX;
            }
            transform.position = playerPos;
        }
    }
}

//--------------------------------------------------------------------------------------


