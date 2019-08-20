using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControll : MonoBehaviour
{
    /// <summary>
    /// マウスの左クリックした座標を可視化するためのターゲット
    /// </summary>
    [SerializeField] private GameObject target;

    /// <summary>
    /// マウス左長押し時間
    /// </summary>
    private float mouseButtonDownTimer = 0;

    /// <summary>
    /// マウスのドラッグ判定時間
    /// </summary>
    private float isMouseDragTime = 1.0f;

    /// <summary>
    /// 現在のスクリーン座標
    /// </summary>
    private Vector3 nowScreenPos;

    /// <summary>
    /// マウス左ボタンが押下状態か判定する
    /// </summary>
    private bool mouseLeftButtonDown = false;

    private float timer = 0;
    private float timeLimit = 0.05f;

    void Start()
    {

    }

    void Update()
    {

        // マウスドラッグイベント
        if (Input.GetMouseButton(0))
        {
            Debug.Log("DeltaTime : " + Time.deltaTime);
            mouseLeftButtonDown = true;
            // カメラスクロール処理を遅延ありで呼び出し
            Invoke("MoveScreen", timeLimit);

            // マウスクリックの場合、ターゲット設定処理を実行する
            while (timer <= timeLimit)
            {
                Debug.Log("Call");
                timer += Time.deltaTime;
                if (Input.GetMouseButtonUp(0)) mouseLeftButtonDown = false;
                if (!mouseLeftButtonDown)
                {
                    SetScreenTarget();
                    break;
                }
            }

            timer = 0;
        }


    }

    /// <summary>
    /// ターゲット設定
    /// </summary>
    void SetScreenTarget()
    {
        // クリック座標を取得して、ターゲットを設定する（NavMeshAgentの目的位置）
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // ターゲット位置にオブジェクトを配置する（可視化している）
            Instantiate(target, hit.point, Quaternion.identity);
            // ターゲット設定
            GrobalStatus.SetTarget(hit.point);
        }
    }

    /// <summary>
    /// カメラ移動
    /// </summary>
    void MoveScreen()
    {
        // マウス左ボタンが離されたら処理をしない
        if (!mouseLeftButtonDown) return;

        // スクリーン座標取得
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 25);

        // スクリーン座標の移動分カメラ移動させる
        if (screenPos != nowScreenPos)
        {
            nowScreenPos = screenPos;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(nowScreenPos);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(worldPos.x, 25, worldPos.z), Time.deltaTime);
        }
    }
}
