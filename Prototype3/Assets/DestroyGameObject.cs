using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public GameObject destroyed; 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(destroyed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
