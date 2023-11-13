using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{

    public string targetName;
    private GameObject Target;
    public float FireTime;
    [SerializeField]
    private GameObject Bullet;

    void Start()
    {
        Target = GameObject.Find(targetName);
        InvokeRepeating(nameof(ShootAtTarget), FireTime, FireTime);
    }

    void ShootAtTarget()
    {
        GameObject inst = Instantiate(Bullet);
        inst.transform.position = transform.position;
        Vector2 direction = Target.transform.position - transform.position;
        var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        inst.transform.rotation = Quaternion.AngleAxis(-angle + 180, Vector3.forward);
    }


}
