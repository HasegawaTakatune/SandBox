using UnityEngine;

public class PatrollingManager : MonoBehaviour
{
    /// <summary>
    /// 巡回ルートを格納
    /// </summary>
    [SerializeField] private PatrollRoute[] patrollPlan;

    /// <summary>
    /// 巡回ルート中の次の進行ルートを取得する
    /// </summary>
    /// <param name="nowPlan">巡回ルート</param>
    /// <param name="nowIndex">巡回ルートの進行度</param>
    /// <returns>次の目的地</returns>
    public Vector3 GetNextTarget(int nowPlan, int nowIndex)
    {
        // 次の目的地を取得
        if (nowPlan < patrollPlan.Length)
            return patrollPlan[nowPlan].Next(nowIndex);
        else
            return Vector3.zero;
    }

    /// <summary>
    /// 巡回ルートの取得
    /// </summary>
    /// <param name="nowPlan">巡回ルート</param>
    /// <param name="index">巡回ルートの進行度</param>
    /// <returns>indexで指定した目的地</returns>
    public Vector3 GetTarget(int nowPlan, int index)
    {
        if (nowPlan < patrollPlan.Length)
            return patrollPlan[nowPlan].GetTarget(index);
        return Vector3.zero;
    }

    /// <summary>
    /// 次のインデックスを取得
    /// </summary>
    /// <param name="nowPlan">巡回ルート</param>
    /// <param name="index">巡回ルートの進行度</param>
    /// <returns>次のインデックス</returns>
    public int GetNextIndex(int nowPlan, int index)
    {
        if (nowPlan < patrollPlan.Length)
            return patrollPlan[nowPlan].GetNextIndex(index);
        else return 0;
    }
}
