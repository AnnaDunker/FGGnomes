using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    public GameObject camCam1;
    public GameObject camCam2;
    //public GameObject camCam3;

    private void Update()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerController.playerIndex))

            if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            camCam1.SetActive(false);
            camCam2.SetActive(true);
            //camCam3.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            camCam1.SetActive(true);
            camCam2.SetActive(false);
            //camCam3.SetActive(false);
        }
    }
}
