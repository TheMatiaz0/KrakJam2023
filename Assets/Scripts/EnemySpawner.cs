using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    private List<GameObject> spawnedEnemies = new();

    private KeyCode[] keyCodes =
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
    };


    private void Update()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]) && i < enemyPrefabs.Length)
            {
                var enemy = Instantiate(enemyPrefabs[i], this.transform);
                enemy.gameObject.name = $"Enemy_{spawnedEnemies.Count + 1}";
                spawnedEnemies.Add(enemy);
            }
        }
    }
}