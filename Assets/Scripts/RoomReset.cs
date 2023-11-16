using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomReset : MonoBehaviour
{
    MainManager mainManager;

    void Start()
    {
        mainManager = MainManager.Instance;
        mainManager.OnRestart();
    }
}
