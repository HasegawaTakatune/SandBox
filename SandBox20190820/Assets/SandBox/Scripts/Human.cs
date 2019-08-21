using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    /// <summary>
    /// ナビメッシュエージェント
    /// </summary>
    [SerializeField] private NavMeshAgent agent;

    public bool isTarget = false;

    /// <summary>
    /// 初期処理
    /// </summary>
    void Start()
    {
        // インスタンス取得
        agent = GetComponent<NavMeshAgent>();        
        // 目的地取得
        StartCoroutine("SetDestination");
    }

    private void Update()
    {
        // セーフゾーンにたどり着いた場合
        if (agent.remainingDistance <= 1)
        {
            isTarget = false;
        }
    }

    /// <summary>
    /// 目的地設定
    /// </summary>
    IEnumerator SetDestination()
    {
        // 目的地が取得できるまでループする
        while (true)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            if (GrobalStatus.evacuationPlace != null)
            {
                agent.destination = GrobalStatus.evacuationPlace.position;
                break;
            }

        }
    }

}
