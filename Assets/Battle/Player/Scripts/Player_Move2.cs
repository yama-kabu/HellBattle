using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move2 : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//�Q�ƌn

    GameObject System;     //���s�����Ă��邩���`�F�b�N���邽�߂̕ϐ�����
    GameObject player_l2;   //�ړ��p�L�����̊i�[����ϐ�����
    Player_Manager_L pl;    //�L�����N�^�[�̈ʒu��������ϐ�����
    private Rigidbody2D rd; //�e��Rigidbody2D���i�[����ϐ�����

//--------------------------------------------------------------------------------------
//�ϐ��n

    public float Character_Speed; //�Q�Ƃ����L�����N�^�[�X�s�[�h�̊m�F
    [SerializeField]
    private float player_speed; //�L�����N�^�[�̑��x���������
    [SerializeField]
    public float maxY, maxX, minY, minX;    //�L�����N�^�[�̈ړ��ł��镝�ɐ����������

//--------------------------------------------------------------------------------------
//�ŏ��̏���

    void Start()
    {
        System = GameObject.Find("Game_Setting");     //���sBool���擾�����
        rd = GetComponent<Rigidbody2D>();   //�e�ɂ��Ă���Rigidbody2D�������
        #region �ړ��͈͂̐ݒ�
        if (this.gameObject.CompareTag("Player_R2"))
        {
            maxY = 725f; minY = -730f; maxX = 1335f; minX = 460f;  //R2�L�����N�^�[�̈ړ��ł���͈͂���
        }
        else if (this.gameObject.CompareTag("Player_L2"))
        {
            maxY = 725f; minY = 446f; maxX = -460f; minX = -1335f;  //L2�L�����N�^�[�̈ړ��ł���͈͂���
        }

        if (this.gameObject.CompareTag("Player_L2"))
        {
            pl = GameObject.Find("Player_L2").GetComponent<Player_Manager_L>();    //�L�����N�^�[�̑��x���擾�����
            Character_Speed = pl.Character;    //�L�����N�^�[�̑��x�ƈꏏ�ɂ����
        }
        else if (this.gameObject.CompareTag("Player_R2"))
        {
            pl = GameObject.Find("Player_L2").GetComponent<Player_Manager_L>();    //�L�����N�^�[�̑��x���擾�����
            Character_Speed = pl.Character;    //�L�����N�^�[�̑��x�ƈꏏ�ɂ����
        }
        #endregion
        #region �L�����N�^�[���Ƃ̃X�s�[�h�ݒ�
        //�L�����N�^�[�X�s�[�h�ݒ�
        if (Character_Speed == 1)
        {
            player_speed = 500;
        }
        else if (Character_Speed == 2)
        {
            player_speed = 1500;
        }
        if (Character_Speed == 3)
        {
            player_speed = 500;
        }
        else if (Character_Speed == 4)
        {
            player_speed = 1500;
        }
        #endregion
    }

//--------------------------------------------------------------------------------------

    void Update()
    {
        //���s�����Ă��Ȃ������ꍇ�ړ�������
        if (System.GetComponent<Start_Timer>().is_start_chack && !System.GetComponent<Setting>().syouhai)
        {
            if (this.gameObject.CompareTag("Player_L2"))
            {
                MovePlayer_L2();
            }

            else if (this.gameObject.CompareTag("Player_R2"))
            {
                MovePlayer_R2();
            }
        }
    }

