using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum SpawnerBehaviour
{
    Periodic,
    SingleRandom,
    OnCall
}

public class SpawnerGroup : MonoBehaviour
{
    [SerializeField] public SpawnerBehaviour behaviour = SpawnerBehaviour.Periodic;

    [SerializeField] private float interval = 2;
    
    private List<Spawner> spawners = new List<Spawner>();
    private float timeSinceSpawn = 0;

    private void Start()
    {
        foreach (var spawner in GetComponentsInChildren<Spawner>())
        {
            spawners.Add(spawner);
        }
    }

    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
            
        if (timeSinceSpawn >= interval)
        {
            int i = (int)Mathf.Round(Random.Range(0f, spawners.Count - 1f));
            spawners[i].Spawn();
            timeSinceSpawn = 0;
        }
        
        foreach (var spawner in spawners)
        {
            spawner.periodicSpawn = (behaviour == SpawnerBehaviour.Periodic);
            spawner.interval = interval;
        }
    }
}
