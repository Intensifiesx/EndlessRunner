using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] FloorManager floors;
    [SerializeField] GameObject endScreen;
    public bool rotating = false;

    void Start()
    {   
        rotating = Random.Range(0, 2) == 1;
        transform.Rotate(0, 0, Random.Range(0, 360));
    }

    void FixedUpdate()
    {
        if (rotating)
            transform.Rotate(0, 0, Time.deltaTime * 60);
        // Move the trap to the left in world space to prevent rotation from affecting movement
        transform.Translate(Vector3.left * floors.GetSpeed() * Time.deltaTime, Space.World);
        if (transform.position.x < -40)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy the trap if it collides with the player
        if (other.CompareTag("Player")) {
            endScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
