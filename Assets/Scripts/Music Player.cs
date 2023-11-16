using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public static MusicPlayer Instance;
    private AudioSource Music;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

        Music = GetComponent<AudioSource>();

    }

    public void PlayNewMusic(AudioClip clip)
    {
        Music.Stop();
        Music.clip = clip;
        Music.Play();
    }
}
