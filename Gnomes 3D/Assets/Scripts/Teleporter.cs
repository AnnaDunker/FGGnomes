using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private bool hasTeleported = false;

    private void Update()
    {
        while(hasTeleported == true)
        {
            Update();
        }
    }
    private void OnTriggerEnter(Collider Teleport)
    {
        Teleport.transform.position = new Vector3(Random.Range(-70f, 70f), Teleport.transform.position.y, Random.Range( -70f, 50f));
        hasTeleported = true;
    }

}
