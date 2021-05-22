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

        HPSlider.maxValue = MaxHP;//スライダーの最大値の設定
        HPSlider.value = NowHP;//スライダーの現在値の設定
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))//左クリックで体力バーを減らす
        {
            HPSlider.value -= 10f;
        }

        if(Input.GetKey(KeyCode.K))
        {
            HPSlider.value += 0.1f;
        }
    }
}
