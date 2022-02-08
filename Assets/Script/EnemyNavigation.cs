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
            //目的地の座標を取得
            agent.destination = goal.transform.position;

            //agentのspeedを敵ごとに用意した個別の数値に変更する
            agent.speed = moveSpeed;

            //valueにagentのspeedを代入して数値をvalueに保存しておく
            float value = agent.speed;

            //speedを０にして停止させる
            agent.speed = 0;

            yield return new WaitForSeconds(2.0f);

            //保存していた数値に戻す
            agent.speed = value;
        }
    }

}
