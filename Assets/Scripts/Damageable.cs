using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]

public class Damageable : MonoBehaviour

{

    public UnityEvent OnDamaged;

    Health health;
    private void Awake()
    {
        health = GetComponent<Health>();
    }
    public void DealDamage(int damageAmount)
    {
        health.ChangeHealth(damageAmount);
        OnDamaged.Invoke();
    }
}
