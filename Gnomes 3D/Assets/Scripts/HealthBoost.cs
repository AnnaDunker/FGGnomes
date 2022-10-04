using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    public int amount = 4;

    private void OnTriggerEnter(Collider other)
    {
        Player health = other.GetComponent<Player>();
        if (health)
        {
            health.Heal(amount);
            Destroy(gameObject);
        }
      
    }


}
