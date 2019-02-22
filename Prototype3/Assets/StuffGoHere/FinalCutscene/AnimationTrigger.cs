using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public Animator[] animations;
    public Animator[] animations2;
    public Animator[] animations3;

    public int timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Animator animationThing in animations)
        {
            animationThing.SetBool("StartAnim", true);
        }

        if (timer > 50)
        {
            foreach (Animator animationThing in animations2)
            {
                animationThing.SetBool("StartAnim", true);
            }
        }

        if (timer > 100)
        {
            foreach (Animator animationThing in animations3)
            {
                animationThing.SetBool("StartAnim", true);
            }
        }

        if (timer < 120)
        {
            timer++;
        }

    }
}
