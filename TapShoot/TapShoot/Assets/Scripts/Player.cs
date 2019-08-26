using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask mask;

    private const float MaxLife = 1000;

    [SerializeField] private float life;

    [SerializeField] private float power;

    void Start()
    {
        life = MaxLife;
    }

    void Update()
    {

    }

    private void OnClickAttack()
    {
        if (Input.GetKeyDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit hit, 10, mask))
            {
                Shot(hit.collider.gameObject);
            }
        }
    }

    private void OnTouchAttack()
    {
        if (Input.touchCount < 0) return;

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out RaycastHit hit, 10, mask))
                {
                    Shot(hit.collider.gameObject);
                }
            }
        }

    }

    private void Shot(GameObject obj)
    {
        Enemy enemy = obj.GetComponent<Enemy>();
        enemy.AddDamage(power);

    }

    /// <summary>
    /// 2点間の角度を求める
    /// </summary>
    /// <param name="to">向く方向</param>
    /// <returns></returns>
    private float GetAim(Vector2 to)
    {
        Vector2 from = transform.position;
        float rad = Mathf.Atan2((to.y - from.y), (to.x - from.x));
        return rad * Mathf.Rad2Deg;
    }

    public void AddDamage(float damage)
    {
        life = damage;
    }

    private void isDead()
    {

    }
}
