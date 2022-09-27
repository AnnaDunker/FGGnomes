using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player One")
        {
            collision.gameObject.transform.SetParent(transform);
        }

        if (collision.gameObject.name == "Player Two")
        {
            collision.gameObject.transform.SetParent(transform);
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player One")
        {
            collision.gameObject.transform.SetParent(null);
        }

        if (collision.gameObject.name == "Player Two")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
