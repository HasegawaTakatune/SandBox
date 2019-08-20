using System.Collections;
using UnityEngine.EventSystems;

public interface IRecieveTargetMessage : IEventSystemHandler
{
    /// <summary>
    /// ターゲット設定時のメッセージ呼び出し
    /// </summary>
    void OnSetTarget();
}
