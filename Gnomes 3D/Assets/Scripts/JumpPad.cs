using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{ 
    
    public int speed;
    public float bounce;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bounce, ForceMode.Impulse);
                
        }
    }
    

}
