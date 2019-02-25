using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    // 最高速度
    private const float MaxSpeed = 120.0f;
    // 基準速度
    private const float ReferenceSpeed = 20.0f;
    // 最高回転角度
    private const float BoostRotationAngle = 360;
    // 回転角度
    private const float RotationAngle = 20;

    // 速度
    private float MoveSpeed = 20.0f;
    // ブースト判定
    private bool Boost = false;

    private float BoostDirection = 0;
    // 回転速度
    private float RotationalSpeed = 0;

    float xMove = 0;
    float yMove = 0;

    void Start()
    {
        RotationalSpeed = 120 * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        // 方向キー入力の取得（WASD入力も含む）
        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");

        // 移動
        transform.position += new Vector3(xMove, yMove, 0) * MoveSpeed * Time.deltaTime;

        // 回転
        if (!Boost)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, (xMove < 0) ? RotationAngle : (xMove > 0) ? -RotationAngle : 0), RotationalSpeed);
        else
            transform.Rotate(new Vector3(0, 0, BoostDirection) * Time.deltaTime);

    }

    void Update()
    {
        // ブースト移動
        if (!Boost && Input.GetKeyDown(KeyCode.Space))
        {
            Boost = true;

            BoostDirection = (xMove < 0) ? BoostRotationAngle : (xMove > 0) ? -BoostRotationAngle : 0;

            MoveSpeed = MaxSpeed;

            StartCoroutine("Boost_SpeedDown");
        }
    }

    /// <summary>
    /// ブーストの減速
    /// </summary>
    /// <returns></returns>
    private IEnumerator Boost_SpeedDown()
    {
        while (true)
        {
            // 遅延
            yield return new WaitForSeconds(Time.deltaTime);

            // 通常速度まで減速する
            MoveSpeed -= (MaxSpeed + MaxSpeed) * Time.deltaTime;
            if (MoveSpeed <= ReferenceSpeed)
            {
                MoveSpeed = ReferenceSpeed;
                Boost = false;
                break;
            }
        }
    }
}
