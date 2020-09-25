using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float startTime;
    public float Min, Sec = 0;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        Min = float.Parse(minutes);
        Sec = float.Parse(seconds);

        if ((t / 60) <= 9 && (t % 60) <= 9)
        {
            timerText.text = "0" + minutes + ":" + "0" + seconds;
        }

        else if((t / 60) <= 9)
        {
            timerText.text = "0" + minutes + ":" + seconds;
        }

        else if((t % 60) <= 9)
        {
            timerText.text = minutes + ":" + "0" + seconds;
        }

        else
        {
            timerText.text = minutes + ":" + seconds;
        }
	}
}
