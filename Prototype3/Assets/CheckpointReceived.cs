using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointReceived : MonoBehaviour
{
    public RespawnCheckpoint checkout;

    //// Start is called before the first frame update
    void Start()
    {
        checkout = GameObject.FindWithTag("Singleton").gameObject.GetComponent<RespawnCheckpoint>();
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.transform.tag == "Player")
        {
            checkout.checkpoint = gameObject.transform;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
