using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPbar : MonoBehaviour
{
    Slider HPSlider;
    // Start is called before the first frame update
    void Start()
    {
        HPSlider = GetComponent<Slider>();

        float MaxHP = 200f;
        float NowHP = 200f;

        HPSlider.maxValue = MaxHP;//�X���C�_�[�̍ő�l�̐ݒ�
        HPSlider.value = NowHP;//�X���C�_�[�̌��ݒl�̐ݒ�
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))//���N���b�N�ő̗̓o�[�����炷
        {
            HPSlider.value -= 10f;
        }

        if(Input.GetKey(KeyCode.K))
        {
            HPSlider.value += 0.1f;
        }
    }
}
