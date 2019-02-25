using UnityEngine.Events;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    public const int Title = 0;
    public const int Play = 1;
    public const int GameOver = 2;

    // コールバックイベントを変数として使うために空のクラスを用意する
    [System.Serializable]
    public class Callback : UnityEvent<int> { }
    // コールバックイベントの変数生成
    public static Callback StateChangeAction = new Callback();

    /**
     *ゲームステート
     * セッタが呼ばれたタイミング（ステート変更が起きたタイミング）で
     *  コールバックイベントを呼ぶ
     **/
    private static int state = Play;
    public static int State
    {
        get { return state; }
        set
        {
            state = value;
            if (StateChangeAction != null)
                StateChangeAction.Invoke(state);
        }
    }
}
