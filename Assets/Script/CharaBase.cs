using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaBase : MonoBehaviour
{
    [SerializeField, Header("�U����")]
    private int attackPower = 5;

    [SerializeField]
    private int hp = 15;


    /// <summary>
    /// �L�����̃X�e�[�^�X���㏑������
    /// </summary>
    /// <param name="charaData"></param>
    public void SetCharaStates(CharaData charaData)
    {
        this.attackPower = charaData.attackPower;
        this.hp = charaData.hp;
    }

}
