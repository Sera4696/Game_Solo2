using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int moveDistance;
    [SerializeField] public float gravity;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        moveDistance = 2;
        gravity = -0.08f;
    }

    // Update is called once per frame
    void Update()
    {        
        Move();
    }

    //Playerの移動処理
    private void Move()
    {
        //transform.position += new Vector3(0, gravity, 0);
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, moveDistance);
            gravity = -0.08f;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position -= new Vector3(0, 0, moveDistance);
            gravity = -0.08f;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position -= new Vector3(moveDistance, 0, 0);
            gravity = -0.08f;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(moveDistance, 0, 0);
            gravity = -0.08f;
        }

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "FR" || other.gameObject.tag == "FB" ||
            other.gameObject.tag == "FG" || other.gameObject.tag == "FY")
        {
            gravity = 0;
        }
    }
}
