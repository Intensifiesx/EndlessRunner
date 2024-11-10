using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    static float speed = 0f;
    float deletePosition;
    [SerializeField] FloorManager floors;
    [SerializeField] GameObject endScreen;

    void Start()
    {   
        // Set speed from FloorManager (ensure it is positive for leftward movement)
        speed = Mathf.Abs(floors.GetSpeed());
        
        // Set delete position based on floor width
        deletePosition = -floors.GetFloorWidth() * 2;

        // Rotate the trap visually without affecting movement direction
        transform.Rotate(0, 0, Random.Range(0, 360));
    }

    void FixedUpdate()
    {
        // Move the trap to the left in world space to prevent rotation from affecting movement
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

        // Destroy the trap if it goes past the delete position
        if (transform.position.x < deletePosition)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("Collision detected");
        // Destroy the trap if it collides with the player
        if (other.CompareTag("Player")) {
            Destroy(other);
            endScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
