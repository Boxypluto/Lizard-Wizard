using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        player.transform.position = transform.position;
        GameObject.Destroy(gameObject);
    }
}
