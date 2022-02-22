using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    public GameObject[] spawnpoints;

    void Awake()
    {
        Instance = this; 

    }

    public Transform spawnpoint1()
    {
        return spawnpoints[0].transform;
    }

    public Transform spawnpoint2()
    {
        return spawnpoints[1].transform;
    }

}
