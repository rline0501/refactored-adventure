using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("�U����")]
    private int attackPower = 5;

    [SerializeField, Header("HP")]
    private int hp = 5;


    /// <summary>
    /// �������ꂽ�G�̌ʃX�e�[�^�X��ݒ�
    /// </summary>
    /// <param name="attackPower"></param>
    /// <param name="hp"></param>
    public void SetEnemyStates(EnemyData enemyData)
    {
        this.attackPower = enemyData.attackPower;
        this.hp =enemyData.hp;
    }





}
