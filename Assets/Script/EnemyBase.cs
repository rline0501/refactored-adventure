using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("攻撃力")]
    private int attackPower = 5;

    [SerializeField, Header("HP")]
    private int hp = 5;

    public bool isDead;

    [SerializeField]
    private CapsuleCollider capCol;


    /// <summary>
    /// 生成された敵の個別ステータスを設定
    /// </summary>
    /// <param name="attackPower"></param>
    /// <param name="hp"></param>
    public void SetEnemyStates(EnemyData enemyData)
    {
        this.attackPower = enemyData.attackPower;
        this.hp =enemyData.hp;
    }


    /// <summary>
    /// 受け取ったキャラの攻撃力でエネミーのHPの計算処理
    /// </summary>
    /// <param name="attackPower">キャラの攻撃力</param>
    public void CalculateHp(int attackPower, CharaController charaController)
    {
        //if(isDead == true)
        //{
            //CharaController側にエネミーの情報を削除するように命令を出す
            
            
           // return;
        //}

        //引数で受け取った攻撃力分エネミーのHPを減らすのと、変化するHPの上下限値設定
        hp = Mathf.Clamp(hp -= attackPower, 0, 100);

        if(hp <= 0)
        {
            //isDead = true;

            //カプセルコライダーのチェックボックスを外すことで感知されなくする
            capCol.enabled = false;

            //倒すとExitが起動しなくなるので別の感知解除をする
            charaController.DisarmChara();

            DestroyEnemy();

            Debug.Log("敵の破壊");
        }
    }

    /// <summary>
    /// エネミーの撃破処理と演出
    /// </summary>
    private void DestroyEnemy()
    {


        //撃破アニメーション再生時間用の無敵状態起動（感知されない状態）


        //撃破アニメーション再生


        //オブジェクト消去
        Destroy(gameObject);

    }




}
