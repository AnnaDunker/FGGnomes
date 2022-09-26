using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float Speed = 30f;
    [SerializeField] private Rigidbody projectileBody;

    private bool isActive;

    public void Initialize()
    {
        isActive = true;
        projectileBody.AddForce(transform.forward * 50f + transform.up * 200f);
    }

    void Update()
    {
        if (isActive)
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;
        DestructionFree destruction = collisionObject.GetComponent<DestructionFree>();

        

        if (destruction == null)
        {
            Destroy(collisionObject);
        } 
        
        Destroy(this.gameObject);
    }

}
