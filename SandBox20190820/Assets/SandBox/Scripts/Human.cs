using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    /// <summary>
    /// ナビメッシュエージェント
    /// </summary>
    [SerializeField] private NavMeshAgent agent;

    /// <summary>
    /// ターゲット判定
    /// </summary>
    public bool isTarget = false;

    /// <summary>
    /// 体力
    /// </summary>
    [SerializeField]private int health = 100;
    
    /// <summary>
    /// 死亡判定
    /// </summary>
    private bool isDead = false;

    /// <summary>
    /// 減速
    /// </summary>
    private const float lowSpeed = 0.5f;

    /// <summary>
    /// 初期処理
    /// </summary>
    private void Start()
    {
        // インスタンス取得
        agent = GetComponent<NavMeshAgent>();
        // 目的地取得
        StartCoroutine("SetDestination");
    }

    /// <summary>
    /// メインループ
    /// </summary>
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
    private IEnumerator SetDestination()
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

    /// <summary>
    /// ダメージ処理
    /// </summary>
    /// <param name="damage">ダメージ量</param>
    public void AddDamage(int damage)
    {
        // 死んでいなければダメージを受ける
        if (!isDead)
        {
            health -= damage;

            // 逃げ足を遅くする
            agent.speed = lowSpeed;

            // 体力が0以下になった場合
            if (health <= 0)
            {
                isDead = true;
                agent.speed = 0.0f;
            }
        }
    }

}
