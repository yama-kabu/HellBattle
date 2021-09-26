using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Set_Image : MonoBehaviour
{
    public Image image; //�C���[�W��������悤�ɂ����
    public GameObject search_character_number; //�L�����N�^�[�̑I�����ɑI�΂��ϐ����Q�Ƃ����
    private Sprite sprite;  //�X�v���C�g��������悤�ɂ����

    void Start()
    {
        if(search_character_number.GetComponent<Player_Manager_L>().Character == 1)
        {
            sprite = Resources.Load<Sprite>("Chara1");
            image.sprite = sprite;
        }
        else if (search_character_number.GetComponent<Player_Manager_L>().Character == 2)
        {
            sprite = Resources.Load<Sprite>("Chara2");
            image.sprite = sprite;
        }
        if (search_character_number.GetComponent<Player_Manager_L>().Character == 3)
        {
            sprite = Resources.Load<Sprite>("Chara3");
            image.sprite = sprite;
        }
        else if (search_character_number.GetComponent<Player_Manager_L>().Character == 4)
        {
            sprite = Resources.Load<Sprite>("Chara4");
            image.sprite = sprite;
        }
    }
}