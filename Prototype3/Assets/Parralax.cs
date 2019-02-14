using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    public Transform player;

    public Renderer renderer;

    int flaviu = 0;

    public float scrollSpeed;
    private Vector2 savedOffset;

    public float flaviuX = 0.0f;

    public float flaviuY = 0.0f;

    public float tileSizeZ = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        //renderer = GetComponent<Renderer>();
        savedOffset = renderer.sharedMaterial.GetTextureOffset("_MainTex");

    }

    // Update is called once per frame
    void Update()
    {

        //texture.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(player.position.x / 4, player.position.y / 4));

        //texture.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(flaviu++, flaviu++));

        //float offset = Time.time * scrollSpeed;
        //texture.material.SetTextureOffset("_MainTex", new Vector2(flaviuX, flaviuY));

        float y = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        Vector2 offset = new Vector2(savedOffset.x, y);
        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
    void OnDisable()
    {
        renderer.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}



//using UnityEngine;
//using System.Collections;

//public class OffsetScroller : MonoBehaviour
//{

//    public float scrollSpeed;
//    private Vector2 savedOffset;

//    void Start()
//    {
//        savedOffset = renderer.sharedMaterial.GetTextureOffset("_MainTex");
//    }

//    void Update()
//    {
//        float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
//        Vector2 offset = new Vector2(savedOffset.x, y);
//        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
//    }

//    void OnDisable()
//    {
//        renderer.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
//    }
//}
