using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

    float counter;
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject PopUpMenu;
    public GameObject myPrefab;
    private bool isInstantiated;
    public static int NumberOfCows;

    private void Start()
    {
        counter = 2;
    }

    private void FixedUpdate()
    {

        for (int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if(popUpIndex == 0) //Joystick
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.x < Screen.width / 2)
                {
                    counter -= Time.deltaTime;
                    if (counter <= 0)
                    {
                        counter = 7;
                        popUpIndex++;
                    }
                    
                }
                
            }
        }


        else if (popUpIndex == 1) //Abduction
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                counter = 7;
                popUpIndex++;
            }

         }

        else if (popUpIndex == 2) //LightWarning
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                counter = 2;
                popUpIndex++;
            }
        }

        else if (popUpIndex == 3) //CowSpawn
        {
            counter -= Time.deltaTime;
            if (isInstantiated == false)
            {
                Instantiate(myPrefab, new Vector3(5.54f, -2.278f, 0), Quaternion.Euler(0, 0, 0));
                isInstantiated = true;
            }
            else if (isInstantiated)
            {
                if (counter <= 0)
                {
                    popUpIndex++;
                }
            }

        }

        else if (popUpIndex == 4)
        {
            PopUpMenu.SetActive(false);
            GameObject[] CowCount = GameObject.FindGameObjectsWithTag("Cows");
            NumberOfCows = CowCount.Length;
            UpdateScore();
        }

    }

    void UpdateScore()
    {
        if (NumberOfCows <= 0)
        {
            NumberOfCows = 0;
            FindObjectOfType<GameManager>().EndTutorial();
        }
    }

}
