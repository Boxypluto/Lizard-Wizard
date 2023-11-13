using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnContactActivate : MonoBehaviour
{
    public UnityEvent Collision;
    public string CollisionCheck;
    public bool DamageObject;
    public string ObjectToDamageName;
    private GameObject ObjectToDamage;
    private Damageable damageable;
    public int DamageToDeal;


    private void Start()
    {
        ObjectToDamage = GameObject.Find(ObjectToDamageName);
        damageable = ObjectToDamage.GetComponent<Damageable>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == CollisionCheck)
        {
            Collision.Invoke();
            if (DamageObject)
            {
                damageable.DealDamage(-DamageToDeal);
            }
        }
    }
}
