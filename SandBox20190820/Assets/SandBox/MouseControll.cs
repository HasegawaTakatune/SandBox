using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControll : MonoBehaviour
{
    /// <summary>
    /// マウスの左クリックした座標を可視化するためのターゲット
    /// </summary>
    [SerializeField] private GameObject target;

    void Start()
    {

    }

    void Update()
    {
        // マウスの左クリックイベント
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.gameObject.name);
                Instantiate(target, hit.point, Quaternion.identity);
            }
        }
    }
}
