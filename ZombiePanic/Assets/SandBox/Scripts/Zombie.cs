using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    /// <summary>
    /// アニメータ
    /// </summary>
    [SerializeField] private Animator animator;

    /// <summary>
    /// 追尾のコンポーネント
    /// </summary>
    [SerializeField] private NavMeshAgent agent;

    /// <summary>
    /// 体力
    /// </summary>
    [SerializeField] private int health = 100;

    /// <summary>
    /// 攻撃力
    /// </summary>
    [SerializeField] private int power = 20;

    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField] private float speed = 8;

    /// <summary>
    /// 死亡判定
    /// </summary>
    public bool isDead = false;

    /// <summary>
    /// 初期設定
    /// </summary>
    private void Start()
    {
        // ナビメッシュエージェント取得
        agent = GetComponent<NavMeshAgent>();

        // アニメータ取得
        animator = GetComponent<Animator>();

        // 速度設定
        agent.speed = speed;

        // ターゲットが設定された際に通知するように設定
        GrobalStatus.SubscriveTargetEvent((GrobalStatus.OnTargetEvent)OnSetTarget);
    }

    /// <summary>
    /// オブジェクトが廃棄された際に呼ばれるイベント
    /// </summary>
    private void OnDestroy()
    {
        // ターゲットが設定された際の通知を解除する
        GrobalStatus.UnSubscribeTargetEvent((GrobalStatus.OnTargetEvent)OnSetTarget);
    }

    /// <summary>
    /// ターゲット設定（通知登録用）
    /// </summary>
    /// <param name="target">ターゲット</param>
    public void OnSetTarget(Vector3 target)
    {
        // 歩くアニメーション再生
        animator.SetTrigger(GrobalStatus.ANIM_WALK);
        agent.destination = target;
    }

    /// <summary>
    /// 当たり判定
    /// </summary>
    /// <param name="collision">当たった対象の情報</param>
    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Human")
        {
            // 攻撃アニメーション再生
            animator.SetTrigger(GrobalStatus.ANIM_ATTACK);

            // ダメージを与える
            obj.GetComponent<Human>().AddDamage(power);
        }
    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    /// <param name="damage"></param>
    public void AddDamage(int damage)
    {
        if (!isDead)
        {
            health -= damage;
            if (health <= 0)
            {
                // 死亡アニメーション再生
                animator.SetTrigger(GrobalStatus.ANIM_DEAD);
                isDead = true;
            }
        }
    }    
}
