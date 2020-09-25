using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text myTimer;
    public Text myBestScore;
    public int chooseLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score()
    {
        switch(chooseLevel)
        {
            case 1:
                myTimer.text = "CURRENT: " + GameObject.FindWithTag("Player").GetComponent<Timer>().Min + ":" + GameObject.FindWithTag("Player").GetComponent<Timer>().Sec;
                myBestScore.text = "YOUR BEST: " + PlayerPrefs.GetFloat("BestScoreMin_Level1") + ":" + PlayerPrefs.GetFloat("BestScoreSec_Level1");

                if (GameObject.FindWithTag("Player").GetComponent<Timer>().Min < PlayerPrefs.GetFloat("BestScoreMin_Level1", 1000))
                {
                    myTimer.color = Color.green;
                    PlayerPrefs.SetFloat("BestScoreMin_Level1", GameObject.FindWithTag("Player").GetComponent<Timer>().Min);
                    PlayerPrefs.SetFloat("BestScoreSec_Level1", GameObject.FindWithTag("Player").GetComponent<Timer>().Sec);
                }

                else if (GameObject.FindWithTag("Player").GetComponent<Timer>().Min == PlayerPrefs.GetFloat("BestScoreMin_Level1", 1000))
                {
                    if (GameObject.FindWithTag("Player").GetComponent<Timer>().Sec < PlayerPrefs.GetFloat("BestScoreSec_Level1", 1000))
                    {
                        myTimer.color = Color.green;
                        PlayerPrefs.SetFloat("BestScoreMin_Level1", GameObject.FindWithTag("Player").GetComponent<Timer>().Min);
                        PlayerPrefs.SetFloat("BestScoreSec_Level1", GameObject.FindWithTag("Player").GetComponent<Timer>().Sec);
                    }

                    else if (GameObject.FindWithTag("Player").GetComponent<Timer>().Sec > PlayerPrefs.GetFloat("BestScoreSec_Level1", 1000))
                    {
                        myTimer.color = Color.red;
                    }
                }

                else if (GameObject.FindWithTag("Player").GetComponent<Timer>().Min > PlayerPrefs.GetFloat("BestScoreMin_Level1", 1000))
                {
                    myTimer.color = Color.red;
                }

                break;

            case 2:
                myTimer.text = "CURRENT: " + GameObject.FindWithTag("Player").GetComponent<Timer>().Min + ":" + GameObject.FindWithTag("Player").GetComponent<Timer>().Sec;
                myBestScore.text = "YOUR BEST: " + "0" + PlayerPrefs.GetFloat("BestScoreMin_Level2") + ":" + PlayerPrefs.GetFloat("BestScoreSec_Level2");

                if (GameObject.FindWithTag("Player").GetComponent<Timer>().Min < PlayerPrefs.GetFloat("BestScoreMin_Level2", 1000))
                {
                    myTimer.color = Color.green;
                    PlayerPrefs.SetFloat("BestScoreMin_Level2", GameObject.FindWithTag("Player").GetComponent<Timer>().Min);
                    PlayerPrefs.SetFloat("BestScoreSec_Level2", GameObject.FindWithTag("Player").GetComponent<Timer>().Sec);
                }

                else if (GameObject.FindWithTag("Player").GetComponent<Timer>().Min == PlayerPrefs.GetFloat("BestScoreMin_Level2", 1000))
                {
                    if (GameObject.FindWithTag("Player").GetComponent<Timer>().Sec < PlayerPrefs.GetFloat("BestScoreSec_Level2", 1000))
                    {
                        myTimer.color = Color.green;
                        PlayerPrefs.SetFloat("BestScoreMin_Level2", GameObject.FindWithTag("Player").GetComponent<Timer>().Min);
                        PlayerPrefs.SetFloat("BestScoreSec_Level2", GameObject.FindWithTag("Player").GetComponent<Timer>().Sec);
                    }

                    else if (GameObject.FindWithTag("Player").GetComponent<Timer>().Sec > PlayerPrefs.GetFloat("BestScoreSec_Level2", 1000))
                    {
                        myTimer.color = Color.red;
                    }
                }

                else if (GameObject.FindWithTag("Player").GetComponent<Timer>().Min > PlayerPrefs.GetFloat("BestScoreMin_Level2", 1000))
                {
                    myTimer.color = Color.red;
                }

                break;

            case 3:
                myTimer.text = "CURRENT: " + GameObject.FindWithTag("Player").GetComponent<Timer>().Min + ":" + GameObject.FindWithTag("Player").GetComponent<Timer>().Sec;
                myBestScore.text = "YOUR BEST: " + PlayerPrefs.GetFloat("BestScoreMin_Level3") + ":" + PlayerPrefs.GetFloat("BestScoreSec_Level3");

                if (GameObject.FindWithTag("Player").GetComponent<Timer>().Min < PlayerPrefs.GetFloat("BestScoreMin_Level3", 1000))
                {
                    myTimer.color = Color.green;
                    PlayerPrefs.SetFloat("BestScoreMin_Level3", GameObject.FindWithTag("Player").GetComponent<Timer>().Min);
                    PlayerPrefs.SetFloat("BestScoreSec_Level3", GameObject.FindWithTag("Player").GetComponent<Timer>().Sec);
                }

                else if (GameObject.FindWithTag("Player").GetComponent<Timer>().Min == PlayerPrefs.GetFloat("BestScoreMin_Level3", 1000))
                {
                    if (GameObject.FindWithTag("Player").GetComponent<Timer>().Sec < PlayerPrefs.GetFloat("BestScoreSec_Level3", 1000))
                    {
                        myTimer.color = Color.green;
                        PlayerPrefs.SetFloat("BestScoreMin_Level3", GameObject.FindWithTag("Player").GetComponent<Timer>().Min);
                        PlayerPrefs.SetFloat("BestScoreSec_Level3", GameObject.FindWithTag("Player").GetComponent<Timer>().Sec);
                    }

                    else if (GameObject.FindWithTag("Player").GetComponent<Timer>().Sec > PlayerPrefs.GetFloat("BestScoreSec_Level3", 1000))
                    {
                        myTimer.color = Color.red;
                    }
                }

                else if (GameObject.FindWithTag("Player").GetComponent<Timer>().Min > PlayerPrefs.GetFloat("BestScoreMin_Level3", 1000))
                {
                    myTimer.color = Color.red;
                }

                break;

            case 4:
                myTimer.text = "CURRENT: " + GameObject.FindWithTag("Player").GetComponent<Timer>().Min + ":" + GameObject.FindWithTag("Player").GetComponent<Timer>().Sec;
                myBestScore.text = "YOUR BEST: " + PlayerPrefs.GetFloat("BestScoreMin_Level4") + ":" + PlayerPrefs.GetFloat("BestScoreSec_Level4");

                if (GameObject.FindWithTag("Player").GetComponent<Timer>().Min < PlayerPrefs.GetFloat("BestScoreMin_Level4", 1000))
                {
                    myTimer.color = Color.green;
                    PlayerPrefs.SetFloat("BestScoreMin_Level4", GameObject.FindWithTag("Player").GetComponent<Timer>().Min);
                    PlayerPrefs.SetFloat("BestScoreSec_Level4", GameObject.FindWithTag("Player").GetComponent<Timer>().Sec);
                }

                else if (GameObject.FindWithTag("Player").GetComponent<Timer>().Min == PlayerPrefs.GetFloat("BestScoreMin_Level4", 1000))
                {
                    if (GameObject.FindWithTag("Player").GetComponent<Timer>().Sec < PlayerPrefs.GetFloat("BestScoreSec_Level4", 1000))
                    {
                        myTimer.color = Color.green;
                        PlayerPrefs.SetFloat("BestScoreMin_Level4", GameObject.FindWithTag("Player").GetComponent<Timer>().Min);
                        PlayerPrefs.SetFloat("BestScoreSec_Level4", GameObject.FindWithTag("Player").GetComponent<Timer>().Sec);
                    }

                    else if (GameObject.FindWithTag("Player").GetComponent<Timer>().Sec > PlayerPrefs.GetFloat("BestScoreSec_Level4", 1000))
                    {
                        myTimer.color = Color.red;
                    }
                }

                else if (GameObject.FindWithTag("Player").GetComponent<Timer>().Min > PlayerPrefs.GetFloat("BestScoreMin_Level4", 1000))
                {
                    myTimer.color = Color.red;
                }

                break;

            case 5:
                break;

            
        }



    }
}
