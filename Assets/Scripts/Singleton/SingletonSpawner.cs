using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonSpawner : MonoBehaviour
{
    public Singleton singletonPrefab;
    void Awake()
    {
        if (Singleton.Main is null)
        {
            Instantiate(singletonPrefab, Vector3.zero, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
}
