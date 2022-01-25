using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("攻撃力")]
    private int attackPower = 5;

    [SerializeField, Header("HP")]
    private int hp = 5;


    /// <summary>
    /// 生成された敵の個別ステータスを設定
    /// </summary>
    /// <param name="attackPower"></param>
    /// <param name="hp"></param>
    public void SetEnemyStates(int attackPower, int hp)
    {
        this.attackPower = attackPower;
        this.hp = hp;
    }





}
