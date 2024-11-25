using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private UpdateUI updateUI;
    private FloorManager floors;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        // Find the FloorManager and UpdateUI components in the scene
        floors = FindObjectOfType<FloorManager>();
        updateUI = FindObjectOfType<UpdateUI>();
        speed = floors.GetSpeed();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && updateUI != null)
        {
            updateUI.IncrementGold(1);
            Destroy(gameObject);
        }
    }
}
