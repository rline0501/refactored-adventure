using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField, Header("�U����")]
    private int attackPower = 10;


    [SerializeField, Header("HP")]
    private int hp = 15;

    [SerializeField, Header("�U�����x")]
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
            Debug.Log("�G�𔭌�");

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
            Debug.Log("�G�Ȃ�");

            isAttack = false;

            enemy = null;

        }
    }

    /// <summary>
    /// �����L�����̌ʃX�e�[�^�X�ɏ㏑��
    /// </summary>
    /// <param name="attackPower"></param>
    /// <param name="Hp"></param>
    public void SetCharaStates(int attackPower, int hp)
    {
        this.attackPower = attackPower;
        this.hp = hp;
    }

    /// <summary>
    /// �U������
    /// </summary>
    /// <returns></returns>
    public IEnumerator PrepareteAttack()
    {
        Debug.Log("�U�������J�n");

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
        Debug.Log("�U��");

        //�G�t�F�N�g��_���[�W����
    }

}
