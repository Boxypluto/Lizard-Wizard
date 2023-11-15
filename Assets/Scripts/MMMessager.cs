using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMMessager : MonoBehaviour
{
    
    private MainManager mainManager;

    void Start()
    {
        mainManager = MainManager.Instance;
    }

    public void BroadcastEnemyDeath()
    {
        mainManager.EnemiesInRoom -= 1;
    }
}
