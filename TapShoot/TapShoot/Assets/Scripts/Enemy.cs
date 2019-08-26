using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float life;

    [SerializeField] private float power;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
            isDead();
    }

    private void isDead()
    {

    }
}
