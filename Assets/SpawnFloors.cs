using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFloors : MonoBehaviour
{
    [SerializeField] GameObject Floor;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0, pos = 20; i < 2; i++, pos += 20) {
            // create a new floor
            Floor.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0F,1F), Random.Range(0, 1F), Random.Range(0, 1F));
            Instantiate(Floor, new Vector3(pos, 0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
