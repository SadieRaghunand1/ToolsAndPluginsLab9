using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        //forever hater of coroutines and ienumerators char to sadie
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    void SpawnEnemy()
    {
        int random = Random.Range(0, 3);
        IEnemyBuilder builder = random switch
        {
            0 => new SmallShips(),
            1 => new MediumShips(),
            _ => new LargeShips()
        };

        builder.SetShip();
        builder.Speed();
        builder.PointValue();

        switch (random)
        {
            case 0: // SmallShips
                builder.SetColor(Color.green).SetScale(0.8f);
                break;
            case 1: // MediumShips
                builder.SetColor(Color.yellow).SetScale(1.2f);
                break;
            case 2: // LargeShips
                builder.SetColor(Color.red).SetScale(1.5f);
                break;
        }

        Enemy enemyData = builder.GetEnemy();

        // Spawn it in the world
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        EnemyBehavior behavior = newEnemy.GetComponent<EnemyBehavior>();

        behavior.SetupFromData(enemyData);

        Debug.Log($"Spawned: {enemyData.Ship} | Speed: {enemyData.Speed} | Points: {enemyData.Points}");
    }
}