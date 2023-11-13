using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class KnockbackReactor : MonoBehaviour
{

    private Rigidbody2D rb;
    public string angleFromName;
    GameObject AngleFrom;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AngleFrom = GameObject.Find(angleFromName);
    }

    public void Knockback(float knockbackForce)
    {
        AddForceAtAngle(knockbackForce, AngleFrom.transform.rotation.eulerAngles.z + 90);
    }

    public void AddForceAtAngle(float force, float angle)
    {
        float xcomponent = Mathf.Cos(angle * Mathf.PI / 180) * force;
        float ycomponent = Mathf.Sin(angle * Mathf.PI / 180) * force;

        rb.velocity = new Vector2(ycomponent, xcomponent);
    }

}
