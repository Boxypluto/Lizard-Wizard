using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Homing : MonoBehaviour
{

    ObjectReferencer referencer;

    private Rigidbody2D rb;
    public string targetName;
    private GameObject Target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxSpeed;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Target = GameObject.Find(targetName);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            rb.AddForce((Target.transform.position - transform.position) * speed);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }

    }

    public void AddForceAtAngle(float force, float angle)
    {
        float xcomponent = Mathf.Cos(angle * Mathf.PI / 180) * force;
        float ycomponent = Mathf.Sin(angle * Mathf.PI / 180) * force;

        rb.AddForce(new Vector2(ycomponent, xcomponent), ForceMode2D.Impulse);
    }

    public void MoveLock()
    {

        canMove = false;
        Invoke(nameof(MoveAgain), 1);

    }

    private void MoveAgain()
    {
        canMove = true;
    }

}
