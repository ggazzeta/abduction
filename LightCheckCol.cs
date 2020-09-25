using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCheckCol : MonoBehaviour {

    public int HowManyCows = 0;
    public float additionalSpeed;

    void Update()
    {
        if(HowManyCows > 2 && HowManyCows < 5)
        {
            additionalSpeed = .5f;
        }

        else if(HowManyCows > 5)
        {
            additionalSpeed = 1f;
        }

        else if(HowManyCows <= 2)
        {
            additionalSpeed = 0;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyCollisor")
        {
            FindObjectOfType<GameManager>().EndGameDetected();
        }

        if (collision.gameObject.tag == "Cows")
        {
            HowManyCows++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cows")
        {
            HowManyCows--;
        }
    }
}
