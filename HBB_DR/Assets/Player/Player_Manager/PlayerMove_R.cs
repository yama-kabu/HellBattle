using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_R : MonoBehaviour
{
    //private Vector2 player_pos;
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float maxY2 =3.77f, minY2 = -3.77f,maxX2 = 7.26f,minX2 = 2.74f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {

        //��������L�[�������ꂽ��
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            Vector3 playerPos = transform.position;
            //y���W��speed�����Z
            playerPos.y += speed * Time.deltaTime;

            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxY2 < playerPos.y)
            {
                //PlayerPos��Y���W��maxY����
                playerPos.y = maxY2;
            }
            //���݂̈ʒu���ɔ��f������
            transform.position = playerPos;

        }

        //���������L�[�������ꂽ��
        else if (Input.GetKey(KeyCode.DownArrow))
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

        //�����E���L�[�������ꂽ��
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            Vector3 playerPos = transform.position;
            //y���W��speed�����Z
            playerPos.x += speed * Time.deltaTime;

            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxX2 < playerPos.x)
            {
                //PlayerPos��Y���W��maxY����
                playerPos.x = maxX2;
            }
            //���݂̈ʒu���ɔ��f������
            transform.position = playerPos;

        }

        //���������L�[�������ꂽ��
        else if (Input.GetKey(KeyCode.LeftArrow))
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
