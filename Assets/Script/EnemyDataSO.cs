using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO", menuName = "Create EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
    public List<EnemyData> enemyDatasList = new List<EnemyData>();

    /// <summary>
    /// SOからエネミーを検索
    /// </summary>
    /// <returns></returns>
    public EnemyData GetEnemyData(int searchEnemyNO)
    {
        foreach(EnemyData data in enemyDatasList)
        {
            if(data.enemyNo == searchEnemyNO)
            {
                return data;
            }
        }
        return null;
    }
}
