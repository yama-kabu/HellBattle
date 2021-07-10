using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPerson : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            SoundManager.Instance.PlaySE(SE.knife);
        }
    }
}
