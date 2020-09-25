using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPresentation : MonoBehaviour
{
    public CanvasGroup myCanvas;
    float canvasFade = 0f;
    float canvasFadeOut = 1f;
    float canvasHit = 0.85f;
    float myTimer = 0.3f;
    float waitForSeconds = 2;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        myTimer -= Time.deltaTime;

        if (myTimer <= 0)
        {
            myTimer = 0;
            canvasFade += canvasHit * Time.deltaTime;
            myCanvas.alpha = canvasFade;
            if (canvasFade >= 1)
            {
                myCanvas.alpha = canvasFadeOut;
                canvasFade = 1;
                waitForSeconds -= Time.deltaTime;

                if (waitForSeconds <= 0)
                {
                    waitForSeconds = 0;
                    canvasFadeOut -= canvasHit * Time.deltaTime;
                    if(canvasFadeOut <= 0)
                    {
                        canvasFadeOut = 0;
                    }
                }
            }

        }

    }

}
