using System.Collections;
using UnityEngine;

public class TargetMarker : MonoBehaviour
{
    /// <summary>
    /// ターゲット座標
    /// </summary>
    public Transform target = null;

    /// <summary>
    /// 1秒後に自動で削除される
    /// </summary>
    private void Start()
    {
        Destroy(gameObject, 1);
        if (target != null)
            StartCoroutine("OnTarget");
    }

    /// <summary>
    /// ターゲットをマークする
    /// </summary>
    private IEnumerator OnTarget()
    {
        float height = target.localScale.y;

        while (true)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            transform.position = target.position;// + (Vector3.up * height);
        }
    }

}
