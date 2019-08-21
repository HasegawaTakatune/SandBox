using UnityEngine;

public sealed class GrobalStatus
{
    /// <summary>
    /// ターゲット座標
    /// </summary>
    public static Vector3 target;

    /// <summary>
    /// 避難場所
    /// </summary>
    public static Transform evacuationPlace;

    /// <summary>
    /// インスタンス
    /// </summary>
    private static GrobalStatus grobalStatus;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private GrobalStatus()
    {
        if (grobalStatus == null)
            grobalStatus = new GrobalStatus();

        evacuationPlace = GameObject.Find("EvacuationPlace").transform;

    }

    /// <summary>
    /// インスタンス取得
    /// </summary>
    /// <returns>グローバルステータスクラス</returns>
    public static GrobalStatus GetInstance()
    {
        return grobalStatus;
    }

    /// <summary>
    /// ターゲット設定処理
    /// </summary>
    /// <param name="inpTarget"></param>
    public static void SetTarget(Vector3 inpTarget)
    {
        // ターゲットを設定
        target = inpTarget;
        // ターゲットが設定されたことを通知する
        NotifyTargetEvent(inpTarget);

    }

    /// <summary>
    /// イベント宣言（デリゲート）
    /// </summary>
    public delegate void OnTargetEvent(Vector3 target);
    /// <summary>
    /// イベント通知用インスタンス
    /// </summary>
    static event OnTargetEvent _OnTargetEvent;

    /// <summary>
    /// 通知先追加
    /// </summary>
    /// <param name="onSomeEvent">通知するイベント</param>
    public static void SubscriveTargetEvent(OnTargetEvent onSomeEvent)
    {
        _OnTargetEvent += onSomeEvent;
    }

    /// <summary>
    /// 通知先解除
    /// </summary>
    /// <param name="onSomeEvent">解除するイベント</param>
    public static void UnSubscribeTargetEvent(OnTargetEvent onSomeEvent)
    {
        _OnTargetEvent -= onSomeEvent;
    }

    /// <summary>
    /// 通知を行う
    /// </summary>
    /// <param name="target"></param>
    public static void NotifyTargetEvent(Vector3 target)
    {
        if (_OnTargetEvent != null)
        {
            _OnTargetEvent(target);
        }
    }
}
