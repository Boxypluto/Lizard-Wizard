using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamager : MonoBehaviour
{

    public int damageToDeal;
    public LayerMask LayerToDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collision!");
        GameObject hitObject = collision.gameObject;
        if (hitObject.layer == LayerToDamage)
        {
            TryDamageObject(hitObject);
        }
    }
    void TryDamageObject(GameObject objectToDamage)
    {
        if (objectToDamage.TryGetComponent(out Damageable damageableObject))
        {
            damageableObject.DealDamage(-damageToDeal);
            print(damageableObject.ToString() + " damaged for " + damageToDeal + " HP!");
        } else
        {
            print(objectToDamage.ToString() + " cannot be damaged!");
        }
    }
}
