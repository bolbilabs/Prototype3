using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBlocks : MonoBehaviour
{
    public GameObject[] blocks;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        int selected = Mathf.FloorToInt(Random.value * blocks.Length * 0.999f);

        if (blocks[selected] != null)
        {
            Destroy(blocks[selected]);
        }
        
    }
}
