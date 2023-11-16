using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{

    private MainManager mainManager;
    public int EnemiesInRoom;
    GameObject titlePlayer;
    private GameObject MusicSource;
    private MusicPlayer MusicPlayer;

    public AudioClip EasyMusic;
    public AudioClip MediumMusic;
    public AudioClip HardMusic;

    void Start()
    {
        mainManager = MainManager.Instance;
        LoadCurrentRoom();
        EnemiesInRoom = GameObject.FindGameObjectsWithTag("Enemy").Length;
        mainManager.EnemiesInRoom = EnemiesInRoom;
        titlePlayer = GameObject.Find("Title Player");
        MusicSource = GameObject.Find("Music Player");
        MusicPlayer = MusicSource.GetComponent<MusicPlayer>();

        if (titlePlayer != null)
        {
            Destroy(titlePlayer);
        }

        if (mainManager.currentRoomMusic == "None" && mainManager.RoomsCleared < mainManager.RoomsInDifficulty)
        {
            MusicPlayer.PlayNewMusic(EasyMusic);
            mainManager.currentRoomMusic = "Easy";

        } else if (mainManager.currentRoomMusic == "Easy" && mainManager.RoomsCleared == mainManager.RoomsInDifficulty)
        {
            MusicPlayer.PlayNewMusic(MediumMusic);
            mainManager.currentRoomMusic = "Medium";

        } else if (mainManager.currentRoomMusic == "Medium" && mainManager.RoomsCleared == mainManager.RoomsInDifficulty * 2)
        {
            MusicPlayer.PlayNewMusic(HardMusic);
            mainManager.currentRoomMusic = "Hard";
        }
    }

    void LoadCurrentRoom()
    {
        GameObject newRoom = GameObject.Instantiate(mainManager.RoomList[mainManager.RoomsCleared]);
        newRoom.transform.position = new Vector2(-8, -8);
    }
}
