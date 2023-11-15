using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{

    private MainManager mainManager;
    public int EnemiesInRoom;

    void Start()
    {
        mainManager = MainManager.Instance;
        LoadCurrentRoom();
        EnemiesInRoom = GameObject.FindGameObjectsWithTag("Enemy").Length;
        mainManager.EnemiesInRoom = EnemiesInRoom;
    }

    void LoadCurrentRoom()
    {
        GameObject newRoom = GameObject.Instantiate(mainManager.RoomList[mainManager.RoomsCleared]);
        newRoom.transform.position = new Vector2(-8, -8);
    }
}
