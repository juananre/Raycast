using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_Enemy : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private Transform[] spawnPoints;

    [Header("Objects")]
    [SerializeField] private GameObject[] enemies;

    [Header("Spawn Time")]
    [SerializeField] private float spawnTime = 5f;

    private void Start()
    {
        if (spawnPoints.Length == 0 || enemies.Length == 0)
        {
            Debug.LogError("Puntos de generación o enemigos no asignados.");
            return;
        }

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        int enemyIndex = Random.Range(0, enemies.Length);

        Transform spawnPoint = spawnPoints[spawnIndex];
        GameObject enemyPrefab = enemies[enemyIndex];

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
