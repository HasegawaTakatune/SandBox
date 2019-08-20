using UnityEngine;

public class Timelimit : MonoBehaviour
{
    /// <summary>
    /// 1秒後に自動で削除される
    /// </summary>
    void Start()
    {
        Destroy(this.gameObject, 1);
    }
}
