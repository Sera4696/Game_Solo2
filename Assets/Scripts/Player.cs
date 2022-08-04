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
    [SerializeField] public float deadCount;

    [SerializeField] public static int ScoreCount;

    [SerializeField] public bool playerDead;
    [SerializeField] public bool isStart;

    [SerializeField] public GameObject Score;
    [SerializeField] public GameObject Result;
    [SerializeField] public GameObject RScore;
    [SerializeField] public GameObject Retry;
    [SerializeField] public GameObject Title;
    [SerializeField] public GameObject StartT;
    [SerializeField] public GameObject UIBack;
    [SerializeField] public GameObject StarL;
    [SerializeField] public GameObject StarS;
    [SerializeField] public GameObject StarR;

    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        moveDistance = 2;
        gravity = -0.08f;
        moveCount = 50;
        UIBack.SetActive(false);
        Result.SetActive(false);
        RScore.SetActive(false);
        Retry.SetActive(false);
        StarL.SetActive(false);
        StarS.SetActive(false);
        StarR.SetActive(false);
        deadCount = 0;
        playerDead = false;
        isStart = false;

        audioSource = GetComponent<AudioSource>();
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
                isStart = true;
                audioSource.PlayOneShot(sound1);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.position -= new Vector3(0, -2, moveDistance);
                gravity = -0.08f;
                moveCount = 0;
                isStart = true;
                audioSource.PlayOneShot(sound1);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position -= new Vector3(moveDistance, -2, 0);
                gravity = -0.08f;
                moveCount = 0;
                isStart = true;
                audioSource.PlayOneShot(sound1);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += new Vector3(moveDistance, 2, 0);
                gravity = -0.08f;
                moveCount = 0;
                isStart = true;
                audioSource.PlayOneShot(sound1);
            }
        }

    }

    public void UI()
    {

        Text score_text = Score.GetComponent<Text>();

        Text result_text = Result.GetComponent<Text>();
        Text rscore_text = RScore.GetComponent<Text>();
        Text retry_text = Retry.GetComponent<Text>();

        score_text.text = "Score:" + ScoreCount;
        rscore_text.text = "" + ScoreCount;

        if (isStart)
        {
            Title.transform.position += new Vector3(0, 1.5f, 0);
            StartT.transform.position += new Vector3(0, -1.5f, 0);
        }

        if (playerDead)
        {
            deadCount++;
        }

        if (deadCount > 50)
        {
            UIBack.SetActive(true);
        }

        if (deadCount > 100)
        {
            Result.SetActive(true);
        }

        if (deadCount > 150)
        {
            RScore.SetActive(true);
        }

        if (deadCount > 200)
        {
            if (ScoreCount >= 25)
            {
                StarL.SetActive(true);
            }

            if (ScoreCount >= 50)
            {
                StarL.SetActive(true);
                StarS.SetActive(true);
            }

            if (ScoreCount >= 100)
            {
                StarL.SetActive(true);
                StarS.SetActive(true);
                StarR.SetActive(true);
            }
        }

        if (deadCount > 250)
        {
            Retry.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    void Dead()
    {
        if (transform.position.y < -2.0f)
        {
            audioSource.PlayOneShot(sound2);
            playerDead = true;
            Debug.Log("死");
            //gameObject.SetActive(false);
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
