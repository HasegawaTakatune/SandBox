using System.Collections;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    /// <summary>
    /// 一度だけ実行
    /// </summary>
    private bool doOnce = false;

    /// <summary>
    /// オブジェクト衝突イベント
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (!doOnce)
        {
            doOnce = true;
            StartCoroutine("CountDown", 1.0f);
        }
    }

    /// <summary>
    /// delay秒遅延させてオブジェクトを非アクティブ化
    /// </summary>
    /// <param name="delay">遅延時間</param>
    /// <returns>待機時間を戻す</returns>
    private IEnumerator CountDown(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// オブジェクトのアクティブ設定
    /// </summary>
    /// <param name="active">アクティブ化/非アクティブ化</param>
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
        doOnce = !active;
    }

    /// <summary>
    /// オブジェクトのアクティブ状態を取得
    /// </summary>
    /// <returns></returns>
    public bool GetActive() { return gameObject.activeInHierarchy; }

}
