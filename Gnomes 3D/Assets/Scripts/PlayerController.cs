using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] public Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] private Rigidbody CharacterBody;
    [SerializeField] public int playerIndex;

    [SerializeField] private CinemachineVirtualCamera vcam;


    private float speed = 10f;
    private float turnSpeed = 110f;




    // Update is called once per frame
    void Update()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex))
        {

            if (Input.GetAxis("Horizontal") != 0)
            {
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed * Input.GetAxis("Vertical"));
            }

            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded())
            {
                speed = 17;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 10;
            }


            vcam.Priority = 1;
        }

        else
        {
            vcam.Priority = 0;
        }

    }

    private void Jump()
    {
        CharacterBody.velocity = Vector3.up * 8f;
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }

}
