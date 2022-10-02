using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform ShootingStartPosition;
    [SerializeField] private PlayerController playerController;
    
    private int shotCount = 0;  
    private bool didShoot;

    private void Start()
    {
        didShoot = false;
    }

    private void Update()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerController.playerIndex))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (didShoot == false)
                {
                    shotCount++;
                    GameObject newProjectile = Instantiate(projectilePrefab, ShootingStartPosition.position, transform.rotation);

                    newProjectile.GetComponent<Projectile>().Initialize();
                }
            }
        }

        if (shotCount == 3)
        {
            didShoot = true;
        }

            
    }

   private void LateUpdate()
    {
        if (didShoot)
        {
            StartCoroutine(waiter());

            IEnumerator waiter()
            {
                yield return new WaitForSeconds(15);
                didShoot=false;
            }
        }
    }

}
