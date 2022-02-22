using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField]
    private bool isAttack;

    [SerializeField]
    private EnemyBase enemy;

    //�G��HP�Ǘ��Ȃǂւ̊����K�v�ɂȂ������̂��߂�CharaBase�^��p�ӂ������Ă���
    [SerializeField]
    private CharaBase charaBase;
        

    /// <summary>
    /// �G�����m
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay(Collider collision)
    {
        //if(enemy && enemy.isDead == true)
        //{
            //�G�����m���������̓G������ł���ꍇ�A�������Ȃ�
            //return;
        //}

        if(!isAttack && !enemy)
        {
            //Debug.Log("�G�𔭌�");

            //�G�����m������U����Ԃɓ���
            if(collision.gameObject.TryGetComponent(out enemy))
            {
                //if(enemy.isDead == true)
                //{
                    //���m�������ǓG��
                    //return;
                //}

                isAttack = true;

                StartCoroutine(PrepareteAttack());
            }
        }
        
    }


    /// <summary>
    /// �G�̊��m����
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent(out enemy))
        {
            //Debug.Log("�G�Ȃ�");

            isAttack = false;

            enemy = null;

        }
    }

    

    /// <summary>
    /// �U������
    /// </summary>
    /// <returns></returns>
    public IEnumerator PrepareteAttack()
    {
        Debug.Log("�U�������J�n");

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
        //�G�l�~�[�f�[�^���v�Z�����邽�߂ɍU���͂����n
        enemy.CalculateHp(charaBase.attackPower, this);


        //Debug.Log("�U��");




        //�G�t�F�N�g��_���[�W����
    }

    /// <summary>
    /// �G��|�������̊��m����
    /// </summary>
   public void DisarmChara()
    {
        isAttack = false;

        enemy = null;
    }

}
