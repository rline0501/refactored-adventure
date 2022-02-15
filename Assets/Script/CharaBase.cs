using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaBase : MonoBehaviour
{
    [SerializeField, Header("攻撃力")]
    private int attackPower = 5;

    [SerializeField]
    private int hp = 15;


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
