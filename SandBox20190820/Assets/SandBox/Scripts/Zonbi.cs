using UnityEngine;
using UnityEngine.AI;

public class Zonbi : MonoBehaviour
{
    /// <summary>
    /// 追尾のコンポーネント
    /// </summary>
    [SerializeField] private NavMeshAgent agent;

    private int power = 20;

    /// <summary>
    /// 初期設定
    /// </summary>
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
            obj.GetComponent<Human>().AddDamage(power);
        }
    }
}
