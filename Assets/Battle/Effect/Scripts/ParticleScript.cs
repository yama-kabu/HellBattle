using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public GameObject particleObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("aaa");
        if (collision.gameObject.tag == "Hit_Body_P1" || collision.gameObject.tag == "Hit_Body_P2") //Object�^�O�̕t�����Q�[���I�u�W�F�N�g�ƏՓ˂���������
        {
            Instantiate(particleObject, this.transform.position, Quaternion.identity); //�p�[�e�B�N���p�Q�[���I�u�W�F�N�g����
            //Destroy(this.gameObject); //�Փ˂����Q�[���I�u�W�F�N�g���폜
        }
    }
}
