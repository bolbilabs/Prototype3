using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayer : MonoBehaviour
{
    public CharacterController2D flipScript;

    // Start is called before the first frame update
    void Start()
    {
        flipScript.Flip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
