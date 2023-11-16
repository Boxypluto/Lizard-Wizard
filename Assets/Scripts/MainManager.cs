using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public int RoomsCleared = 0;
    public GameObject[] EasyRooms;
    public GameObject[] MediumRooms;
    public GameObject[] HardRooms;
    public List<GameObject> RoomList = new List<GameObject>();
    public List<GameObject> TempEasyRooms = new List<GameObject>();
    public List<GameObject> TempMediumRooms = new List<GameObject>();
    public List<GameObject> TempHardRooms = new List<GameObject>();
    public int RoomsInDifficulty = 7;
    public int EnemiesInRoom = 9999;
    public string currentRoomMusic = "None";

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

    public void OnRestart()
    {
        RoomList.Clear();
        SetupRoomList();
        EnemiesInRoom = 9999;
        RoomsCleared = 0;
    }

    void SetupRoomList()
    {

        TempEasyRooms = EasyRooms.ToList();
        TempMediumRooms = MediumRooms.ToList();
        TempHardRooms = HardRooms.ToList();

        for (int i = 0; i < RoomsInDifficulty; i++)
        {
            int pick = Random.Range(0, TempEasyRooms.Count);
            RoomList.Add(TempEasyRooms[pick]);
            TempEasyRooms.RemoveAt(pick);
            
        }
        for (int i = 0; i < RoomsInDifficulty; i++)
        {
            int pick = Random.Range(0, TempMediumRooms.Count);
            RoomList.Add(TempMediumRooms[Random.Range(0, TempMediumRooms.Count)]);
            TempMediumRooms.RemoveAt(pick);
        }
        for (int i = 0; i < RoomsInDifficulty; i++)
        {
            int pick = Random.Range(0, TempHardRooms.Count);
            RoomList.Add(TempHardRooms[Random.Range(0, TempHardRooms.Count)]);
            TempHardRooms.RemoveAt(pick);
        }

        for (int i = 0; i < RoomList.Count; i++)
        {
            print(RoomList[i]);
        }

    }

    void Update()
    {
        
        if (EnemiesInRoom <= 0)
        {
            LoadNextRoom();
        }

    }

    public void LoadNextRoom()
    {

        if (RoomsCleared >= RoomList.Count - 1)
        {
            EnemiesInRoom = 9999;

            currentRoomMusic = "None";

            if (GameObject.Find("Music Player") != null)
            {
                GameObject.Destroy(GameObject.Find("Music Player"));
            }

            SceneManager.LoadScene("You Win!");

        } else
        {
            RoomsCleared++;
            EnemiesInRoom = 9999;
            SceneManager.LoadScene("Room");
        }
    }

    

}
