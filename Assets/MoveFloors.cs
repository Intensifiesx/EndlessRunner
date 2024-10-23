using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloors : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float floorWidth = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < -floorWidth)
        {
            gameObject.transform.position = new Vector3(transform.position.x + (3 * floorWidth), 0, 0);
        }
    }
}
