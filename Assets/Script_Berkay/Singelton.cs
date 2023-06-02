
using System;
using UnityEngine;

public class Singelton<T> : MonoBehaviour where T: MonoBehaviour
{
    public static T Instance;

    private void Awake()
    {

        if (Instance == null) Instance = GameObject.FindObjectOfType<T>();
        else Destroy(gameObject);
    }
}
