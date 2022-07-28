using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherDelete : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public bool isFall;
    [SerializeField] public static int Score;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.18f;
        isFall = false;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Fall();
        //Dead();
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "FR")
        {
            Debug.Log("離れた!");
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
        if (transform.position.y < -2.5f)
        {
            Debug.Log("死");
            Destroy(gameObject);
        }
    }


}
