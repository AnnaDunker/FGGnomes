using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    public void TakeDamage (int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void ChangeHealth()
    {
        currentHealth += 10;
        healthBar.SetHealth(currentHealth);
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("End Screen");
        }
    }

}
