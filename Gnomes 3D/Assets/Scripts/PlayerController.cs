using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] private Rigidbody CharacterBody;
    [SerializeField] public int playerIndex;

    
    private float speed = 10f;
    private float turnSpeed = 140f;
    
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TurnManagerTest.GetInstance().IsItPlayerTurn(playerIndex))
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

        }

    }

    private void Jump ()
    {
        CharacterBody.velocity = Vector3.up * 5.5f;
    }
 
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }

}
