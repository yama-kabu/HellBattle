using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_L : MonoBehaviour
{
    //private Vector2 player_pos;
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float maxY = 3.74f, minY = -3.74f,maxX = -2.74f,minX = -7.27f;

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
        if (Input.GetKey(KeyCode.W))
        {
            //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            Vector3 playerPos = transform.position; 
            //y���W��speed�����Z
            playerPos.y += speed * Time.deltaTime; 

            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxY < playerPos.y)
            {
                //PlayerPos��Y���W��maxY����
                playerPos.y = maxY; 
            }
            //���݂̈ʒu���ɔ��f������
            transform.position = playerPos; 

        }

        //���������L�[�������ꂽ��
        else if (Input.GetKey(KeyCode.S))
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

        //�����E���L�[�������ꂽ��
        if (Input.GetKey(KeyCode.D))
        {
            //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            Vector3 playerPos = transform.position; 
            //y���W��speed�����Z
            playerPos.x += speed * Time.deltaTime; 

            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxX < playerPos.x)
            {
                //PlayerPos��Y���W��maxY����
                playerPos.x = maxX; 
            }
            //���݂̈ʒu���ɔ��f������
            transform.position = playerPos; 

        }

        //���������L�[�������ꂽ��
        else if (Input.GetKey(KeyCode.A))�@
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
