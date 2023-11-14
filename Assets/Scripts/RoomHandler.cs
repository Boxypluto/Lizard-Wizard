using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{

    private MainManager mainManager;

    void Start()
    {
        mainManager = MainManager.Instance;
        LoadCurrentRoom();
        print(GameObject.FindGameObjectsWithTag("Enemy").Length);
    }

    void LoadCurrentRoom()
    {
        GameObject newRoom = GameObject.Instantiate(mainManager.RoomList[mainManager.RoomsCleared]);
        newRoom.transform.position = new Vector2(-8, -8);
    }
}
