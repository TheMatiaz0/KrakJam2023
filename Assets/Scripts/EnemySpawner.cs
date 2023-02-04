using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            var enemy = Instantiate(enemyPrefab, this.transform);
            enemy.name = $"Enemy_{Random.Range(0, 9999)}";
        }
    }
}
