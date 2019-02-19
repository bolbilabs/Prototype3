using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableScript : MonoBehaviour
{

    public GameObject gc;

    // Start is called before the first frame update
    void Start()
    {
        gc.SetActive(false);
    }

}
