using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    //�X�s�[�h
    [SerializeField]
    private float speed = 3;

    [SerializeField]
    public float maxY, maxX, minY, minX;


    private Rigidbody2D rd;

//--------------------------------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        if (this.gameObject.CompareTag("Player_L1"))
        {
            //L1
            maxY = -2.6f; minY = -3.77f; maxX = 7.26f; minX = 2.74f;
        }
        else if (this.gameObject.CompareTag("Player_R2"))
        {
            //R2
            maxY = 3.77f; minY = -3.77f; maxX = 7.26f; minX = 2.74f;
        }

        else if (this.gameObject.CompareTag("Player_L2"))
        {
            //L2
            maxY = 3.74f; minY = 2.6f; maxX = -2.74f; minX = -7.27f;
        }
        else if (this.gameObject.CompareTag("Player_R1"))
        {
            //R1
            maxY = 3.74f; minY = -3.74f; maxX = -2.74f; minX = -7.27f;
        }



    }

//--------------------------------------------------------------------------------------

    void Update()
    {
        if(this.gameObject.CompareTag("Player_L1"))
        {
            MovePlayer_L1();
        }
        else if(this.gameObject.CompareTag("Player_L2"))
        {
            MovePlayer_L2();
        }
        else if(this.gameObject.CompareTag("Player_R1"))
        {
            MovePlayer_R1();
        }
        else if(this.gameObject.CompareTag("Player_R2"))
        {
            MovePlayer_R2();
        }
    }

//--------------------------------------------------------------------------------------

    void MovePlayer_L1()
    {
        //��������L�[�������ꂽ��
        if (Input.GetAxisRaw("Vertical_L1") > 0)
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
        //���������L�[�������ꂽ��
        else if (Input.GetAxisRaw("Vertical_L1") < 0)�@
        {
            Vector3 playerPos = transform.position;
            //�ʏ�ړ�
            playerPos.y -= speed * Time.deltaTime;
            //�ǉ�
            if (minY > playerPos.y)
            {
                playerPos.y = minY;
            }
            transform.position = playerPos;
        }

        //��������L�[�������ꂽ��
        if (Input.GetAxisRaw("Horizontal_L1") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            //�ʏ�ړ�
            playerPos.x += speed * Time.deltaTime; //y���W��speed�����Z

            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxX < playerPos.x)
            {
                playerPos.x = maxX; //PlayerPos��Y���W��maxY����
            }
            transform.position = playerPos; //���݂̈ʒu���ɔ��f������

        }
        else if (Input.GetAxisRaw("Horizontal_L1") < 0)�@//���������L�[�������ꂽ��
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

//--------------------------------------------------------------------------------------

    void MovePlayer_L2()
    {
        //��������L�[�������ꂽ��
        if (Input.GetAxisRaw("Vertical_L2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            //�ʏ�ړ�
            playerPos.y += speed * Time.deltaTime; //y���W��speed�����Z

            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxY < playerPos.y)
            {
                playerPos.y = maxY; //PlayerPos��Y���W��maxY����
            }
            transform.position = playerPos; //���݂̈ʒu���ɔ��f������

        }
        //���������L�[�������ꂽ��
        else if (Input.GetAxisRaw("Vertical_L2") < 0)
        {
            Vector3 playerPos = transform.position;
            //�ʏ�ړ�
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
            //�ʏ�ړ�
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
            //�ʏ�ړ�
            playerPos.x -= speed * Time.deltaTime;

            //�ǉ�
            if (minX > playerPos.x)
            {
                playerPos.x = minX;
            }
            transform.position = playerPos;
        }
    }