//--------------------------------------------------------------------------------------

    void MovePlayer_L2()
    {
        //L2�̈ړ�
        #region ��������L�[�������ꂽ��
        if (Input.GetAxisRaw("Vertical_L2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            //�ʏ�ړ�
            playerPos.y += player_speed * Time.deltaTime; //y���W��speed�����Z

            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxY < playerPos.y)
            {
                playerPos.y = maxY; //PlayerPos��Y���W��maxY����
            }
            transform.position = playerPos; //���݂̈ʒu���ɔ��f������
        }
        #endregion
        #region ���������L�[�������ꂽ��
        else if (Input.GetAxisRaw("Vertical_L2") < 0)
        {
            Vector3 playerPos = transform.position;
            //�ʏ�ړ�
            playerPos.y -= player_speed * Time.deltaTime;

            //�ǉ�
            if (minY > playerPos.y)
            {
                playerPos.y = minY;
            }
            transform.position = playerPos;
        }
        #endregion
        #region �����E���L�[�������ꂽ��
        if (Input.GetAxisRaw("Horizontal_L2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            //�ʏ�ړ�
            playerPos.x += player_speed * Time.deltaTime; //y���W��speed�����Z
            
            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxX < playerPos.x)
            {
                playerPos.x = maxX; //PlayerPos��Y���W��maxY����
            }
            transform.position = playerPos; //���݂̈ʒu���ɔ��f������
        }
        #endregion
        #region ���������L�[�������ꂽ��
        else if (Input.GetAxisRaw("Horizontal_L2") < 0)�@
        {
            Vector3 playerPos = transform.position;
            //�ʏ�ړ�
            playerPos.x -= player_speed * Time.deltaTime;
            //�ǉ�
            if (minX > playerPos.x)
            {
                playerPos.x = minX;
            }
            transform.position = playerPos;
        }
        #endregion
    }

//--------------------------------------------------------------------------------------

    void MovePlayer_R2()
    {
        //R2�̈ړ�
        #region ��������L�[�������ꂽ��
        if (Input.GetAxisRaw("Vertical_R2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            //�����ړ�
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Button_L2"))
            {
                playerPos.y += (player_speed * 0.4f) * Time.deltaTime; //y���W��speed�����Z
            }
            //�ʏ�ړ�
            else
            {
                playerPos.y += player_speed * Time.deltaTime; //y���W��speed�����Z
            }

            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxY < playerPos.y)
            {
                playerPos.y = maxY; //PlayerPos��Y���W��maxY����
            }
            transform.position = playerPos; //���݂̈ʒu���ɔ��f������
        }
        #endregion
        #region ���������L�[�������ꂽ��
        else if (Input.GetAxisRaw("Vertical_R2") < 0)
        {
            Vector3 playerPos = transform.position;
            //�����ړ�
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Button_L2"))
            {
                playerPos.y -= (player_speed * 0.4f) * Time.deltaTime; //y���W��speed�����Z
            }
            //�ʏ�ړ�
            else
            {
                playerPos.y -= player_speed * Time.deltaTime;
            }
            //�ǉ�
            if (minY > playerPos.y)
            {
                playerPos.y = minY;
            }
            transform.position = playerPos;
        }
        #endregion
        #region �����E���L�[�������ꂽ��
        if (Input.GetAxisRaw("Horizontal_R2") > 0)
        {
            Vector3 playerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
            //�����ړ�
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Button_L2"))
            {
                playerPos.x += (player_speed * 0.4f) * Time.deltaTime; //y���W��speed�����Z
            }
            //�ʏ�ړ�
            else
            {
                playerPos.x += player_speed * Time.deltaTime; //y���W��speed�����Z
            }
            //�ǉ�
            //����playerPos��Y���W��maxY�i�ő�Y���W�j���傫���Ȃ�����
            if (maxX < playerPos.x)
            {
                playerPos.x = maxX; //PlayerPos��Y���W��maxY����
            }
            transform.position = playerPos; //���݂̈ʒu���ɔ��f������
        }
        #endregion
        #region ���������L�[�������ꂽ��
        else if (Input.GetAxisRaw("Horizontal_R2") < 0)
        {
            Vector3 playerPos = transform.position;
            //�����ړ�
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Button_L2"))
            {
                playerPos.x -= (player_speed * 0.4f) * Time.deltaTime; //y���W��speed�����Z
            }
            //�ʏ�ړ�
            else
            {
                playerPos.x -= player_speed * Time.deltaTime;
            }
            //�ǉ�
            if (minX > playerPos.x)
            {
                playerPos.x = minX;
            }
            transform.position = playerPos;
        }
        #endregion
    }

//--------------------------------------------------------------------------------------

}



