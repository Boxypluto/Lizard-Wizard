using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        print("ENTER: " + collision.name);
        if (collision.tag == "Enemy" && damageable != null)
        {
            damageable.Shielded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        print("EXIT: " + collision.name);
        if (collision.tag == "Enemy" && damageable != null)
        {
            damageable.Shielded = false;
        }
    }
}
