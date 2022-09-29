using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 12, -13);
    private float timeLeft = 5f;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            ChangeCamera();
        }

        void ChangeCamera()
        {
            transform.position = player.transform.position + offset;
        }
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.transform.position + offset;
        }
    }

}
