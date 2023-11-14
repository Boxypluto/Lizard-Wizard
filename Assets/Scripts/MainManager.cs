using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public int RoomsCleared = 0;
    public GameObject[] EasyRooms;
    public GameObject[] MediumRooms;
    public GameObject[] HardRooms;
    public GameObject[] RoomList;
    public int RoomsInDifficulty = 7;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void SetupRoomList()
    {

        GameObject[] TempEasyRooms = EasyRooms;
        GameObject[] TempMediumRooms = MediumRooms;
        GameObject[] TemphardRooms = HardRooms;

        for (int i = 0; i < 3*RoomsInDifficulty; i++)
        {
            if (i >= 0 && i < RoomsInDifficulty)
            {
                GameObject pick = EasyRooms[Random.Range(0, EasyRooms.Length-1)];
                //RoomList

            }
            else if (i >= RoomsInDifficulty && i < RoomsInDifficulty * 2)
            {


            }
            else if (i >= RoomsInDifficulty * 2 && i < RoomsInDifficulty * 3)
            {

            }
        }


    }

    public void LoadNextRoom()
    {
        RoomsCleared++;
        
    }

}
