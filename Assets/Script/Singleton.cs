using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T:Component
{
    private static T instance;
    
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<T>();

                if(instance == null )
                {
                    GameObject gameObject = new GameObject("Singleton");
                    instance = gameObject.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    public void Awake()
    {
        if(instance == null )
        {
            instance = this as T;
        }
        else
        {
            if(instance != this)
                Destroy(gameObject);
        }
    }
    
}
