using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SquishPlayer : MonoBehaviour
{

    public Transform playerSoul;
    public Transform playerSoul2;

    public Transform player;


    public Transform head;
    public Transform tail;

    public bool playerDie = false;

    public float soulRadius = .2f;

    Transform particles;

    // Start is called before the first frame update
    void Start()
    {
        //Object.Destroy(playerSoul.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerDie)
        {
            //Collider2D[] colliders = Physics2D.OverlapCircleAll(playerSoul.position, soulRadius, 1 << 8);

            Collider2D[] colliders = Physics2D.OverlapAreaAll(head.position, tail.position, 1 << 8);



            //foreach (Collider2D element in colliders)
            //{
            //    Debug.Log(element.gameObject.ToString);
            //}

            //Debug.Log(colliders.Length);


            if (colliders.Length > 1)
            {
                //Object.Destroy(playerSoul.gameObject);
                playerDie = true;
                //playerSoul.GetChild(0).DetachChildren;

                particles = player.GetChild(0).GetChild(0);
                //Vector3 theScale = particles.localScale;
                //theScale = new Vector3(1,1,1);
                particles.localScale = new Vector3(1, 1, 1);
                particles.gameObject.SetActive(true);



                particles.parent = null;



                player.gameObject.SetActive(false);
            }
            Collider2D collider2 = Physics2D.OverlapArea(playerSoul.position, playerSoul2.position, 1 << 8);

            if (collider2 != null)
            {
                //Object.Destroy(playerSoul.gameObject);
                playerDie = true;
                //playerSoul.GetChild(0).DetachChildren;

                particles = player.GetChild(0).GetChild(0);
                //Vector3 theScale = particles.localScale;
                //theScale = new Vector3(1,1,1);
                particles.localScale = new Vector3(1, 1, 1);
                particles.gameObject.SetActive(true);



                particles.parent = null;



                player.gameObject.SetActive(false);
            }



            if (player.transform.position.y < -20.0f)
            {
                //Object.Destroy(playerSoul.gameObject);
                playerDie = true;
                //playerSoul.GetChild(0).DetachChildren;

                particles = player.GetChild(0).GetChild(0);
                //Vector3 theScale = particles.localScale;
                //theScale = new Vector3(1,1,1);
                particles.localScale = new Vector3(1, 1, 1);
                particles.gameObject.SetActive(true);



                particles.parent = null;



                player.gameObject.SetActive(false);
            }


        }

        if (particles != null)
        {
            particles.localScale = new Vector3(1, 1, 1);
        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            //Object.Destroy(playerSoul.gameObject);
            playerDie = true;
            //playerSoul.GetChild(0).DetachChildren;

            particles = player.GetChild(0).GetChild(0);
            //Vector3 theScale = particles.localScale;
            //theScale = new Vector3(1,1,1);
            particles.localScale = new Vector3(1, 1, 1);
            particles.gameObject.SetActive(true);



            particles.parent = null;



            player.gameObject.SetActive(false);
        }
        if (particles != null)
        {
            particles.localScale = new Vector3(1, 1, 1);
        }

    }




}
