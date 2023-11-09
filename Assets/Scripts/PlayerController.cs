using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        Slash = GameObject.Find("Slash");
        SlashCollider = Slash.GetComponent<Collider2D>();
        SlashAnim = Slash.GetComponent<Animator>();
        SlashCollider.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {

        float XInput = Input.GetAxisRaw("Horizontal");
        float YInput = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(XInput * Time.deltaTime * speed, YInput * Time.deltaTime * speed, 0);

        SlashUpdate(XInput, YInput);
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            SlashAnim.SetTrigger("Slash");
        }

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
