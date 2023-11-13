using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float speed;
    private GameObject Slash;
    private Collider2D SlashCollider;
    private Animator SlashAnim;
    private Rigidbody2D PlayerRB;
    private Vector3 MoveAmount;
    public bool PlayerCanMove = true;
    [SerializeField]
    private float SlashKnockbackPlayer = 0f;
    float XInput;
    float YInput;

    // Start is called before the first frame update
    void Start()
    {
        Slash = GameObject.Find("Slash");
        SlashCollider = Slash.GetComponent<Collider2D>();
        SlashAnim = Slash.GetComponent<Animator>();
        SlashCollider.enabled = false;
        PlayerRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveAmount = new Vector3(0, 0, 0);
        

        XInput = Input.GetAxisRaw("Horizontal");
        YInput = Input.GetAxisRaw("Vertical");

        MoveAmount = transform.position;

        MoveAmount += new Vector3(XInput * Time.deltaTime * speed, YInput * Time.deltaTime * speed, 0);

        if (PlayerCanMove)
        {
            PlayerRB.MovePosition(MoveAmount);
        }

        SlashUpdate(XInput, YInput);
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            SlashAnim.SetTrigger("Slash");
        }

    }

    public void PlayerKnockback()
    {
        PlayerCanMove = false;
        AddForceAtAngle(SlashKnockbackPlayer, Slash.transform.rotation.eulerAngles.z - 90);
        Invoke("ResetKnockback", 0.2f);
    }

    public void AddForceAtAngle(float force, float angle)
    {
        float xcomponent = Mathf.Cos(angle * Mathf.PI / 180) * force;
        float ycomponent = Mathf.Sin(angle * Mathf.PI / 180) * force;

        PlayerRB.AddForce(new Vector2(ycomponent, xcomponent));
    }

    void ResetKnockback()
    {
        PlayerCanMove = true;
        PlayerRB.velocity = new Vector2(0f, 0f);
    }

    #region SLASH

    void SlashUpdate(float XInput, float YInput)
    {
        if (YInput > 0)
        {

            if (XInput > 0)
            {
                Slash.transform.rotation = Quaternion.Euler(0, 0, 45);
            } else if (XInput < 0)
            {
                Slash.transform.rotation = Quaternion.Euler(0, 0, 135);
            } else
            {
                Slash.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            

        } else if (YInput < 0)
        {

            if (XInput > 0)
            {
                Slash.transform.rotation = Quaternion.Euler(0, 0, -45);
            }
            else if (XInput < 0)
            {
                Slash.transform.rotation = Quaternion.Euler(0, 0, -135);
            }
            else
            {
                Slash.transform.rotation = Quaternion.Euler(0, 0, -90);
            }

        } else
        {
            if (XInput > 0)
            {
                Slash.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (XInput < 0)
            {
                Slash.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
        
    }

    #endregion

}
