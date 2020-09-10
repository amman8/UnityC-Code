using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int maxHealth = 300;
    public static int currentHealth;
    public HealthBar healthbar;//Creating a refrence
    public PlayerManager manage;
    public GameObject DieUI;

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }*/

        if (other.gameObject.CompareTag("Medic"))
        {
            Heal(10);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    void Heal (int heal)
    {
        currentHealth += heal;
        healthbar.SetHealth(currentHealth);
        if (currentHealth > 300) currentHealth = maxHealth;
    }

    void TakeDamage( int damage)
    {
        currentHealth -= damage; 
        healthbar.SetHealth(currentHealth);
        if (currentHealth < 0)
        {
            currentHealth = 0;
            DieUI.SetActive(true);
            manage.PlayerDie();
        }
    }
}