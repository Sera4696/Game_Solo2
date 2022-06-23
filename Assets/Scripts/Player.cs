using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int moveDistance;
    // Start is called before the first frame update
    void Start()
    {
        moveDistance = 2;
    }

    // Update is called once per frame
    void Update()
    {        
        Move();
    }

    //Playerの移動処理
    private void Move()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, moveDistance);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position -= new Vector3(0, 0, moveDistance);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position -= new Vector3(moveDistance, 0, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(moveDistance, 0, 0);
        }

    }
}
