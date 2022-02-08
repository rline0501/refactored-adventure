using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    private NavMeshAgent agent;

    //public GameObject goal;


    void Start()
    {
        //StartCoroutine(SetTarget());
    }

    void Update()
    {
        
    }

    public IEnumerator SetTarget(GameObject goal, float moveSpeed)
    {
        if (TryGetComponent(out agent))
        {
            //�ړI�n�̍��W���擾
            agent.destination = goal.transform.position;

            //agent��speed��G���Ƃɗp�ӂ����ʂ̐��l�ɕύX����
            agent.speed = moveSpeed;

            //value��agent��speed�������Đ��l��value�ɕۑ����Ă���
            float value = agent.speed;

            //speed���O�ɂ��Ē�~������
            agent.speed = 0;

            yield return new WaitForSeconds(2.0f);

            //�ۑ����Ă������l�ɖ߂�
            agent.speed = value;
        }
    }

}
