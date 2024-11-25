using System.Collections;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    // make speed override the default value of 6f
    public float speed = 6f;
    [SerializeField] float floorWidth = 20f;
    [SerializeField] GameObject topFloor, bottomFloor;
    ArrayList floors = new();
    public float numFloors = 5;

    void Start()
    {
        floors.Add(topFloor);
        floors.Add(bottomFloor);

        for(int i = 1, pos = 20; i < numFloors; i++, pos += 20) {
            GameObject newTopFloor = Instantiate(topFloor, new Vector3(topFloor.transform.position.x+pos, topFloor.transform.position.y, 0), Quaternion.identity, transform);
            newTopFloor.name = "Floor#" + i;
            GameObject newBottomFloor = Instantiate(bottomFloor, new Vector3(bottomFloor.transform.position.x+pos, bottomFloor.transform.position.y, 0), Quaternion.identity, transform);
            newBottomFloor.name = "Floor#" + i;

            floors.Add(newTopFloor);
            floors.Add(newBottomFloor);
        }
    }
    void FixedUpdate()
    {
        foreach (GameObject i in floors)
            i.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = new Vector3(other.transform.position.x + (numFloors * floorWidth), other.transform.position.y, 0);
    }

    public float GetSpeed()
    {
        return speed;
    }

    public float GetFloorWidth()
    {
        return floorWidth;
    }
}
