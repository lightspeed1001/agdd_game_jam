using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : BasicEnemy
{
    public GameObject enemyPrefab;
    public Transform spawnLocation;
    public float minTimeBetweenSpawns, maxTimeBetweenSpawns;
    public int numSpawns;
    public bool dieWhenOutOfSpawns;

    private int spawnsRemaining;
    private float timeToSpawn = 0;
    private float timeSinceLastSpawn = 0;


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
            if(spawnsRemaining == 0 && dieWhenOutOfSpawns) OnDeath();
        }
        else if(dieWhenOutOfSpawns)
        {
            OnDeath();
        }
    }

    #region Overrides

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        spawnsRemaining = numSpawns;
        SetTimeToSpawn();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnDamageTaken()
    {
        base.OnDamageTaken();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void RegisterComponents()
    {
        base.RegisterComponents();
    }

    protected override void RegisterEvents()
    {
        base.RegisterEvents();
    }

    protected override void OnDeath()
    {
        base.OnDeath();
    }
    #endregion
}
