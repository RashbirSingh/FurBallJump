using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    public float Speed;
    public float UpDownSpeed;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveBird();
        InvokeRepeating("SwitchUpDown", 0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SwitchUpDown()
    {
        UpDownSpeed = -UpDownSpeed;
        rb.velocity = new Vector2(-Speed, UpDownSpeed);
    }

    void MoveBird()
    {
        rb.velocity = new Vector2(-Speed, UpDownSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BirdRemover")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
