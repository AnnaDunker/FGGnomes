using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairFunction : MonoBehaviour
{
    [SerializeField] private GameObject AimCrosshair;
    void Start()
    {
        AimCrosshair.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartCoroutine(waiter());

            IEnumerator waiter()
            {
                yield return new WaitForSeconds(1.85f);
                AimCrosshair.SetActive(true);
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            AimCrosshair.SetActive(false);
        }
    }
}
