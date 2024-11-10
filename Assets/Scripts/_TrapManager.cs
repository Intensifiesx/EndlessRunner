using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public GameObject trapPrefab;
    float spawnRate = 5f;
    float nextSpawn = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            Vector2 spawnPosition = new (transform.position.x, transform.position.y + Random.Range(-7f, 7f));
            Instantiate(trapPrefab, spawnPosition, Quaternion.identity).SetActive(true);
        }
    }
}
