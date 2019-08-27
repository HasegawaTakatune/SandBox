using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// ゲームステータス
    /// </summary>
    public enum GAMESTATE
    {
        /// <summary>
        /// タイトル
        /// </summary>
        TITLE,
        /// <summary>
        /// プレイ
        /// </summary>
        PLAY,
        /// <summary>
        /// ゲームオーバー
        /// </summary>
        GAMEOVER
    }

    /// <summary>
    /// ゲームステータス
    /// </summary>
    public GAMESTATE gameState;

    /// <summary>
    /// ゲームスタートパネル
    /// </summary>
    [SerializeField] private StartPanel startPanel;

    /// <summary>
    /// ゲームオーバーパネル
    /// </summary>
    [SerializeField] private GameOverPanel gameOverPanel;

    /// <summary>
    /// 人間キルカウント
    /// </summary>
    private static float humanKillCount;

    /// <summary>
    /// 兵士キルカウント
    /// </summary>
    private static float soldierKillCount;

    /// <summary>
    /// 人間キルカウント加算
    /// </summary>
    public static void AddHumanKillCount() { humanKillCount++; }

    /// <summary>
    /// 兵士キルカウント加算
    /// </summary>
    public static void AddSoldierKillCount() { soldierKillCount++; }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        gameState = GAMESTATE.TITLE;
        humanKillCount = 0;
        soldierKillCount = 0;
    }

    /// <summary>
    /// メインループ
    /// </summary>
    private void Update()
    {
        // ゲームステータスごとに処理を分岐
        switch (gameState)
        {
            case GAMESTATE.TITLE:
                Title();
                break;

            case GAMESTATE.PLAY:
                Play();
                break;

            case GAMESTATE.GAMEOVER:
                GameOver();
                break;
        }

    }

    /// <summary>
    /// タイトル処理
    /// </summary>
    private void Title()
    {
        if (!startPanel.GetActive())
            gameState = GAMESTATE.PLAY;
    }

    /// <summary>
    /// ゲームプレイ処理
    /// </summary>
    private void Play()
    {

    }

    /// <summary>
    /// ゲームオーバー処理
    /// </summary>
    private void GameOver()
    {
        if (!gameOverPanel.GetActive())
        {
            // ゲームオーバーパネルのアクティブ化・スコアの設定
            gameOverPanel.SetActive(true);
            gameOverPanel.SetScore(humanKillCount, soldierKillCount);

            // スコアの初期化
            humanKillCount = 0;
            soldierKillCount = 0;

            // 2秒後にゲームステータスをタイトルに戻す
            StartCoroutine(Delay(2.0f, () =>
            {
                gameState = GAMESTATE.TITLE;
                startPanel.SetActive(true);
                gameOverPanel.SetActive(false);
            }));
        }
    }

    /// <summary>
    /// 遅延処理
    /// Actionに処理（デリゲート）を入れ込み一定時間後にその処理を行う
    /// </summary>
    /// <param name="waitTimr">遅延時間</param>
    /// <param name="action">実行処理（デリゲート）</param>
    private IEnumerator Delay(float waitTimr, Action action)
    {
        yield return new WaitForSeconds(waitTimr);
        action();
    }
}
