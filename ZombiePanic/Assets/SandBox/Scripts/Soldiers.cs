using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers : Human
{
    /// <summary>
    /// 最大体力
    /// </summary>
    const float MAX_HEALTH = 100;

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
    [SerializeField] private MODE mode = MODE.PATROLL;

    /// <summary>
    /// 敵ターゲット格納
    /// </summary>
    private Transform targetEnemy = null;

    /// <summary>
    /// 攻撃力
    /// </summary>
    private int power = 5;

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
        }
    }

    /// <summary>
    /// 警戒モード
    /// </summary>
    private void Wary()
    {
        // 体力が半分以上残っていれば戦い
        // 残っていなければ逃げる
        if (health >= MAX_HEALTH / 2)
        {
            agent.destination = targetEnemy.position;
            agent.stoppingDistance = 2;
            agent.speed = maxSpeed;
            mode = MODE.ATTACK;
        }
        else
        {
            agent.destination = GrobalStatus.evacuationPlace.position;
            mode = MODE.ESCAPE;
        }

    }

    /// <summary>
    /// 攻撃モード
    /// </summary>
    private void Attack()
    {
        // 射程距離まで近づいたら攻撃開始
        if (agent.remainingDistance <= 2)
        {
            // レイを飛ばして本当に攻撃が当たるのかを判定
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 10.0f))
            {
                // ダメージを与える
                GameObject obj = hit.collider.gameObject;
                if (obj.layer == mask)
                {
                    obj.GetComponent<Zombie>().AddDamage(power);
                }
            }
        }
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

            // キル数カウント
            if (isDead) GameManager.AddSoldierKillCount();
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
