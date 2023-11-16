using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneName : MonoBehaviour
{
    public void LoadAScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
