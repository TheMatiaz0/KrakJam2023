using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawns;
    [SerializeField] public float interval = 5;
    [SerializeField] public bool periodicSpawn = true;
    [SerializeField] private float ghostSpawnTime = 1;

    private float timeSinceSpawn = 0;

    public void Spawn()
    {
        int i = (int)Mathf.Round(Random.Range(0f, spawns.Count - 1f));
        var obj = Instantiate(spawns[i]);
        var spriteRenderer = obj.GetComponent<SpriteRenderer>();
        var enemyAI = obj.GetComponent<EnemyAI>();
        var dmgTaker = obj.GetComponent<CollisionHpTaker>();
        enemyAI.enabled = false;
        dmgTaker.enabled = false;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
        spriteRenderer.DOColor(new Color(spriteRenderer.color.r, spriteRenderer.color.g, 
            spriteRenderer.color.b, 1), ghostSpawnTime).OnComplete(() =>
        {
            enemyAI.enabled = true;
            dmgTaker.enabled = true;
        });
        
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
