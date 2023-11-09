using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
