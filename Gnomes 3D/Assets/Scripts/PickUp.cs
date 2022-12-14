using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player controller = other.GetComponent<Player>();

        if (controller != null)
        {
            controller.ChangeHealth();
            Destroy(gameObject);
        }
    }
}
