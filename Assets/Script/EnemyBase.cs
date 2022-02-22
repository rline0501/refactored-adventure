using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("�U����")]
    private int attackPower = 5;

    [SerializeField, Header("HP")]
    private int hp = 5;

    public bool isDead;

    [SerializeField]
    private CapsuleCollider capCol;


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


    /// <summary>
    /// �󂯎�����L�����̍U���͂ŃG�l�~�[��HP�̌v�Z����
    /// </summary>
    /// <param name="attackPower">�L�����̍U����</param>
    public void CalculateHp(int attackPower, CharaController charaController)
    {
        //if(isDead == true)
        //{
            //CharaController���ɃG�l�~�[�̏����폜����悤�ɖ��߂��o��
            
            
           // return;
        //}

        //�����Ŏ󂯎�����U���͕��G�l�~�[��HP�����炷�̂ƁA�ω�����HP�̏㉺���l�ݒ�
        hp = Mathf.Clamp(hp -= attackPower, 0, 100);

        if(hp <= 0)
        {
            //isDead = true;

            //�J�v�Z���R���C�_�[�̃`�F�b�N�{�b�N�X���O�����ƂŊ��m����Ȃ�����
            capCol.enabled = false;

            //�|����Exit���N�����Ȃ��Ȃ�̂ŕʂ̊��m����������
            charaController.DisarmChara();

            DestroyEnemy();

            Debug.Log("�G�̔j��");
        }
    }

    /// <summary>
    /// �G�l�~�[�̌��j�����Ɖ��o
    /// </summary>
    private void DestroyEnemy()
    {


        //���j�A�j���[�V�����Đ����ԗp�̖��G��ԋN���i���m����Ȃ���ԁj


        //���j�A�j���[�V�����Đ�


        //�I�u�W�F�N�g����
        Destroy(gameObject);

    }




}
