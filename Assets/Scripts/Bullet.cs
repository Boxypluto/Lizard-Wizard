using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int[] CrashLayerIndex;
    [SerializeField]
    private int[] SpecialCrashLayer;

    public UnityEvent Crash;
    public UnityEvent SpecialCrash;

    private GameObject Player;
    private Damageable PlayerDamageable;

    private Rigidbody2D Rigidbody;

    public float speed;

    private void Start()
    {
        Player = GameObject.Find("Player");
        PlayerDamageable = Player.GetComponent<Damageable>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CrashLayerIndex.Contains(collision.gameObject.layer))
        {
            Crash.Invoke();
            if (SpecialCrashLayer.Contains(collision.gameObject.layer)) { SpecialCrash.Invoke(); }
            Object.Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        var LocalVelocity = transform.InverseTransformDirection(Rigidbody.velocity);
        LocalVelocity.y = -speed;
        Rigidbody.velocity = transform.TransformDirection(LocalVelocity);
    }

    public void DamagePlayer(int amount)
    {
        PlayerDamageable.DealDamage(-amount);
    }


}
