using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropDummyArchery1 : MonoBehaviour, IEnemy
{
    private float currentHealth;
    private float maxHealth = 10.0f;
    private float armor = 0f;

    [SerializeField] FloatingHealthBar healthBar;

    void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }    

    public void TakeDamage(float damage, float penetration)
    {
        currentHealth -= damage - armor;

        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
