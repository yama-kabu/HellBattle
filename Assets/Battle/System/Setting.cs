//ƒ‹
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
//--------------------------------------------------------------------------------------
//QÆŒn

    //Ÿ”s‚ªŒˆ‚Ü‚Á‚½‚©  false= ‚Ü‚½I‚í‚Á‚Ä‚¢‚È‚¢B true= I‚í‚Á‚½
    public bool syouhai = false;

//--------------------------------------------------------------------------------------
//Å‰‚Ì€”õ
    void Start()
    {
        Application.targetFrameRate = 240; //FPS‚ğ240‚Éİ’è 
    }

//--------------------------------------------------------------------------------------
//ƒQ[ƒ€‚ÌŸ”s‚ÉŠÖ‚·‚éˆ—‚Æ’e‚ÌŒãˆ—

    private void Update()
    {
        //Ÿ”s‚ª‚Â‚¢‚½‚çÁ‹ŠJn
        if (syouhai)
        {
            zenkesi();
        }
    }
    //Á‹‚Ì’†g
    void zenkesi()
    {
        //‚ ‚è‚Æ‚ ‚ç‚ä‚é’e‚ğˆê‚Â‚É‚Ü‚Æ‚ß‚é
        GameObject[] Bullets = GameObject.FindGameObjectsWithTag("Bullet");
        Clean(Bullets);
        Bullets = GameObject.FindGameObjectsWithTag("Bullet_1");
        Clean(Bullets);
        Bullets = GameObject.FindGameObjectsWithTag("Bullet_2");
        Clean(Bullets);
        Bullets = GameObject.FindGameObjectsWithTag("Bullet_3");
        Clean(Bullets);
    }
    //Á‚·‚º‚¦‚¦‚¦‚¦‚¦
    void Clean(GameObject[] Bullets)
    {
        foreach (GameObject AllBullet in Bullets)
        {
            //‚ ‚è‚Æ‚ ‚ç‚ä‚é’e‚ğ”j‰ó
            Destroy(AllBullet);
        }
    }
}
