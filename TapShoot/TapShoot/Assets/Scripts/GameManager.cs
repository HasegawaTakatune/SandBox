using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// タイトルオブジェクト
    /// </summary>
    [SerializeField] private GameObject TitleObject;

    /// <summary>
    /// スコアテキスト
    /// </summary>
    [SerializeField] private Text ScoreText;

    /// <summary>
    /// ゲームステータス（列挙）
    /// </summary>
    public enum GAMESTATUS
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
    private static GAMESTATUS gameStatus;

    /// <summary>
    /// スコア
    /// </summary>
    private static float score;

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        gameStatus = GAMESTATUS.TITLE;
    }

    /// <summary>
    /// メインループ
    /// </summary>
    private void Update()
    {
        //ステータス別に処理を分岐する
        switch (gameStatus)
        {
            case GAMESTATUS.TITLE:
                Title();
                break;

            case GAMESTATUS.PLAY:
                Play();
                break;

            case GAMESTATUS.GAMEOVER:
                GameOver();
                break;
        }
    }

    /// <summary>
    /// タイトル画面
    /// </summary>
    private void Title()
    {
        // タイトル画面が表示されていなければ、タイトル表示する
        if (!TitleObject.activeSelf)
        {
            TitleObject.SetActive(true);
        }
        else
        {
            // タップ（クリック）してゲームスタート
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
#elif UNITY_ANDROID
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                GameStart();
            }
#endif
        }

    }

    /// <summary>
    /// ゲーム開始処理
    /// </summary>
    private void GameStart()
    {
        TitleObject.SetActive(false);
        gameStatus = GAMESTATUS.PLAY;
        score = 0;
    }

    private void Play()
    {

    }

    public static void AddScore(int addScore)
    {
        score = addScore;
    }

    private void GameOver()
    {

    }

    public static void ChangeGameState(GAMESTATUS status)
    {
        gameStatus = status;
    }

}
