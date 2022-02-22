using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaBase : MonoBehaviour
{
    [SerializeField, Header("�U����")]
    public int attackPower = 5;

    [SerializeField]
    public int hp = 15;

    [SerializeField, Header("�U�����x")]
    public float attackSpeed = 2.0f;


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
