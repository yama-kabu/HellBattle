using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [Header("�G�t�F�N�g��\�����鏇�ɓ����")]
    [SerializeField]
    private List<GameObject> EffectList;

    [Header("�e�G�t�F�N�g��؂�ւ���܂ł̎���")]
    [SerializeField]
    private List<float> EffectTime;

    [Header("�eeffect�̑傫��")]
    [SerializeField]
    private List<float> EffectSize;

    private float CountTime = 0;
    private bool EffectUp = false;
    private int E_No = 0;
    private GameObject BuckEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EffectUp == false)
        {
            //�G�t�F�N�g��\��
            BuckEffect = Instantiate(EffectList[E_No]);
            Vector3 EffectScale;
            EffectScale.x = EffectScale.y = EffectScale.z = EffectSize[E_No];
            BuckEffect.transform.localScale = EffectScale;

            EffectUp = true;
            //Debug.Log(E_No);
        }

        //�G�t�F�N�g��؂�ւ���܂ł̃J�E���g
        CountTime += Time.deltaTime;

        if(CountTime >= EffectTime[E_No])
        {
            //�\�����̃G�t�F�N�g������
            Destroy(BuckEffect);

            //���̃G�t�F�N�g�ɐ؂�ւ���
            if(E_No == 4)
            {
                E_No = 0;
            }
            else
            {
                E_No += 1;
            }

            CountTime = 0;
            EffectUp = false;
        }
    }
}
