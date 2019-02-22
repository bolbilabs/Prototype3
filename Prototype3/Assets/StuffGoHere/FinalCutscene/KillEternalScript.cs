using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEternalScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("Singleton").gameObject.GetComponent<RespawnCheckpoint>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
