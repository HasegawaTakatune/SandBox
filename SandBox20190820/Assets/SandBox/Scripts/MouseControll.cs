using UnityEngine;

public class MouseControll : MonoBehaviour
{
    /// <summary>
    /// マウスの左クリックした座標を可視化するためのターゲット
    /// </summary>
    [SerializeField] private GameObject showTarget = null;

    /// <summary>
    /// 経過タイム格納
    /// </summary>
    private float timer = 0;

    /// <summary>
    /// マウスドラッグの判定時間
    /// </summary>
    private const float dragTime = 0.08f;

    /// <summary>
    /// 人間をターゲットにした場合の格納場所
    /// </summary>
    private Transform humanTarget = null;

    void Start()
    {

    }

    void Update()
    {

        // マウスドラッグイベント
        if (Input.GetMouseButton(0))
        {
            // 時間を加算する
            timer += Time.deltaTime;

            // ボタンを長押ししていたら、画面スライド処理を呼ぶ
            if (timer >= dragTime)
            {
                MoveScreen();
            }
        }
        // マウスボタンを離した際の処理
        if (timer != 0 && Input.GetMouseButtonUp(0))
        {
            // ドラッグと判定される前にボタンを離していたら
            // ターゲット設定処理を呼ぶ
            if (timer <= dragTime)
            {
                SetScreenTarget();
            }
            timer = 0;
        }

        // 人間をターゲットした際の処理
        if (humanTarget != null)
            SetHumanTarget();
    }

    /// <summary>
    /// ターゲット設定
    /// </summary>
    void SetScreenTarget()
    {
        // クリック座標を取得して、ターゲットを設定する（NavMeshAgentの目的位置）
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);       
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            // 人をターゲット選択した場合
            if (hit.collider.gameObject.tag == "Human")
            {
                hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
                humanTarget = hit.collider.transform;
            }
            else
            {
                // ターゲット位置にオブジェクトを配置する（可視化している）
                if (showTarget != null)
                    Instantiate(showTarget, hit.point, Quaternion.identity);
                // ターゲット設定
                GrobalStatus.SetTarget(hit.point);
            }            
        }
    }

    /// <summary>
    /// 人間をターゲットした際の処理
    /// </summary>
    void SetHumanTarget()
    {
        GrobalStatus.SetTarget(humanTarget.position);
    }

    /// <summary>
    /// カメラ移動
    /// </summary>
    void MoveScreen()
    {
        // スクリーン座標取得
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 25);

        // スクリーン座標の移動分カメラ移動させる        
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(worldPos.x, 25, worldPos.z), Time.deltaTime);
    }
}
