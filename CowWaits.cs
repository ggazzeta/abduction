using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowWaits : MonoBehaviour {

    private Animator animat;

    float counter;

    void Start()
    {
        counter = Random.Range(1, 6);
        animat = GetComponent<Animator> ();
    }

    void Update()
    {

        if (counter > 1 && counter <= 6)
        {
            counter -= Time.deltaTime;
            animat.SetBool("isAnimated", false);
        }
        else if(counter <= 1 && counter > 0)
        {
            counter -= Time.deltaTime;
            animat.SetBool("isAnimated", true);
        }
        else
        {
            animat.SetBool("isAnimated", false);
            counter = Random.Range(1, 6);
        }

    }
}
