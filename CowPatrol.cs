using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowPatrol : MonoBehaviour {

    float speed = .7f;
    public float additionalSpeed;
    float abductionSpeed;
    float finalAbductionSpeed;
    public float distance;
    bool addPoint = false;

    public Rigidbody2D rb;

    public bool isRaining;

    public GameObject CowAbductVFX;

    private bool movingRight = false;

    public Transform groundDetection;
    public Transform groundDetectionBehind;
    private Animator animat;

    private void Start()
    {
        animat = GetComponent<Animator>();

        if (isRaining)
        {
            abductionSpeed = 1f;
        }

        if (!isRaining)
        {
            abductionSpeed = 1.5f;
        }
    }

    private void Update()
    {
        additionalSpeed = GameObject.FindWithTag("Light").GetComponent<LightCheckCol>().additionalSpeed;
        finalAbductionSpeed = abductionSpeed - additionalSpeed;
        
        Walk();
        if(addPoint == true)
        {
            CowCounter.cowCounter += 1;
            Destroy(gameObject);
        }
    }

    void Walk()
    {
        {
            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
            RaycastHit2D groundbehindInfo = Physics2D.Raycast(groundDetectionBehind.position, Vector2.down, distance);

            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (groundInfo.collider == false && groundbehindInfo.collider == true)
            {

                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }

                else if (movingRight == false)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            rb.gravityScale = 0;
            speed = 0;
            transform.Translate(Vector2.up * finalAbductionSpeed * Time.deltaTime);
            animat.SetBool("isAbducting", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            rb.gravityScale = 3f;
            speed = .7f;
            animat.SetBool("isAbducting", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(CowAbductVFX, transform.position, transform.rotation);
            ProCamera2DShake.Instance.Shake("PlayerHit");
            Vibration.Vibrate(80);
            Score.NumberOfCows -= 1;
            addPoint = true;
        }

    }
}
