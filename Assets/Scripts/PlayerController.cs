using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Non Visible
    private GameObject Slash;
    private Collider2D SlashCollider;
    private Animator SlashAnim;
    private Animator PlayerAnim;
    private Rigidbody2D PlayerRB;
    private Vector3 MoveAmount;
    float XInput;
    float YInput;
    private Damageable PlayerDamageable;
    private Animator CloakUIAnim;
    private Health health;

    // Visible
    [SerializeField]
    float speed;
    public bool PlayerCanMove = true;
    [SerializeField]
    private float SlashKnockbackPlayer = 0f;
    public string CloakState = "Ready";
    public float CloakTime = 1f;
    public float CloakRecharge = 3f;
    public GameObject[] Hearts;

    // Start is called before the first frame update
    void Start()
    {
        Slash = GameObject.Find("Slash");
        SlashCollider = Slash.GetComponent<Collider2D>();
        SlashAnim = Slash.GetComponent<Animator>();
        SlashCollider.enabled = false;
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerDamageable = GetComponent<Damageable>();
        PlayerAnim = GetComponent<Animator>();
        CloakUIAnim = GameObject.Find("Cloak UI").GetComponent<Animator>();
        health = GetComponent<Health>();
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

        CloakUpdate();
        UIUpdate();
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

    #region CLOAK
    void CloakUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z) && CloakState == "Ready") {
            CloakState = "Cloaked";
            PlayerDamageable.Invincible = true;
            PlayerAnim.SetBool("Cloaked", true);
            CloakUIAnim.SetInteger("State", 1);
            Invoke(nameof(EndCloak), CloakTime);
        }
    }

    void EndCloak()
    {
        CloakState = "Charging";
        PlayerDamageable.Invincible = false;
        PlayerAnim.SetBool("Cloaked", false);
        CloakUIAnim.SetInteger("State", 2);
        Invoke(nameof(ChargeCloak), CloakRecharge);
    }

    void ChargeCloak()
    {
        CloakUIAnim.SetInteger("State", 0);
        CloakState = "Ready";
    }
    #endregion

    #region UI

    void UIUpdate()
    {

        for (int i = 0; i < Hearts.Length; i++)
        {
            bool active = false;
            if (health.HitPoints-1 >= i)
            {
                active = true;
            }
            Hearts[i].SetActive(active);
        }

    }

    #endregion
}
