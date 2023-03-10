using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum SpawnerBehaviour
{
    Periodic,
    SingleRandom,
}

public class SpawnerGroup : MonoBehaviour
{
    [SerializeField] public SpawnerBehaviour behaviour = SpawnerBehaviour.Periodic;

    [SerializeField] private float interval = 2;
    [SerializeField] private int EnemyLimit;
    [SerializeField] private int EnemyLow;
    [SerializeField] private int Increments;
    
    private List<Spawner> spawners = new List<Spawner>();
    private float timeSinceSpawn = 0;
    private int additionalDifficulty = 0;

    private void Start()
    {
        foreach (var spawner in GetComponentsInChildren<Spawner>())
        {
            spawners.Add(spawner);
        }

        RecountMobs();
    }

    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
            
        if (timeSinceSpawn >= interval && behaviour == SpawnerBehaviour.SingleRandom)
        {
            var count = RecountMobs();
            Debug.Log($"Enemies: {count} Extra diff: {additionalDifficulty}");
            
            if (count <= EnemyLow + additionalDifficulty)
            {
                additionalDifficulty += Increments;
                for (int i = 0; i < Increments; i++)
                {
                    int j = (int)Mathf.Round(Random.Range(0f, spawners.Count - 1f));
                    spawners[j].Spawn();
                }
                timeSinceSpawn = 0;
            }
            
            if (count < (uint)(EnemyLimit + additionalDifficulty))
            {
                int i = (int)Mathf.Round(Random.Range(0f, spawners.Count - 1f));
                spawners[i].Spawn();
                timeSinceSpawn = 0;

                if (additionalDifficulty > 0)
                {
                    additionalDifficulty--;
                }
            }
        }
        
        foreach (var spawner in spawners)
        {
            spawner.periodicSpawn = (behaviour == SpawnerBehaviour.Periodic);
            spawner.interval = interval;
        }
    }

    uint RecountMobs()
    {
        return (uint)GameObject.FindGameObjectsWithTag("Enemi").Length;
    }
}
