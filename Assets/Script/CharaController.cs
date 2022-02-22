using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField]
    private bool isAttack;

    [SerializeField]
    private EnemyBase enemy;

    //敵のHP管理などへの干渉が必要になった時のためにCharaBase型を用意だけしておく
    [SerializeField]
    private CharaBase charaBase;
        

    /// <summary>
    /// 敵を感知
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay(Collider collision)
    {
        //if(enemy && enemy.isDead == true)
        //{
            //敵を感知したがその敵が死んでいる場合、処理しない
            //return;
        //}

        if(!isAttack && !enemy)
        {
            //Debug.Log("敵を発見");

            //敵を感知したら攻撃状態に入る
            if(collision.gameObject.TryGetComponent(out enemy))
            {
                //if(enemy.isDead == true)
                //{
                    //感知したけど敵が
                    //return;
                //}

                isAttack = true;

                StartCoroutine(PrepareteAttack());
            }
        }
        
    }


    /// <summary>
    /// 敵の感知解除
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent(out enemy))
        {
            //Debug.Log("敵なし");

            isAttack = false;

            enemy = null;

        }
    }

    

    /// <summary>
    /// 攻撃準備
    /// </summary>
    /// <returns></returns>
    public IEnumerator PrepareteAttack()
    {
        Debug.Log("攻撃準備開始");

        float timer = 0;

        float attackInterval = 300;

        while (isAttack)
        {
            timer += charaBase.attackSpeed;

            if(timer > attackInterval)
            {
                timer = 0;

                Attack();
            }

            yield return null;
        }


    }

    private void Attack()
    {
        //エネミーデータを計算させるために攻撃力を譲渡
        enemy.CalculateHp(charaBase.attackPower, this);


        //Debug.Log("攻撃");




        //エフェクトやダメージ処理
    }

    /// <summary>
    /// 敵を倒した時の感知解除
    /// </summary>
   public void DisarmChara()
    {
        isAttack = false;

        enemy = null;
    }

}
