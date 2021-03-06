using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    public EnemyNavigation enemyPrefab;

    [SerializeField]
    public Transform generatePos;

    [SerializeField]
    public GameObject goalPos;

    public bool isEnemyGenerate;

    public int generateIntervalTime;

    public int generateEnemyCount;

    public int maxEnemyCount;

    public EnemyDataSO enemyDataSO;

    void Start()
    {
        isEnemyGenerate = true;

        StartCoroutine(PreparateEnemyGenerate());
    }


    public IEnumerator PreparateEnemyGenerate()
    {
        //生成用タイマー
        int timer = 0;

        //isEnemyGenerateがtrueの間はループする
        while(isEnemyGenerate)
        {
            //タイマーを加算
            timer++;

            if (timer > generateIntervalTime)
            {

                //次の生成のためのタイマーをリセット
                timer = 0;

                //敵の生成
                GenerateEnemy();

                //生成した敵をカウントアップ
                generateEnemyCount++;

                //敵の最大生成数を超えたら
                if (generateEnemyCount >= maxEnemyCount)
                {
                    //生成停止
                    isEnemyGenerate = false;
                }
            }

            yield return null;

        }

    }

    /// <summary>
    /// 敵の生成と生成敵の個別ステータス用意
    /// </summary>
    public void GenerateEnemy()
    {
        //生成するエネミーの番号をEnemyDataSOから引っ張るためにGetEnemyDataに欲しいエネミーの番号を宣言する
        EnemyData enemydata = enemyDataSO.GetEnemyData(0);
        
        //↓でEnemyNavigationのgoalPos情報を使うのであらかじめ型として宣言しつつ、PrefabをgeneratePosに実体化
        EnemyNavigation enemy = Instantiate(enemyPrefab, generatePos.position, Quaternion.identity);

        //ゴール地点の情報と移動速度の情報をenemyに付与
        StartCoroutine(enemy.SetTarget(goalPos, enemydata.moveSpeed));

        //エネミーのステータスを、最初に拾ったEnemyDataSOのエネミーデータでSetEnemyStateで上書きする
        enemy.gameObject.GetComponent<EnemyBase> ().SetEnemyStates(enemydata);
    }


}
