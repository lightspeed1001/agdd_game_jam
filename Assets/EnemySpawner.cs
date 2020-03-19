using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnLocation;
    public float minTimeBetweenSpawns, maxTimeBetweenSpawns;
    public int numSpawns;

    private int spawnsRemaining;
    private float timeToSpawn = 0;
    private float timeSinceLastSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnsRemaining = numSpawns;
        SetTimeToSpawn();
    }

    private void SetTimeToSpawn()
    {
        timeToSpawn = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
    }

    private void SpawnEnemy()
    {
        GameObject spawn = Instantiate(enemyPrefab, spawnLocation.position, Quaternion.identity);

        spawnsRemaining--;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnsRemaining > 0)
        {
            timeSinceLastSpawn += Time.deltaTime;
            if(timeSinceLastSpawn >= timeToSpawn)
            {
                SpawnEnemy();
                timeSinceLastSpawn = 0;
                SetTimeToSpawn();
            }
        }
    }
}
