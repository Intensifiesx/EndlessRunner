using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    [SerializeField] FloorManager floors;
    public GameObject trapPrefab;
    private float baseSpawnRate = 5f;
    private float nextSpawn = 0f;
    private int maxTraps = 4; // Maximum number of traps
    private float maxTimeFactor = 10f; // Cap the time factor at 10 for balanced difficulty
    private List<GameObject> activeTraps = new();

    void Update()
    {
        // Get the latest speed from the FloorManager
        float speed = floors.GetSpeed();

        // Time-based scaling with a capped time factor
        float timeFactor = Mathf.Min(maxTimeFactor, Mathf.Max(1, Time.timeSinceLevelLoad / 30));
        float spawnRate = Mathf.Max(1f, baseSpawnRate / timeFactor);

        // Only spawn a new trap if we're below the max trap limit
        if (Time.time > nextSpawn && activeTraps.Count < maxTraps)
        {
            nextSpawn = Time.time + spawnRate;
            Vector2 spawnPosition = new (transform.position.x, transform.position.y + Random.Range(-7f, 7f));
            GameObject newTrap = Instantiate(trapPrefab, spawnPosition, Quaternion.identity);
            newTrap.SetActive(true);
            activeTraps.Add(newTrap); // Add trap to active list
        }

        // Clean up any traps that are destroyed or out of bounds
        activeTraps.RemoveAll(trap => trap == null);
    }
}
