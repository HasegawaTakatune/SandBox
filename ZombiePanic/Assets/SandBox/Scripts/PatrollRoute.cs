using UnityEngine;

public class PatrollRoute : MonoBehaviour
{
    /// <summary>
    /// ターゲットのTransformコンポーネント格納
    /// </summary>
    [SerializeField] private Transform[] target;

    /// <summary>
    /// 次のターゲット位置を取得する
    /// </summary>
    /// <param name="nowIndex">今のインデックス</param>
    /// <returns>ターゲット情報</returns>
    public Vector3 Next(int nowIndex)
    {
        // インデックスが配列の長さより大きければ
        // 最初に戻り、それ以外は次のターゲットに向かう
        int next = nowIndex + 1;
        if (next < target.Length) return target[next].position;
        else return target[0].position;
    }

    /// <summary>
    /// ターゲット位置を取得
    /// </summary>
    /// <param name="index">インデックス</param>
    /// <returns></returns>
    public Vector3 GetTarget(int index)
    {
        if (index < target.Length) return target[index].position;
        return target[0].position;
    }

    /// <summary>
    /// 次のインデックスを取得
    /// </summary>
    /// <param name="index">インデックス</param>
    /// <returns>次のインデックス</returns>
    public int GetNextIndex(int index)
    {
        if (index + 1 < target.Length) return index + 1;
        else return 0;
    }
}
