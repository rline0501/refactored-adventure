using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaBase : MonoBehaviour
{
    [SerializeField, Header("攻撃力")]
    public int attackPower = 5;

    [SerializeField]
    public int hp = 15;

    [SerializeField, Header("攻撃速度")]
    public float attackSpeed = 2.0f;


    /// <summary>
    /// キャラのステータスを上書きする
    /// </summary>
    /// <param name="charaData"></param>
    public void SetCharaStates(CharaData charaData)
    {
        this.attackPower = charaData.attackPower;
        this.hp = charaData.hp;
    }

}
