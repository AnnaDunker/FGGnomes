using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform ShootingStartPosition;
    [SerializeField] private PlayerController playerController;
   
    private bool didShoot;

    private void Update()
    {
        didShoot = false;

        if (TurnManager.GetInstance().IsItPlayerTurn(playerController.playerIndex))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject newProjectile = Instantiate(projectilePrefab, ShootingStartPosition.position, transform.rotation);

                newProjectile.GetComponent<Projectile>().Initialize();
                
                didShoot = true;
            }
        }

            
    }

    private void LateUpdate()
    {
        if (didShoot)
        {
            TurnManager.GetInstance().ChangeTurn();
        }
        
    }

}
