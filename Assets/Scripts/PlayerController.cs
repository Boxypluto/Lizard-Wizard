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
    private bool IsSlashing = false;
    private bool CanSlash = true;
    private Animator SlashAnim;
    private Rigidbody2D PlayerRB;
    private Vector3 MoveAmount;
    public bool PlayerCanMove = true;

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
        

        float XInput = Input.GetAxisRaw("Horizontal");
        float YInput = Input.GetAxisRaw("Vertical");

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
        StartCoroutine("PlayerKnockback");
    }

    private IEnumerator PlayerKnockback(float WaitTime)
    {
        print("Start");
        yield return new WaitForSeconds(WaitTime);
        print("End");
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
