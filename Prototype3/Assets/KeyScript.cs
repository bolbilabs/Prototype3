using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    public bool collected = false;

    public Transform player;

    public float keyLoomDistance = 1.0f;

    public float followSpeed = 0.5f;

    public Transform door;

    public Sprite activate;
    public Color color;


    void Update()
    {
       if (collected && door == null)
        {
            if (Vector3.Distance(gameObject.transform.position, player.position) > keyLoomDistance)
            {
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, player.position, followSpeed);
            }
        }

       if (collected && door != null)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, door.position, 0.05f);
        }


       if (collected)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = activate;

            gameObject.GetComponent<SpriteRenderer>().color = color;
        }

     }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collected)
        {
            collected = true;
        }
    }
}
