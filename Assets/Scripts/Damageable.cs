using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class Damageable : MonoBehaviour

{


    Health health;
    private void Awake()
    {
        health = GetComponent<Health>();
    }
    public void DealDamage(int damageAmount)
    {
        health.ChangeHealth(damageAmount);
    }
}
