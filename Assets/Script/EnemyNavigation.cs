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

    public IEnumerator SetTarget(GameObject goal)
    {
        if (TryGetComponent(out agent))
        {
            agent.destination = goal.transform.position;

            float value = agent.speed;

            agent.speed = 0;

            yield return new WaitForSeconds(2.0f);

            agent.speed = value;
        
        
        }
    }

}
