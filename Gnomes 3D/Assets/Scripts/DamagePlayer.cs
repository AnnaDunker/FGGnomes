using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage = 2;
    public float invincibilityTime = 0.5f;
    private bool _isColliding;

    private void OnTriggerEnter(Collider other)
    {
        if (_isColliding) return;

        StartCoroutine(InvincibilityFrames());
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }

        Player2 player2 = other.GetComponent<Player2>();
        if (player2 != null)
        {
            player2.TakeDamage(damage);
        }

    }

    IEnumerator InvincibilityFrames()
    {
        _isColliding = true;

        yield return new WaitForSeconds(invincibilityTime);

        _isColliding = false;
    }
}
