using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateEternal : MonoBehaviour
{
    public RespawnCheckpoint checkout;

    public LerpAlpha lerpAlpha;

    public GameObject lerpGO;

    public int level = 1;

    void Awake()
    {
        checkout = GameObject.FindWithTag("Singleton").gameObject.GetComponent<RespawnCheckpoint>();

    }

    // Start is called before the first frame update
    void Start()
    {
        if (RespawnCheckpoint.fadeIn)
        {
            lerpGO.SetActive(true);
            lerpAlpha.enabled = true;
            RespawnCheckpoint.fadeIn = false;
        }
        else
        {
            lerpGO.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
