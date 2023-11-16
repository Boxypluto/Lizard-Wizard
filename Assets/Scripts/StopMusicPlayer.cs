using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusicPlayer : MonoBehaviour
{

    MainManager mainManager;

    void Start()
    {
        mainManager = MainManager.Instance;
        mainManager.currentRoomMusic = "None";

        if (GameObject.Find("Music Player") != null)
        {
            GameObject.Destroy(GameObject.Find("Music Player"));
        }
    }

}
