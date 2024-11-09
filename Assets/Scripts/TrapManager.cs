using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public float angle = 0;
    float speed;
    [SerializeField] FloorManager moveFloors;

    void Start()
    {
        speed = moveFloors.GetSpeed();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, angle++);
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
