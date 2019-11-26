using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoints;
    private bool debug = true;
    public int numberOfUsedSpawns;
    public FloatReference enemySpawnTime;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", enemySpawnTime.Value);
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
            }
        }

        Invoke("Spawn", enemySpawnTime.Value);
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            debug = !debug;
        }
    }
}
