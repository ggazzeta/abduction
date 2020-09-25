using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlGame : MonoBehaviour
{
    public GameObject MenuDica_2;
    public GameObject myButton2;

    bool abductingIdle;
    bool Skipped2;
    public Image myTimer2;

    float tipCounter_2 = 0;
    float tipIncreaser = 0.02f;

    float tipTimer2 = 1f;
    float TipDamage = 0.0012f;

    // Start is called before the first frame update
    void Start()
    {

        myButton2.SetActive(false);
        myButton2.GetComponent<CanvasGroup>().alpha = 0;
        Skipped2 = false;
        abductingIdle = false;
        MenuDica_2.GetComponent<CanvasGroup>().alpha = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if (abductingIdle)
        {
            tipCounter_2 += tipIncreaser;
            GameManager.SlowMo = true;
            myButton2.SetActive(true);
            MenuDica_2.GetComponent<CanvasGroup>().alpha = tipCounter_2;
            myButton2.GetComponent<CanvasGroup>().alpha = tipCounter_2;
            if (tipCounter_2 >= 1)
            {
                tipCounter_2 = 1;
                tipTimer2 -= TipDamage;
                myTimer2.fillAmount = tipTimer2;
                if (tipTimer2 <= 0 || Skipped2)
                {
                    tipTimer2 = 0;
                    MenuDica_2.GetComponent<CanvasGroup>().alpha = 0;
                    myButton2.GetComponent<CanvasGroup>().alpha = 0;
                    myButton2.SetActive(false);
                    GameManager.SlowMo = false;
                    abductingIdle = false;
                }
            }
        }

    }

    public void Skip2ndTip()
    {
        Skipped2 = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "IdleCow")
        {
            abductingIdle = true;
        }
    }
}
