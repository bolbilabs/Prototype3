using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDialogue : MonoBehaviour
{
    public DialogueTrigger trigger;


    // Start is called before the first frame update
    void Start()
    {
        trigger.TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
