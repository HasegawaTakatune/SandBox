using UnityEngine;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    /// <summary>
    /// ナビメッシュエージェント
    /// </summary>
    [SerializeField] protected NavMeshAgent agent;

    /// <summary>
    /// ターゲット判定
    /// </summary>
    [SerializeField] public bool isTarget = false;

    /// <summary>
    /// 死亡判定
    /// </summary>
    protected bool isDead = false;

    /// <summary>
    /// 減速
    /// </summary>
    protected const float lowSpeed = 0.5f;

    /// <summary>
    /// 体力
    /// </summary>
    protected int health = 100;

    /// <summary>
    /// 初期処理
    /// </summary>
    protected virtual void Start()
    {
        // インスタンス取得
        agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    /// <param name="damage">ダメージ量</param>
    public virtual void AddDamage(int damage)
    {
        // ダメージを受ける        
        health -= damage;

        // 逃げ足を遅くする
        agent.speed = lowSpeed;

        // 体力が0以下になった場合
        if (health <= 0)
        {
            isDead = true;
            isTarget = false;
            agent.speed = 0.0f;
        }
    }

}
