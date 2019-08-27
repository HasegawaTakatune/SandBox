using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    /// <summary>
    /// 人間キルスコア表示
    /// </summary>
    [SerializeField] private Text KillsHuman;
    /// <summary>
    /// 兵士キルスコア表示
    /// </summary>
    [SerializeField] private Text KillsSoldier;

    /// <summary>
    /// スコアの表示
    /// </summary>
    /// <param name="humanScore">人間キルカウント</param>
    /// <param name="soldierScore">兵士キルカウント</param>
    public void SetScore(float humanScore, float soldierScore)
    {
        KillsHuman.text = "Human:" + humanScore;
        KillsSoldier.text = "Soldier:" + soldierScore;
    }

    /// <summary>
    /// オブジェクトのアクティブ設定
    /// </summary>
    /// <param name="active">アクティブ化/非アクティブ化</param>
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    /// <summary>
    /// オブジェクトのアクティブ状態を取得
    /// </summary>
    /// <returns>オブジェクトのアクティブ状態</returns>
    public bool GetActive() { return gameObject.activeInHierarchy; }
}
