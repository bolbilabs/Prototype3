using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{

    public bool unlocked = false;

    public GameObject key;

    public KeyScript keyScript;

    public LerpAlpha lerpAlpha;

    public LerpAlpha exitLerp;

    int transition = 0;

    public GameObject player;

    public string scene;

    public RespawnCheckpoint checkout;


    void Start()
    {
        checkout = GameObject.FindWithTag("Singleton").gameObject.GetComponent<RespawnCheckpoint>();
    }


    void Update()
    {
        if (unlocked)
        {
            lerpAlpha.enabled = true;
        }



    }

    void FixedUpdate()
    {
        if (transition > 0)
        {
            checkout.checkpoint = null;

            exitLerp.enabled = true;
            transition++;

        }
        //if (transition > 40)
        //{
        //    checkout.checkpoint = null;
        //}


        if (transition > 50)
        {
            checkout.currentScene = scene;
            checkout.checkpoint = null;
            checkout.transitionBool = false;
            checkout.checkpoint = null;
            RespawnCheckpoint.checkLocation = new Vector3(0, 0, 0);

            RespawnCheckpoint.fadeIn = true;
            SceneManager.LoadScene(scene);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && keyScript.collected)
        {
            //Destroy(key);
            //unlocked = true;
            keyScript.door = gameObject.transform;
        }

        if (collision.tag == "Key" && keyScript.door != null)
        {
            Destroy(key);
            unlocked = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && unlocked)
        {
            if (Input.GetKey("w") || Input.GetKey("space") || Input.GetKey("left shift"))
            {
                // This will need to be changed.
                //SceneManager.LoadScene("SampleScene");
                transition++;
                player.SetActive(false);
                checkout.checkpoint = null;


            }
        }
    }

}
