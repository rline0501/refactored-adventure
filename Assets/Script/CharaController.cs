using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField, Header("攻撃力")]
    private int attackPower = 10;

    [SerializeField, Header("HP")]
    private int hp = 15;

    [SerializeField, Header("攻撃速度")]
    private float attackSpeed = 60.0f;

    [SerializeField]
    private bool isAttack;

    [SerializeField]
    private EnemyNavigation enemy;

    //敵のHP管理などへの干渉が必要になった時のためにCharaBase型を用意だけしておく
    [SerializeField]
    private CharaBase charaBase;
        
    private void OnTriggerStay(Collider collision)
    {
        if(!isAttack && !enemy)
        {
            Debug.Log("敵を発見");

            //敵を感知したら攻撃状態に入る
            if(collision.gameObject.TryGetComponent(out enemy))
            {

                isAttack = true;

                StartCoroutine(PrepareteAttack());
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent(out enemy))
        {
            Debug.Log("敵なし");

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

        float attackInterval = 100;

        while (isAttack)
        {
            timer += attackSpeed;

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
        Debug.Log("攻撃");

        //エフェクトやダメージ処理
    }

}
