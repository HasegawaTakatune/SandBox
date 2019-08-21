using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    /// <summary>
    /// ナビメッシュエージェント
    /// </summary>
    private NavMeshAgent agent;

    /// <summary>
    /// 初期処理
    /// </summary>
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestination(GrobalStatus.evacuationPlace.position);
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 目的地設定
    /// </summary>
    void SetDestination(Vector3 inpEvacuationPlace)
    {
        agent.destination = inpEvacuationPlace;
    }

}
