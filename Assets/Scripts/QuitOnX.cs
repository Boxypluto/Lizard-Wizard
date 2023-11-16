using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnX : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Application.Quit();
        }
    }
}
