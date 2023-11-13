using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReferencer : MonoBehaviour
{
    public GameObject player;
    public GameObject slash;
    public GameObject HomingTarget;
    public GameObject Custom2;
    public GameObject Custom3;

    void Start()
    {
        player = GameObject.Find("Player");
        slash = GameObject.Find("Slash");

    }

}
