using UnityEngine;

public class SafeZone : MonoBehaviour
{
    /// <summary>
    /// 初期設定
    /// </summary>
    void Start()
    {
        GrobalStatus.SetEvacutionPlace(this.transform);
    }
}
