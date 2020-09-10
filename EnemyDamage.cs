using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float enemymaxhelth = 100f;
    public float enemycurrenthelth;
    public Animator Enemy;
    public static bool Enemycheck = false;
    public Transform changeony;

    private void Start()
    {
        enemycurrenthelth = enemymaxhelth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Shoot(50);
        }
    }

    void Shoot(float bullethit)
    {
        enemycurrenthelth -= bullethit;
        if (enemycurrenthelth < 0) 
        {
            enemycurrenthelth = 0;
            Enemy.SetTrigger("die");
            Enemycheck = true;
        }
    }
}
