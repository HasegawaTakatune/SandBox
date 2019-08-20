﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentBall : MonoBehaviour
{
    /// <summary>
    /// 追尾のコンポーネント
    /// </summary>
    [SerializeField]NavMeshAgent agent;

    /// <summary>
    /// 初期設定
    /// </summary>
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // ターゲットが設定された際に通知するように設定
        GrobalStatus.SubscriveTargetEvent((GrobalStatus.OnTargetEvent)OnSetTarget);
    }

    /// <summary>
    /// メインループ
    /// </summary>
    void Update()
    {

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
}
