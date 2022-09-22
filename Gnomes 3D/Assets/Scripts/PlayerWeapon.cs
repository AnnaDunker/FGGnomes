using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform ShootingStartPosition;
    

    private void Update()
    {
    
    if (Input.GetKeyDown(KeyCode.F))
    {
       GameObject newProjectile = Instantiate(projectilePrefab, ShootingStartPosition.position, transform.rotation);
       newProjectile.GetComponent<Projectile>().Initialize();
    }
            
    }
}
