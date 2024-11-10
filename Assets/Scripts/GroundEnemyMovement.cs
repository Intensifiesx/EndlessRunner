using UnityEngine;

public class GroundEnemyMovement : MonoBehaviour
{
    public float speed = 3f;

    void Awake()
    {
        speed = Random.Range(2f, 7f); // Randomize speed

        // Randomly decide whether the enemy moves right or left
        if (Random.Range(0, 2) > 0)
        {
            // Move to the right
            speed = Mathf.Abs(speed); // Ensure speed is positive
            Vector3 theScale = transform.localScale;
            theScale.x = -theScale.x;
            transform.localScale = theScale;
            return;
        }
        
        // Move to the left
        speed = -Mathf.Abs(speed); // Ensure speed is negative
    }

    void Update()
    {
        // Move the enemy horizontally based on speed
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("OutOfBounds"))
        {
            Destroy(gameObject);
        }
    }
}
