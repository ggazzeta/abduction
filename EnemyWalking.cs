using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWalking : MonoBehaviour
{
    [SerializeField]
    public Image AwarenessBG;
    public Image AwarenessBarStroke;
    public Image AwarenessBar;
    public Image exclamation;

    private float Aware = 100f;
    private float Awareness = 0.1f;
    private float AwarenessHit = 2f;
    private float AwarenessHeal = 0.6f;

    private bool isDetecting;

    private float speed;

    public Rigidbody2D rb;

    public Animator animador;

    float counter;
    private int decision;

    private void Start()
    {
        isDetecting = false;
        animador = GetComponent<Animator>();
        counter = Random.Range(5, 30);
        decision = Random.Range(0, 2);
        AwarenessBG.enabled = false;
        AwarenessBarStroke.enabled = false;
        AwarenessBar.enabled = false;
        exclamation.enabled = false;
    }

    private void FixedUpdate()
    {
        if (counter > 10 && counter <= 30)
        {
            counter -= Time.deltaTime;
            speed = 1f;

            if (decision == 1)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                animador.SetBool("isStopped", false);
                if (isDetecting == true)
                {
                    AwarenessBG.enabled = true;
                    AwarenessBarStroke.enabled = true;
                    AwarenessBar.enabled = true;
                    exclamation.enabled = true;

                    if (Aware > Awareness)
                    {
                        Awareness += AwarenessHit;
                    }

                    if (Awareness >= Aware)
                    {
                        Awareness = Aware;
                        FindObjectOfType<GameManager>().EndGameDetected();
                    }
                }
                else if (isDetecting == false)
                {
                    if (Awareness > 0 && Awareness <= Aware)
                    {
                        Awareness -= AwarenessHeal;
                    }

                    if (Awareness <= 0.1)
                    {
                        Awareness = 0;
                        AwarenessBG.enabled = false;
                        AwarenessBarStroke.enabled = false;
                        AwarenessBar.enabled = false;
                        exclamation.enabled = false;
                    }
                }
            }

            if (decision == 0)
            {
                transform.Translate(-Vector2.right * speed * Time.deltaTime);
                transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
                animador.SetBool("isStopped", false);
                if (isDetecting == true)
                {
                    AwarenessBG.enabled = true;
                    AwarenessBarStroke.enabled = true;
                    AwarenessBar.enabled = true;
                    exclamation.enabled = true;

                    if (Aware > Awareness)
                    {
                        Awareness += AwarenessHit;
                    }

                    if (Awareness >= Aware)
                    {
                        Awareness = Aware;
                        FindObjectOfType<GameManager>().EndGameDetected();
                    }
                }
                else if (isDetecting == false)
                {
                    if (Awareness > 0 && Awareness <= Aware)
                    {
                        Awareness -= AwarenessHeal;
                    }

                    if (Awareness <= 0.1)
                    {
                        Awareness = 0;
                        AwarenessBG.enabled = false;
                        AwarenessBarStroke.enabled = false;
                        AwarenessBar.enabled = false;
                        exclamation.enabled = false;
                    }
                }

            }

        }

        else if (counter <= 10 && counter > 0)
        {
            counter -= Time.deltaTime;
            speed = 0;
            animador.SetBool("isStopped", true);
            if (isDetecting == true)
            {
                AwarenessBG.enabled = true;
                AwarenessBarStroke.enabled = true;
                AwarenessBar.enabled = true;
                exclamation.enabled = true;

                if (Aware > Awareness)
                {
                    Awareness += AwarenessHit;
                }

                if (Awareness >= Aware)
                {
                    Awareness = Aware;
                    FindObjectOfType<GameManager>().EndGameDetected();
                }
            }
            else if (isDetecting == false)
            {
                if (Awareness > 0 && Awareness <= Aware)
                {
                    Awareness -= AwarenessHeal;
                }

                if (Awareness <= 0.1)
                {
                    Awareness = 0;
                    AwarenessBG.enabled = false;
                    AwarenessBarStroke.enabled = false;
                    AwarenessBar.enabled = false;
                    exclamation.enabled = false;
                }
            }
        }

        else
        {
            counter = Random.Range(5, 30);
            decision = Random.Range(0, 2);
        }

        float AwarenessRatio = Awareness / Aware;

        AwarenessBar.fillAmount = AwarenessRatio;
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ColCanvas")
        {
            decision = 1;
            FixedUpdate();
        }
        else if (collision.gameObject.tag == "TurnPoint")
        {
            decision = 0;
            FixedUpdate();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Light")
        {
            isDetecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            isDetecting = false;
        }
    }

}
