using LDtkUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ShieldGenerator : MonoBehaviour
{

    private LDtkFields LDTK;
    private GameObject Shield;

    void Start()
    {
        Shield = transform.Find("Shield").gameObject;

        LDTK = GetComponent<LDtkFields>();

        if ( LDTK != null )
        {
            Vector2 Position;
            LDTK.TryGetPoint("Shield_Position", out Position);
            Shield.transform.position = Position;
        }
    }

}
