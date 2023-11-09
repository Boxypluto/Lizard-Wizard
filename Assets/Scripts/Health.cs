using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int HitPoints = 5;
    public UnityEvent onHealthZero;
    public void ChangeHealth(int amountToChange)
    {
        HitPoints += amountToChange;
        
        if (HitPoints <= 0)
        {
            onHealthZero.Invoke();
        }
    }

}
