using System.Collections;
using UnityEngine;

public class Citizens : Human
{
    /// <summary>
    /// 初期処理
    /// </summary>
    protected override void Start()
    {
        // ベースクラスの初期化呼び出し
        base.Start();
        // 目的地取得
        StartCoroutine("SetDestination");
    }

    /// <summary>
    /// メインループ
    /// </summary>
    void Update()
    {
        // セーフゾーンにたどり着いた場合
        if (agent.remainingDistance <= 2)
        {
            isTarget = false;
        }
    }

    /// <summary>
    /// 目的地設定
    /// </summary>
    protected IEnumerator SetDestination()
    {
        // 目的地が取得できるまでループする
        while (true)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            if (GrobalStatus.evacuationPlace != null)
            {
                agent.destination = GrobalStatus.evacuationPlace.position;
                GetComponent<Animation>().Play();
                break;
            }

        }
    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    /// <param name="damage">ダメージ量</param>
    public override void AddDamage(int damage)
    {
        if (!isDead)
        {
            // 死んでいなければダメージを受ける
            base.AddDamage(damage);

            // キル数カウント
            if (isDead) GameManager.AddHumanKillCount();
        }
    }
}
