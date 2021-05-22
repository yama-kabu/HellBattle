using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_R2 : MonoBehaviour
{
    //private Vector2 player_pos;
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float maxY2 = 3.77f, minY2 = -3.77f, maxX2 = 7.26f, minX2 = 2.74f;
    private Rigidbody2D rd;

    //--------------------------------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    //--------------------------------------------------------------------------------------

    //���̃L�����N�^�[��p
    // Update is called once per frame
    void Update()
    {
        MovePlayer_R2();
    }
    void MovePlayer_R2()
    {
        //��������L�[�������ꂽ��
        if (Input.GetAxisRaw("Vertical_R2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            playerPos.y += speed * Time.deltaTime; //y���W��speed�����Z

            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxY2 < playerPos.y)
            {
                playerPos.y = maxY2; //PlayerPos��Y���W��maxY����
            }
            transform.position = playerPos; //���݂̈ʒu���ɔ��f������

        }
        else if (Input.GetAxisRaw("Vertical_R2") < 0) //���������L�[�������ꂽ��
        {
            Vector3 playerPos = transform.position;
            playerPos.y -= speed * Time.deltaTime;

            //�ǉ�
            if (minY2 > playerPos.y)
            {
                playerPos.y = minY2;
            }
            transform.position = playerPos;
        }

        //��������L�[�������ꂽ��
        if (Input.GetAxisRaw("Horizontal_R2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            playerPos.x += speed * Time.deltaTime; //y���W��speed�����Z

            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxX2 < playerPos.x)
            {
                playerPos.x = maxX2; //PlayerPos��Y���W��maxY����
            }
            transform.position = playerPos; //���݂̈ʒu���ɔ��f������

        }
        else if (Input.GetAxisRaw("Horizontal_R2") < 0) //���������L�[�������ꂽ��
        {
            Vector3 playerPos = transform.position;
            playerPos.x -= speed * Time.deltaTime;

            //�ǉ�
            if (minX2 > playerPos.x)
            {
                playerPos.x = minX2;
            }
            transform.position = playerPos;
        }
    }
}

