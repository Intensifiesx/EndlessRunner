using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy the object if it goes out of bounds
        Destroy(other.gameObject);
    }
}
