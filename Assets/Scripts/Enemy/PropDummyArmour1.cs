using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropDummyArmour1 : MonoBehaviour, IEnemy
{
    private float currentHealth;
    private float maxHealth = 10.0f;
    private float armor = 2f;

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
        if(damage - armor > 0)
        {
            currentHealth -= damage - armor;
        }
        Debug.Log(damage + " " + armor);
        Debug.Log(damage - armor);
        Debug.Log(currentHealth);


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
