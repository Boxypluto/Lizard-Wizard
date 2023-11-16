using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOnZ : MonoBehaviour
{

    [SerializeField] string scene;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {

            SceneManager.LoadScene(scene);

        }
    }
}
