using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDelete : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public bool isFall;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.05f;
        isFall = false;
    }

    // Update is called once per frame
    void Update()
    {
        Fall();
        Dead();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("通り抜け終えた");
            isFall = true;
        }
    }

    void Fall()
    {
        if (isFall)
        {
            transform.position += new Vector3(0, -speed, 0);
        }
    }

    void Dead()
    {
        if(transform.position.y < -2.5f)
        {
            Debug.Log("死");
            Player.ScoreCount += 1;
            Destroy(gameObject);
        }
    }
}
