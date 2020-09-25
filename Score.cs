using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int scorePoints = 0;
    Text score;
    public static int NumberOfCows;

	// Use this for initialization
	void Start () {
        score = GetComponent<Text>();
	}

	
	// Update is called once per frame
	void Update () {
        GameObject[] CowCount = GameObject.FindGameObjectsWithTag("Cows");
        NumberOfCows = CowCount.Length;
        UpdateScore();
    }

    void UpdateScore()
    {
        score.text = "/" + NumberOfCows;
        if(NumberOfCows <= 0)
        {
            NumberOfCows = 0;
            FindObjectOfType<GameManager>().EndGameVaquinhas();
        }
    }
}
