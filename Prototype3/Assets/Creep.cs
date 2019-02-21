using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : MonoBehaviour
{

    public float creepSpeed = 0.05f;
    public float creepIncrease = 0.05f;
    public float creepCap = 20.0f;

    public Transform particles;
    public Transform player;

    public SquishPlayer squishPlayer;

    public Transform playerParticles;

    bool playerDrives = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (creepSpeed < creepCap)
        {
            creepSpeed += creepIncrease;
        }

        //Vector3 special = particles.position;
        //special.x = particles.position.x;

        //special.x += creepSpeed;

        //particles.position = special;

        if (player.position.x < particles.position.x && player.gameObject.activeSelf)
        {
            //Object.Destroy(playerSoul.gameObject);
            squishPlayer.playerDie = true;
            //playerSoul.GetChild(0).DetachChildren;

            playerParticles = player.GetChild(0).GetChild(0);
            //Vector3 theScale = particles.localScale;
            //theScale = new Vector3(1,1,1);
            playerParticles.localScale = new Vector3(1, 1, 1);
            playerParticles.gameObject.SetActive(true);



            playerParticles.parent = null;



            player.gameObject.SetActive(false);
        }


        if (playerParticles != null)
        {
            playerParticles.localScale = new Vector3(1, 1, 1);
        }

        if (Vector3.Distance(player.position, particles.position) > 21)
        {
            //Vector3 special = particles.position;
            //special.x = particles.position.x;

            //special.x += 40;

            Vector3 special = new Vector3 (player.position.x, particles.position.y, particles.position.z);
            special.x -= 20;

            particles.position = special;

        }

        if (Vector3.Distance(player.position, particles.position) <= 30)
        {
            Vector3 special = particles.position;
            special.x = particles.position.x;

            special.x += creepSpeed;

            particles.position = special;

        }

        //if (Vector3.Distance(player.position, particles.position) > 50)
        //{
        //    Destroy(gameObject);
        //}

    }
}
