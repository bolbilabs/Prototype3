using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public DialogueTrigger trigger;

    bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered)
        {
            trigger.TriggerDialogue();
            Destroy(gameObject);
            triggered = true;
        }
    }
}
