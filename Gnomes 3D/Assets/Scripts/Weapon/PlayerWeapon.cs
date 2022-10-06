using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform ShootingStartPosition;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject playerWeapon;

    public Timer Timer;
    [HideInInspector] public int shotCount = 0;

    private void Start()
    {
        projectilePrefab.gameObject.SetActive(true);
    }

    /* public void AmmoRefill()
    {
        didShoot = false;
    } */

    private void Update()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerController.playerIndex))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (true)
                {
                    GameObject newProjectile = Instantiate(projectilePrefab, ShootingStartPosition.position, transform.rotation);

                    newProjectile.GetComponent<Projectile>().Initialize();
                }
            }
        }

        /* if (TurnManager.GetInstance().IsItPlayerTurn(playerController.playerIndex))
         {
             StartCoroutine(waiter());

             IEnumerator waiter()
             {
                 yield return new WaitForSeconds(7);
                 didShoot = false;
             }
         } */
    }
    /*
    IEnumerator wait()
    {
        Debug.Log("Bajs");
        yield return new WaitForSeconds(12);
        projectilePrefab.gameObject.SetActive(true);
        shotCount = 0;

    }
    */
    private void LateUpdate()
    {

    }

}