using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] public int moveDistance;
    [SerializeField] public float gravity;

    [SerializeField] public float moveCount;

    [SerializeField] public static int ScoreCount;

    [SerializeField] public GameObject Score;
    [SerializeField] public GameObject UIBack;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        moveDistance = 2;
        gravity = -0.08f;
        moveCount = 50;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UI();
        Dead();
    }

    //Playerの移動処理
    private void Move()
    {
        moveCount++;
        transform.position += new Vector3(0, gravity, 0);

        if (moveCount > 50)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position += new Vector3(0, 2, moveDistance);
                gravity = -0.08f;
                moveCount = 0;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.position -= new Vector3(0, -2, moveDistance);
                gravity = -0.08f;
                moveCount = 0;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position -= new Vector3(moveDistance, -2, 0);
                gravity = -0.08f;
                moveCount = 0;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += new Vector3(moveDistance, 2, 0);
                gravity = -0.08f;
                moveCount = 0;
            }
        }

    }

    public void UI()
    {
        Text score_text = Score.GetComponent<Text>();

        score_text.text = "Score:" + ScoreCount;
    }

    void Dead()
    {
        if (transform.position.y < -2.5f)
        {
            Debug.Log("死");
            Destroy(gameObject);
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "FR" || other.gameObject.tag == "FB" ||
            other.gameObject.tag == "FG" || other.gameObject.tag == "FY")
        {
            gravity = 0;
        }
    }
}
