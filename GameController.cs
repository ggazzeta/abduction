using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject MenuDica;
    public GameObject myCow;
    public GameObject myButton;

    bool isTime;
    bool abductingIdle;
    bool Skipped;

    public Image myTimer;
    public Image HighlightPanel;

    float tipCounter = 0;
    float tipIncreaser = 0.02f;
    float tipTimer = 1f;
    float TipDamage = 0.0012f;

    // Start is called before the first frame update
    void Start()
    {
        myButton.SetActive(false);
        myButton.GetComponent<CanvasGroup>().alpha = 0;
        Skipped = false;
        isTime = false;
        MenuDica.GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(myCow != null)
        {
            HighlightPanel.transform.position = myCow.transform.position;
        }

        if(isTime)
        {
            tipCounter += tipIncreaser;
            myButton.SetActive(true);
            MenuDica.GetComponent<CanvasGroup>().alpha = tipCounter;
            myButton.GetComponent<CanvasGroup>().alpha = tipCounter;
            if (tipCounter >= 1)
            {
                tipCounter = 1;
                GameManager.SlowMo = true;
                tipTimer -= TipDamage;
                myTimer.fillAmount = tipTimer;
                if(tipTimer <= 0 || Skipped)
                {
                    tipTimer = 0;
                    MenuDica.GetComponent<CanvasGroup>().alpha = 0;
                    myButton.GetComponent<CanvasGroup>().alpha = 0;
                    myButton.SetActive(false);
                    GameManager.SlowMo = false;
                    isTime = false;
                }
            }
        }
    }

    public void SkipTip()
    {
        Skipped = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cows")
        {
            isTime = true;
        }
    }

}
