using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 12, -13);

    private void Start()
    {
        
    }

   

    private void Update()
    {
        if (player != null)
        {
            StartCoroutine(waiter());

            IEnumerator waiter()
            {
                yield return new WaitForSeconds(4);
                transform.position = player.transform.position + offset;
            }
        }
    }

    private void LateUpdate()
    {
        
    }

}
