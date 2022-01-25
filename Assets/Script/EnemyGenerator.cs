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

    void Start()
    {
        isEnemyGenerate = true;

        StartCoroutine(PreparateEnemyGenerate());
    }


    public IEnumerator PreparateEnemyGenerate()
    {
        //�����p�^�C�}�[
        int timer = 0;

        //isEnemyGenerate��true�̊Ԃ̓��[�v����
        while(isEnemyGenerate)
        {
            //�^�C�}�[�����Z
            timer++;

            if (timer > generateIntervalTime)
            {

                //���̐����̂��߂̃^�C�}�[�����Z�b�g
                timer = 0;

                //�G�̐���
                GenerateEnemy();

                //���������G���J�E���g�A�b�v
                generateEnemyCount++;

                //�G�̍ő吶�����𒴂�����
                if (generateEnemyCount >= maxEnemyCount)
                {
                    //������~
                    isEnemyGenerate = false;
                }
            }

            yield return null;

        }

    }

    /// <summary>
    /// �G�̐����Ɛ����G�̌ʃX�e�[�^�X�p��
    /// </summary>
    public void GenerateEnemy()
    {
        EnemyNavigation enemy = Instantiate(enemyPrefab, generatePos.position, Quaternion.identity);

        StartCoroutine(enemy.SetTarget(goalPos));

        enemy.gameObject.GetComponent<EnemyBase> ().SetEnemyStates(10, 10);
    }


}