//--------------------------------------------------------------------------------------

    void MovePlayer_R1()
    {
        //��������L�[�������ꂽ��
        if (Input.GetAxisRaw("Vertical_R1") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            //�����ړ�
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerPos.y += (speed * 0.4f) * Time.deltaTime; //y���W��speed�����Z
            }
            //�ʏ�ړ�
            else
            {
                playerPos.y += speed * Time.deltaTime; //y���W��speed�����Z
            }

            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxY < playerPos.y)
            {
                playerPos.y = maxY; //PlayerPos��Y���W��maxY����
            }
            transform.position = playerPos; //���݂̈ʒu���ɔ��f������

        }
        //���������L�[�������ꂽ��
        else if (Input.GetAxisRaw("Vertical_R1") < 0)
        {
            Vector3 playerPos = transform.position;
            //�����ړ�
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerPos.y -= (speed * 0.4f) * Time.deltaTime; //y���W��speed�����Z
            }
            //�ʏ�ړ�
            else
            {
                playerPos.y -= speed * Time.deltaTime;
            }
            //�ǉ�
            if (minY > playerPos.y)
            {
                playerPos.y = minY;
            }
            transform.position = playerPos;
        }

        //��������L�[�������ꂽ��
        if (Input.GetAxisRaw("Horizontal_R1") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            //�����ړ�
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerPos.x += (speed * 0.4f) * Time.deltaTime; //y���W��speed�����Z
            }
            //�ʏ�ړ�
            else
            {
                playerPos.x += speed * Time.deltaTime; //y���W��speed�����Z
            }
            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxX < playerPos.x)
            {
                playerPos.x = maxX; //PlayerPos��Y���W��maxY����
            }
            transform.position = playerPos; //���݂̈ʒu���ɔ��f������

        }
        else if (Input.GetAxisRaw("Horizontal_R1") < 0)�@//���������L�[�������ꂽ��
        {
            Vector3 playerPos = transform.position;
            //�����ړ�
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerPos.x -= (speed * 0.4f) * Time.deltaTime; //y���W��speed�����Z
            }
            //�ʏ�ړ�
            else
            {
                playerPos.x -= speed * Time.deltaTime;
            }
            //�ǉ�
            if (minX > playerPos.x)
            {
                playerPos.x = minX;
            }
            transform.position = playerPos;
        }
    }

//--------------------------------------------------------------------------------------

    void MovePlayer_R2()
    {
        //��������L�[�������ꂽ��
        if (Input.GetAxisRaw("Vertical_R2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            //�����ړ�
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerPos.y += (speed * 0.4f) * Time.deltaTime; //y���W��speed�����Z
            }
            //�ʏ�ړ�
            else
            {
                playerPos.y += speed * Time.deltaTime; //y���W��speed�����Z
            }

            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxY < playerPos.y)
            {
                playerPos.y = maxY; //PlayerPos��Y���W��maxY����
            }
            transform.position = playerPos; //���݂̈ʒu���ɔ��f������

        }
        //���������L�[�������ꂽ��
        else if (Input.GetAxisRaw("Vertical_R2") < 0)
        {
            Vector3 playerPos = transform.position;
            //�����ړ�
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerPos.y -= (speed * 0.4f) * Time.deltaTime; //y���W��speed�����Z
            }
            //�ʏ�ړ�
            else
            {
                playerPos.y -= speed * Time.deltaTime;
            }
            //�ǉ�
            if (minY > playerPos.y)
            {
                playerPos.y = minY;
            }
            transform.position = playerPos;
        }

        //��������L�[�������ꂽ��
        if (Input.GetAxisRaw("Horizontal_R2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            //�����ړ�
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerPos.x += (speed * 0.4f) * Time.deltaTime; //y���W��speed�����Z
            }
            //�ʏ�ړ�
            else
            {
                playerPos.x += speed * Time.deltaTime; //y���W��speed�����Z
            }
            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxX < playerPos.x)
            {
                playerPos.x = maxX; //PlayerPos��Y���W��maxY����
            }
            transform.position = playerPos; //���݂̈ʒu���ɔ��f������

        }
        else if (Input.GetAxisRaw("Horizontal_R2") < 0)�@//���������L�[�������ꂽ��
        {
            Vector3 playerPos = transform.position;
            //�����ړ�
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerPos.x -= (speed * 0.4f) * Time.deltaTime; //y���W��speed�����Z
            }
            //�ʏ�ړ�
            else
            {
                playerPos.x -= speed * Time.deltaTime;
            }
            //�ǉ�
            if (minX > playerPos.x)
            {
                playerPos.x = minX;
            }
            transform.position = playerPos;
        }
    }

//--------------------------------------------------------------------------------------


}



