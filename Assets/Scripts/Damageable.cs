using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]

public class Damageable : MonoBehaviour

{

    public UnityEvent OnDamaged;
    public UnityEvent OnShielded;

    public bool CanBeShielded;
    public bool Shielded = false;
    public bool Invincible = false;

    Health health;
    private void Awake()
    {
        health = GetComponent<Health>();
    }
    public void DealDamage(int damageAmount)
    {
        if (CanBeShielded && Shielded)
        {

            OnShielded.Invoke();

        } else if (!Invincible)
        {
            health.ChangeHealth(damageAmount);
            OnDamaged.Invoke();
        }
    }

}
