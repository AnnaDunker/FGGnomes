using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage = 2;
    

    private void OnTriggerEnter(Collider other)
    {
       
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        
    }
    
}
