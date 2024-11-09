using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingWall : MonoBehaviour
{
    static float speed;
    float deletePosition;
    [SerializeField] FloorManager floors;

    // Start is called before the first frame update
    void Start()
    {   
        speed = floors.GetSpeed();
        deletePosition = -floors.GetFloorWidth() * 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < deletePosition)
        {
            Destroy(gameObject);
        }
    }
}
