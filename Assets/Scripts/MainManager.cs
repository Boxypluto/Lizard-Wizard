using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public int RoomsCleared = 0;
    public GameObject[] EasyRooms;
    public GameObject[] MediumRooms;
    public GameObject[] HardRooms;
    public List<GameObject> RoomList = new List<GameObject>();
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
        SetupRoomList();
    }

    void SetupRoomList()
    {

        GameObject[] TempEasyRooms = EasyRooms;
        GameObject[] TempMediumRooms = MediumRooms;
        GameObject[] TempHardRooms = HardRooms;

        for (int i = 0; i < RoomsInDifficulty; i++)
        {
            RoomList.Add(TempEasyRooms[Random.Range(0, TempEasyRooms.Length)]);
        }
        for (int i = 0; i < RoomsInDifficulty; i++)
        {
            RoomList.Add(TempMediumRooms[Random.Range(0, TempMediumRooms.Length)]);
        }
        for (int i = 0; i < RoomsInDifficulty; i++)
        {
            RoomList.Add(TempHardRooms[Random.Range(0, TempHardRooms.Length)]);
        }

        for (int i = 0; i < RoomList.Count; i++)
        {
            print(RoomList[i]);
        }

    }

    public void LoadNextRoom()
    {
        RoomsCleared++;
        SceneManager.LoadScene("Room");

    }

    

}
