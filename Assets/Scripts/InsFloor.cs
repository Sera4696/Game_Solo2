using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsFloor : MonoBehaviour
{
    [SerializeField] GameObject insFloor;
    [SerializeField] GameObject[] preFloors;
    [SerializeField] int floorCount;
    [SerializeField] int insCount;
    // Start is called before the first frame update
    void Start()
    {
        
        insCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (insFloor == null && insCount == 3)
        {
            insCount = 0;
            floorCount = Random.Range(0, 4);
            insFloor = Instantiate(preFloors[floorCount], transform.position, Quaternion.identity);            
        }

        if (insFloor == null &&
            (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || 
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            insCount += 1;
        }
    }
}
