using UnityEngine;

public class Building : MonoBehaviour
{
    // 座標系
    Transform trans = null;
    // 速度
    const float speed = -5;

    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        trans.position += Vector3.forward * speed;
    }
}
