using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float spawnRate = 3f;
    float nextSpawn = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            Vector2 spawnPosition = new (Random.Range(-13f, 13f), transform.position.y);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
