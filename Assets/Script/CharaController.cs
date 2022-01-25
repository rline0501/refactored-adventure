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

    [SerializeField]
    private CharaGenerator chara;
        
    private void OnTriggerStay(Collider collision)
    {
        if(!isAttack && !enemy)
        {
            Debug.Log("敵を発見");

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
    /// 味方キャラの個別ステータスに上書き
    /// </summary>
    /// <param name="attackPower"></param>
    /// <param name="Hp"></param>
    public void SetCharaStates(int attackPower, int hp)
    {
        this.attackPower = attackPower;
        this.hp = hp;
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
