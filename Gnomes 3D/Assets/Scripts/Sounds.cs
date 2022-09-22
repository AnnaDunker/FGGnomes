using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ShootingFX;
    [SerializeField] private AudioClip JumpingFX;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            audioSource.PlayOneShot(ShootingFX);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(JumpingFX);
        }
    }

}
