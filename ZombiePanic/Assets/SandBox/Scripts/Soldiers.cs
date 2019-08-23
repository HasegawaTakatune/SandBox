using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers : Human
{
    /// <summary>
    /// 衝突する対象のレイヤ
    /// </summary>
    [SerializeField] private LayerMask mask;

    /// <summary>
    /// 巡回ルートの管理クラス
    /// </summary>
    [SerializeField] private PatrollingManager patrolling;

    /// <summary>
    /// 巡回ルート
    /// </summary>
    private int patrollRoute;

    /// <summary>
    /// 巡回ルートの進行度
    /// </summary>
    private int patrollIndex;

    /// <summary>
    /// モード列挙
    /// </summary>
    private enum MODE
    {
        /// <summary>
        /// 巡回モード
        /// </summary>
        PATROLL,
        /// <summary>
        /// 警戒モード
        /// </summary>
        WARY,
        /// <summary>
        /// 攻撃モード
        /// </summary>
        ATTACK,
        /// <summary>
        /// 逃走モード
        /// </summary>
        ESCAPE
    }
    /// <summary>
    /// モード
    /// </summary>
    private MODE mode = MODE.PATROLL;

    /// <summary>
    /// 敵ターゲット格納
    /// </summary>
    private Transform targetEnemy = null;

    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Start()
    {
        base.Start();
        SetPatrollInfo(0);

    }

    /// <summary>
    /// メインループ
    /// </summary>
    void Update()
    {
        // モードごとに分岐
        switch (mode)
        {

            case MODE.PATROLL: Patroll(); break;    // 巡回            
            case MODE.WARY: Wary(); break;          // 警戒            
            case MODE.ATTACK: Attack(); break;      // 攻撃            
            case MODE.ESCAPE: Escape(); break;      // 逃走
        }
    }

    /// <summary>
    /// 巡回モード
    /// </summary>
    private void Patroll()
    {
        // SphereCastの半径
        float radius = 10.0f;
        // SphereCastの距離
        int length = 4;

        // 目的地に近づいたら、次の目的地を設定する
        if (agent.remainingDistance <= 1)
        {
            patrollIndex = patrolling.GetNextIndex(patrollRoute, patrollIndex);
            agent.destination = patrolling.GetTarget(patrollRoute, patrollIndex);
        }

        // 正面に球型の当たり判定を飛ばす
        if (Physics.SphereCast(transform.position, radius, transform.forward * length, out RaycastHit hit, length, mask))
        {
            targetEnemy = hit.transform;
            mode = MODE.WARY;
            Debug.Log(hit.collider.name);
        }
    }

    private void OnDrawGizmos()
    {
        // SphereCastの半径
        float radius = 10.0f;
        // SphereCastの距離
        int length = 4;

        if (Physics.SphereCast(transform.position, radius, transform.forward * length, out RaycastHit hit, length, mask))
        {
            Gizmos.color = Color.red;
            //Gizmos.DrawSphere(transform.position + transform.forward * length, radius);
            Debug.Log(hit.collider.name);
            Gizmos.DrawSphere(hit.point, 0.5f);
        }
        else Gizmos.DrawSphere(transform.position + transform.forward * length, radius);
    }

    /// <summary>
    /// 警戒モード
    /// </summary>
    private void Wary()
    {

    }

    /// <summary>
    /// 攻撃モード
    /// </summary>
    private void Attack()
    {

    }

    /// <summary>
    /// 逃走モード
    /// </summary>
    private void Escape()
    {

    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    /// <param name="damage">ダメージ量</param>
    public override void AddDamage(int damage)
    {
        if (!isDead)
        {
            base.AddDamage(damage);
        }
    }

    /// <summary>
    /// 巡回情報設定
    /// </summary>
    /// <param name="setRoute">巡回ルート</param>
    public void SetPatrollInfo(int setRoute)
    {
        patrollRoute = setRoute;
        patrollIndex = 0;
        agent.destination = patrolling.GetTarget(patrollRoute, patrollIndex);
    }
}
