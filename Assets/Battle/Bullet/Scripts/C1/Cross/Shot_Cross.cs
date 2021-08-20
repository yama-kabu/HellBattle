//��
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Cross : Shot_Common
{
//--------------------------------------------------------------------------------------
//�ϐ��n

    public float rotation = 0.4f; //�e�̉�]����ʂ���

    public bool is_direction;   //�e�̉�]���������������@true�F�E,false:��

//--------------------------------------------------------------------------------------
//���E�̈ړ�

    void Update()
    {
        #region is_direction�ɍ��킹�ĕ�����ς��鏈��
        {
            if (is_direction)
            {
                transform.Rotate(new Vector3(0, 0, rotation));
            }
            else if (!is_direction)
            {
                transform.Rotate(new Vector3(0, 0, -rotation));
            }
        }
        #endregion
        transform.Translate(0, bullet_Speed * 0.01f, 0);    //�e�𔭎˂����
    }

//--------------------------------------------------------------------------------------
}
