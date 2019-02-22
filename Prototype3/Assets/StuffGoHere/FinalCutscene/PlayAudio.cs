using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class PlayAudio : MonoBehaviour
{

    public AudioSource audioSource;

    public int counter = 0;

    public SpriteRenderer shadow;

    public Animator animationize;

    public GameObject car;

    public GameObject yesWorld;

    public TextMeshProUGUI theEnd;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
        shadow.enabled = true;
        theEnd.faceColor = new Color32(255, 255, 255, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counter > 61)
        {
            shadow.sortingOrder = 1;
        }

        if (counter > 135)
        {
            shadow.sortingOrder = 251;
        }

        if (counter > 195)
        {
            shadow.sortingOrder = 502;
        }

        if (counter > 290)
        {
            yesWorld.SetActive(true);
            //shadow.enabled = false;
        }

        if (counter > 780 && animationize != null)
        {
            animationize.SetBool("StartAnim", true);
        }

        if (counter > 1200)
        {
            car.SetActive(false);

            Color32 thisOne = theEnd.faceColor;


            if (thisOne.a < 255)
            {
                thisOne.a += 1;
            }

            theEnd.faceColor = thisOne;


        }



        if (counter < 10000)
        {
            counter++;
        }
        
    }
}
