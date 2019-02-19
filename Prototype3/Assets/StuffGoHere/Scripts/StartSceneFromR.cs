using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class StartSceneFromR : MonoBehaviour
{

    float restart = 0.0f;

    int waitTime = 0;
    public int maxWaitTime = 1000;

    public int maxWaitTime2 = 2000;

    public GameObject destroyPlatform;
    public DialogueManager dialogue;

    public MonoBehaviour script;

    // Update is called once per frame
    void FixedUpdate()
    {
        restart = Input.GetAxisRaw("Respawn");

        if (restart > 0 && waitTime == 0)
        {
            //SceneManager.LoadScene("SampleScene");

            destroyPlatform.SetActive(false);
            dialogue.EndDialogue();


            waitTime++;

        }

        if (waitTime > 0)
        {
            waitTime++;

            if (waitTime > maxWaitTime && !script.enabled)
            {
                script.enabled = true;
            }

            if (waitTime > maxWaitTime2)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
