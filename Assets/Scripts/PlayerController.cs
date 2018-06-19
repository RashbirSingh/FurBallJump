using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public AudioSource CoinCollision;// Audio file
    public AudioSource TapSound; // audio file

    public float upForce;
    Rigidbody2D rb;
    public bool Started;
    bool GameOver;
    public GameObject coins;
    public static PlayerController instance;
    public float rotation;

    public int Flag = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Started = false;
        GameOver = false;
        rb.isKinematic = true;

	}
	
	// Update is called once per frame
	void Update () {
        if (!Started)
        {
            PauseButton.instance.Flag = false; // pause button OFF when game is not started

            if (Input.GetMouseButtonDown(0))
            {

                Started = true; // game started? true, yes
                rb.isKinematic = false; // turning off kinematics as soon as game starts by taping
                GameManager.Instance.GameStart(); // stating function of game manager called GameStart();
            }
        }
        else if (Started && !GameOver)
        {
            if (Flag == 1)
            {

                transform.Rotate(0, 0, rotation);

                if (Input.GetMouseButtonDown(0)) // on tap on single tap change velocity i.e upforce, in y direction while keeping x as zero
                {
                    rb.velocity = Vector2.zero; // initially velocity zero in both x and y
                    rb.AddForce(new Vector2(0, upForce));
                    this.GetComponent<Animator>().Play("PlayerAnimation");
                    TapSound.Play();

                }

                else
                {
                    this.GetComponent<Animator>().Play("PlayerDownAnimation");
                }
            }
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "abcd")
        {
        }
        else
        {
            GameOver = true;
            GameManager.Instance.GameOver();
        }
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Bird" &&!GameOver)
        {
            GameOver = true;
            GameManager.Instance.GameOver();
        }

        if (collision.gameObject.tag == "Coin" && !GameOver)
        {
            ScoreManager.instance.IncrementScoreDiamond();
            CoinCollision.Play();
        }
	}
}

