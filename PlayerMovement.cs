using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float speed = 2;
    float life = 1500;
    float currentLife = 1500;
    private float damage = 1.5f;
    private float heal = 1.5f;

    private GameObject Player;
    public GameObject myLight;
    private bool isDamaging = false;

    public Image Background;
    public Image CurrentLightBar;

    public ParticleSystem Leafs;
    
    public Joystick joystick;

    public static bool abducted;

    void Start()
    {
        myLight.GetComponent<SpriteRenderer>().enabled = false;
        myLight.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    void Update()
    {

        Player = GameObject.Find("Player");

        float ratio = life / currentLife;

        CurrentLightBar.fillAmount = ratio;
        
        if(isDamaging)
        {
            life -= damage;
            if (life <= 0)
            {
                life = 0;
                myLight.GetComponent<SpriteRenderer>().enabled = false;
                myLight.GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }

        if(life < currentLife && !isDamaging)
        {
            life += heal;
            if(life >= currentLife)
            {
                life = currentLife;
            }
        }

#if !UNITY_ANDROID && !UNITY_IPHONE
        if (Input.GetKey(KeyCode.Space) == true && Player.tag == "Player")
        {
            Light();
        }

        else
        {
            HealLight();
        }
#endif

        if (Player.tag == "Player")
            {
                float posX = (transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed);

                transform.position = new Vector3(Mathf.Clamp(posX, -8f, 8f), 3.7f, 0);

                float posXTouch = (transform.position.x + joystick.Horizontal * Time.deltaTime * speed);

                transform.position = new Vector3(Mathf.Clamp(posXTouch, -8f, 8f), 3.7f, 0);
        }
 
    }

    public void Light()
    {
        myLight.GetComponent<SpriteRenderer>().enabled = true;
        myLight.GetComponent<CapsuleCollider2D>().enabled = true;
        Leafs.Play();
        isDamaging = true;
    }

    public void HealLight()
    {
        myLight.GetComponent<SpriteRenderer>().enabled = false;
        myLight.GetComponent<CapsuleCollider2D>().enabled = false;
        Leafs.Stop();
        isDamaging = false;
    }

    public void Abduction()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}
