using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDamager : MonoBehaviour
{

    public int damageToDeal;
    public int LayerToDamage;
    public UnityEvent OnSuccesfulDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collision!");
        GameObject hitObject = collision.gameObject;

        print(hitObject.layer);
        print(LayerToDamage);

        if (hitObject.layer == LayerToDamage)
        {
            TryDamageObject(hitObject);
        }
    }
    void TryDamageObject(GameObject objectToDamage)
    {
        if (objectToDamage.TryGetComponent(out Damageable damageableObject))
        {
            OnSuccesfulDamage.Invoke();
            damageableObject.DealDamage(-damageToDeal);
            print(damageableObject.ToString() + " damaged for " + damageToDeal + " HP!");
        } else
        {
            print(objectToDamage.ToString() + " cannot be damaged!");
        }
    }
}
