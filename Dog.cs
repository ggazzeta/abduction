using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public float speed;
    public SpriteRenderer SR;

    public Rigidbody2D rb;

    public Animator animador;
    public float abductionSpeed;

    float counter;
    private int decision;

    private void Start()
    {
        animador = GetComponent<Animator>();
        counter = Random.Range(5, 30);
        decision = Random.Range(0, 2);
        SR = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Walk();
    }

    void Walk()
    {
        if (counter > 10 && counter <= 30)
        {
            counter -= Time.deltaTime;
            speed = 4f;
            //RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
            //RaycastHit2D groundbehindInfo = Physics2D.Raycast(groundDetectionBehind.position, Vector2.down, distance);

            if (decision == 1)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                SR.flipX = true;
                animador.SetBool("isStopped", false);
                //movingRight = true;
            }

            if (decision == 0)
            {
                transform.Translate(-Vector2.right * speed * Time.deltaTime);
                SR.flipX = false;
                animador.SetBool("isStopped", false);
                //movingRight = false;
            }

        }

        else if (counter <= 10 && counter > 0)
        {
            counter -= Time.deltaTime;
            speed = 0;
            animador.SetBool("isStopped", true);
        }

        else
        {
            counter = Random.Range(5, 30);
            decision = Random.Range(0, 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ColCanvas")
        {
            decision = 1;
            Walk();
        }
        else if (collision.gameObject.tag == "TurnPoint")
        {
            decision = 0;
            Walk();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cows")
        {
            transform.Translate(Vector2.up * abductionSpeed * Time.deltaTime);
        }

        if (collision.gameObject.tag == "Cows")
        {
            rb.gravityScale = 0;
            animador.SetBool("isAbducting", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cows")
        {
            rb.gravityScale = 3f;
            animador.SetBool("isAbducting", false);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Score.NumberOfCows -= 1;
            Destroy(gameObject);
        }
    }*/
}
