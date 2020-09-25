using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AwareBar : MonoBehaviour {

    public Image AwarenessBar;

	// Use this for initialization
	void Start () {

        AwarenessBar.color = Color.yellow;
    }
	
	// Update is called once per frame
	void Update () {

		if(AwarenessBar.fillAmount <= 0.35)
        {
            AwarenessBar.color = new Color(1.0f, 0.57f, 0.0f); //yellow
        }

        else if (AwarenessBar.fillAmount <= 0.60 && AwarenessBar.fillAmount > 0.35)
        {
            AwarenessBar.color = new Color(1.0f, 0.4002928f, 0.0f); //orange
        }

        else if (AwarenessBar.fillAmount <= 0.85 && AwarenessBar.fillAmount > 0.60)
        {
            AwarenessBar.color = new Color(1.0f, 0.1893373f, 0.0f); //redOrange
        }

        else if (AwarenessBar.fillAmount <= 1 && AwarenessBar.fillAmount > 0.85)
        {
            AwarenessBar.color = Color.red;
        }
    }
}
