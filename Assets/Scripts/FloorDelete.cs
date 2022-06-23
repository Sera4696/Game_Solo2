using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            Debug.Log("通り抜け終えた");
            Destroy(other.gameObject);
        }
       
    }
}
