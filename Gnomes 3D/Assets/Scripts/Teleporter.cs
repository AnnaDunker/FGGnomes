using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    private void OnTriggerEnter(Collider Teleport)
    {
        Teleport.transform.position = new Vector3(Random.Range(-120.0f, 120.0f), Teleport.transform.position.y, Random.Range( -120.0f, 100.0f));
    }

}
