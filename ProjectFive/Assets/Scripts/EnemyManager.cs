using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime = 1f;
    public Transform[] spawnPoints;
    private bool debug = true;
    public int numberOfUsedSpawns;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void Update()
    {
        if (Debug.isDebugBuild)
        {
            RespondToDebugKeys();
        }
    }

    void Spawn()
    {
        List<Transform> freeSpawnPoints = new List<Transform>(spawnPoints);
        if (debug == true)
        {
            for(int i = 0; i< numberOfUsedSpawns; i++)
            {
                if (freeSpawnPoints.Count <= 0)
                    return;

                int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                Transform pos = freeSpawnPoints[spawnPointIndex];
                freeSpawnPoints.RemoveAt(spawnPointIndex);
                Instantiate(enemy, pos.position, pos.rotation);
                //Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
        }
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            debug = !debug;
        }
    }
}
