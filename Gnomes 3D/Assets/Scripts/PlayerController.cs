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
    private Vector2 _input = Vector2.zero;
    private bool Movebool;

    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex))
        {
            

            if (Input.GetAxis("Horizontal") != 0)
            {
                _input.x = Input.GetAxis("Horizontal");
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                _input.y = Input.GetAxis("Vertical");
                transform.Translate(Vector3.forward * Time.deltaTime * speed * Input.GetAxis("Vertical"));
                animator.SetBool("Movebool", true);
            }
            else
            {
                animator.SetBool("Movebool", false);
                Debug.Log("egg");
            }

            if(_input.x != 0 || _input.y != 0)
            {
                //Change bool
                
            }

            if (CharacterBody.velocity == new Vector3(0, 0, 0))
            {
                
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
        CharacterBody.velocity = Vector3.up * 6f;
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }

}
