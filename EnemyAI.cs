using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour {

    public Animator animat;

    float counter;
    public bool isAwake;
    public bool isColliding;

    [SerializeField]
    public Image AwarenessBarBackground;
    public Image AwarenessBar;
    public Image BackgroundAware;
    public Image Question;
    public Image CaughtBackground;
    public Image CaughtBar;
    public Image Exclamation;

    public Text myText;

    private float Aware = 100.0f;
    private float Awareness = 0.1f;
    public float AwarenessHit = 1.3f;
    private float AwarenessHeal = 0.6f;

    private void Awake()
    {
        isAwake = false;
        isColliding = false;
    }

    void Start()
    {
        counter = Random.Range(30, 35);
        AwarenessBar.enabled = false;
        AwarenessBarBackground.enabled = false;
        BackgroundAware.enabled = false;
        Question.enabled = false;
        CaughtBackground.enabled = false;
        CaughtBar.enabled = false;
        Exclamation.enabled = false;
        myText.text = "";
        // animat = GetComponent<Animator>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            isColliding = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            isColliding = false;
        }
    }

    void FixedUpdate()
    {

        float AwarenessRatio = Awareness / Aware;

        AwarenessBar.fillAmount = AwarenessRatio;

        if (counter > 12 && counter <= 35)
        {
            animat.SetBool("isAsleep", true);
            counter -= Time.deltaTime;
            //Debug.Log("Sleeping... zzzz");
            myText.text = "zZzZ";

            if (Awareness > 0 && Awareness <= Aware)
            {
                Awareness -= AwarenessHeal;
            }

            if (Awareness <= 0.1)
            {
                Awareness = 0;
                AwarenessBar.enabled = false;
                AwarenessBarBackground.enabled = false;
                BackgroundAware.enabled = false;
                Question.enabled = false;
            }
        }
        else if (counter <= 12 && counter > 0)
        {
            if (isColliding == false)
            {
                animat.SetBool("isAsleep", false);
                myText.text = "";
                counter -= Time.deltaTime;
                isAwake = true;
                //Debug.Log("It's Awake!!");

                if (Awareness > 0 && Awareness <= Aware)
                {
                    Awareness -= AwarenessHeal;
                }

                if (Awareness <= 0.1)
                {
                    Awareness = 0;
                    AwarenessBar.enabled = false;
                    AwarenessBarBackground.enabled = false;
                    BackgroundAware.enabled = false;
                    Question.enabled = false;
                }
            }

            else if (isColliding == true && isAwake == true)
            {
                myText.text = "";
                counter -= Time.deltaTime;
                AwarenessBar.enabled = true;
                AwarenessBarBackground.enabled = true;
                BackgroundAware.enabled = true;
                Question.enabled = true;

                if (Aware > Awareness)
                {
                    Awareness += AwarenessHit;
                }

                if(Awareness >= Aware)
                {
                    Awareness = Aware;
                    CaughtBackground.enabled = true;
                    CaughtBar.enabled = true;
                    Exclamation.enabled = true;
                    FindObjectOfType<GameManager>().EndGameDetected();
                }
            }

            //   animat.SetBool("isAnimated", true);
        }
        else
        {
            counter = Random.Range(30, 35);
            //Debug.Log("Sleeping Again");
            isAwake = false;

            if(Awareness > 0 && Awareness <= Aware)
            {
                Awareness -= AwarenessHeal;
            }

            if(Awareness <= 0.1)
            {
                Awareness = 0;
                AwarenessBar.enabled = false;
                AwarenessBarBackground.enabled = false;
                BackgroundAware.enabled = false;
                Question.enabled = false;
            }
        }

    }

    /* private void Update()
    {
        float AwarenessRatio = Awareness / Aware;

        AwarenessBar.fillAmount = AwarenessRatio;

        CountUpdate();
    } */
}
