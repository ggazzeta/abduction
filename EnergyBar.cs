using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{

    public Image AwarenessBar;
    Color WaterGreen;

    // Use this for initialization
    void Start()
    {

        WaterGreen = new Color(0.2f, 1, 0.6f, 1);
        AwarenessBar.color = WaterGreen;
    }

    // Update is called once per frame
    void Update()
    {
        if(AwarenessBar.fillAmount > 0.75)
        {
            AwarenessBar.color = WaterGreen;
        }
        
        if (AwarenessBar.fillAmount <= 0.75 && AwarenessBar.fillAmount > 0.5)
        {
            AwarenessBar.color = new Color(1.0f, 0.57f, 0.0f); //yellow
        }

        else if (AwarenessBar.fillAmount <= 0.5 && AwarenessBar.fillAmount > 0.35)
        {
            AwarenessBar.color = new Color(1.0f, 0.4002928f, 0.0f); //orange
        }

        else if (AwarenessBar.fillAmount <= 0.35 && AwarenessBar.fillAmount > 0.25)
        {
            AwarenessBar.color = new Color(1.0f, 0.1893373f, 0.0f); //redOrange
        }

        else if (AwarenessBar.fillAmount >= 0 && AwarenessBar.fillAmount <= 0.25)
        {
            AwarenessBar.color = Color.red;
        }
    }
}