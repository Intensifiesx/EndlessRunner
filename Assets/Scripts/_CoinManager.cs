using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CoinManager : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    float spawnRate = 3f;
    float nextSpawn = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            Vector2 spawnPosition = new (Random.Range(-13f, 13f), transform.position.y);
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
