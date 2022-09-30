using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int maxHealth = 4;
    public int currentHealth;

    //public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;

        //healthBar.SetHealth(currentHealth);
    }
    
}
