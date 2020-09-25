using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WarningMessage : MonoBehaviour
{
    public int whichLevel;

    public float panelOn;

    public TextMeshProUGUI title;
    public TextMeshProUGUI body;
    bool finishTutorial = false;
    public UnityEngine.UI.Button okButton;

    float buttonCharge = 0;
    float buttonLoadSpeed = .35f;

    // Start is called before the first frame update
    void Start()
    {
        chooseLevel();
        okButton.interactable = false; 
    }

    void chooseLevel()
    {
        switch (whichLevel)
        {
            case 3:
                panelOn = 1;
                title.text = "Oh no, it's raining!";
                body.text = "Whenever it's raining, the Abducting Light does not work properly. It will be harder to abduct the cows!";
                break;

            case 4:
                panelOn = 1;
                title.text = "Uh oh, a farmer!";
                body.text = "It seems that my recent abductions are making people aware. I can't let the farmer see me abducting when he's awake!";
                break;

            case 5:
                break;
        }
    }

    public void fadeOut()
    {
        finishTutorial = true;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = panelOn;

        buttonCharge += buttonLoadSpeed * Time.deltaTime;

        okButton.image.fillAmount = buttonCharge;

        if(buttonCharge >= 1)
        {
            buttonCharge = 1;
            okButton.interactable = true;
        }

        if (finishTutorial)
        {
            panelOn -= Time.deltaTime;
            if (panelOn <= 0)
            {
                panelOn = 0f;
                finishTutorial = false;
                gameObject.SetActive(false);
            }
        }
    }
}
