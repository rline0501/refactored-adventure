using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField, Header("UŒ‚—Í")]
    private int attackPower = 10;

    [SerializeField, Header("UŒ‚‘¬“x")]
    private float attackSpeed = 60.0f;

    [SerializeField]
    private bool isAttack;

    [SerializeField]
    private EnemyNavigation enemy;
        
    private void OnTriggerStay(Collider collision)
    {
        if(!isAttack && !enemy)
        {
            Debug.Log("“G‚ğ”­Œ©");

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
            Debug.Log("“G‚È‚µ");

            isAttack = false;

            enemy = null;

        }
    }

    /// <summary>
    /// UŒ‚€”õ
    /// </summary>
    /// <returns></returns>
    public IEnumerator PrepareteAttack()
    {
        Debug.Log("UŒ‚€”õŠJn");

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
        Debug.Log("UŒ‚");

        //ƒGƒtƒFƒNƒg‚âƒ_ƒ[ƒWˆ—
    }

}
