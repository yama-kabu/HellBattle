using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "MyScriptable/Create BulletData")]
public class BulletData : ScriptableObject
{
	public string bulletName;
	public int m_hp;
	public int m_atk;
	public int m_speed;
}