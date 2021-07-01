using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPbar : MonoBehaviour
{
    public GameObject Player;

    public Slider HPGauge;

    private float PlayerHP,PlayerHPMax,CurrentHP;

    void Start()
    {
        PlayerHPMax = Player.GetComponent<Player_Manager_R>().m_Player_MAXHP;

        HPGauge.maxValue = PlayerHPMax;
    }

    private void Update()
    {
        PlayerHP = Player.GetComponent<Player_Manager_R>().m_Player_HP;

        HPGauge.value = PlayerHP;
    }
}
