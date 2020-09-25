using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowIdle : MonoBehaviour {

    float abductionSpeed;
    float finalAbductionSpeed;
    public float additionalSpeed;
    public Rigidbody2D rb;
    private Animator animat;
    bool addPoint = false;

    public bool isRaining;

    public GameObject CowAbductVFX;

    private void Start()
    {
        animat = GetComponent<Animator>();

        if (isRaining)
        {
            abductionSpeed = 0.8f;
        }

        if (!isRaining)
        {
            abductionSpeed = 1.2f;
        }
    }

    private void Update()
    {
        additionalSpeed = GameObject.FindWithTag("Light").GetComponent<LightCheckCol>().additionalSpeed;
        finalAbductionSpeed = abductionSpeed - additionalSpeed;

        if (addPoint == true)
        {
            CowCounter.cowCounter += 1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            transform.Translate(Vector2.up * finalAbductionSpeed * Time.deltaTime);
        }

        if (collision.gameObject.tag == "Light")
        {
            rb.gravityScale = 0;
            animat.SetBool("isAbducting", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Light")
        {
            rb.gravityScale = 3f;
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
