using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class RidePlatform : MonoBehaviour
{
    Rigidbody2D rb;

    public PlayerMovement playerMovement;

    [Header("Events")]
    [Space]

    public UnityEvent OnJumpEvent;





    private void Awake()
    {
        if (OnJumpEvent == null)
            OnJumpEvent = new UnityEvent();
    }

        void ConnectTo(Rigidbody2D character)
    {
        SliderJoint2D joint = GetComponent<SliderJoint2D>();
        joint.connectedBody = character;
    }

    void OnCollisionEnter2D(Collision2D player)
    {

        if (player.gameObject.tag == "Player")
        {
            //rb = player.gameObject.GetComponent<Rigidbody2D>();

            //rb.velocity = rb.velocity + gameObject.GetComponent<Rigidbody2D>().velocity;

            //if (playerMovement.jump)
            //{
            //    OnJumpEvent.Invoke();
            //}

            ////rb.AddForce(gameObject.GetComponent<Rigidbody2D>().velocity);
            //rb.AddForce(transform.position);

            ////player.transform.parent = gameObject.transform;
            /// 

            //ConnectTo(player.collider.GetComponent<Rigidbody2D>());
            //if (player.gameObject.tag == "Player")
            //{
            //    player.transform.parent.parent = gameObject.transform;
            //}

        }
    }

    void OnCollisonExit2D(Collision2D player)
    {
        //if (player.gameObject.tag == "Player")
        //{
        //    player.transform.parent = null;
        //}
    }

    //public void OnJumping ()
    //{
    //    animator.SetBool("IsJumping", false);
    //}
}
