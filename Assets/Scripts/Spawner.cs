using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawns;
    [SerializeField] public float interval = 5;
    [SerializeField] public bool periodicSpawn = true;

    private float timeSinceSpawn = 0;

    public void Spawn()
    {
        int i = (int)Mathf.Round(Random.Range(0f, spawns.Count - 1f));
        var obj = Instantiate(spawns[i]);
        obj.transform.position = transform.position;

        timeSinceSpawn = 0;
    }    
    
    void Update()
    {
        if (periodicSpawn)
        {
            timeSinceSpawn += Time.deltaTime;
            
            if (timeSinceSpawn >= interval)
            {
                Spawn();
            }
        }

    }
}
