using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LerpAlpha : MonoBehaviour
{

    public SpriteRenderer currentRender;
    public Tilemap tilemap;

    public Color changeColor;

    private Color currentColor;

    public float adjustSpeed = 0.5f;

    public bool fadeIn = false;

    // Start is called before the first frame update
    void Start()
    {
        if (currentRender != null)
        {
            currentColor = currentRender.color;
        }


        if (tilemap != null)
        {
            currentColor = tilemap.color;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentRender != null)
        {
            if (!fadeIn)
            {
                currentColor.a = Mathf.Lerp(currentColor.a, changeColor.a, adjustSpeed);


                currentColor.r = Mathf.Lerp(currentColor.r, changeColor.r, adjustSpeed);
                currentColor.g = Mathf.Lerp(currentColor.g, changeColor.g, adjustSpeed);
                currentColor.b = Mathf.Lerp(currentColor.b, changeColor.b, adjustSpeed);

            }
            else
            {
                currentColor.a = Mathf.Lerp(changeColor.a, currentColor.a, adjustSpeed);

                currentColor.r = Mathf.Lerp(changeColor.r, currentColor.r, adjustSpeed);
                currentColor.g = Mathf.Lerp(changeColor.g, currentColor.g, adjustSpeed);
                currentColor.b = Mathf.Lerp(changeColor.b, currentColor.b, adjustSpeed);

            }

            currentRender.color = currentColor;
        }

        if (tilemap != null)
        {
            if (!fadeIn)
            {
                currentColor.a = Mathf.Lerp(currentColor.a, changeColor.a, adjustSpeed);
            }
            else
            {
                currentColor.a = Mathf.Lerp(changeColor.a, currentColor.a, adjustSpeed);
            }
            
            tilemap.color = currentColor;
        }

    }
}
