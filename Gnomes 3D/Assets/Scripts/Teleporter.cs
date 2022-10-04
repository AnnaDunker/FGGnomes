using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    private void OnTriggerEnter(Collider Teleport)
    {
        Teleport.transform.position = new Vector3(Random.Range(-50.0f, 50.0f), Teleport.transform.position.y, Random.Range( -50.0f, 50.0f));
    }

}
