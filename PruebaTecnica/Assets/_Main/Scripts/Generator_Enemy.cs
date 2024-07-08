using System.Collections;
using UnityEngine;

public class GeneratorEnemy : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private Transform[] spawnPoints;

    [Header("Objects")]
    [SerializeField] private GameObject[] enemies;

    [Header("Spawn Time")]
    [SerializeField] private float spawnTime = 5f;

    [Header("Observer")]
    [SerializeField] private ScoreManager scoreManager;

    private void Start()
    {
        if (spawnPoints.Length == 0 || enemies.Length == 0 || scoreManager == null)
        {
            Debug.LogError("Puntos de generación, enemigos o ScoreManager no asignados.");
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

        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        ISubject enemySubject = enemy.GetComponent<ISubject>();
        if (enemySubject != null)
        {
            enemySubject.RegisterObserver(scoreManager);
        }
    }
}
