using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour
{

    public MonoBehaviour script;

    // Start is called before the first frame update
    void Start()
    {
        script.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
