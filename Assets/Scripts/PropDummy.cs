using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropDummy : MonoBehaviour, IEnemy
{
    public float maxHealth, power, toughness;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }    

    public void TakeDamage(int amount)
    {
        //TODO: REPLACE WITH A HIT ANIMATION AND DAMAGE ABOVE HEAD 
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
