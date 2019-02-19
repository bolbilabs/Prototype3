using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    public float horizontalMove = 0f;

    public int maxPowerTime = 20;
    int currentPower = 20;

    public bool jump = false;

    SpriteRenderer spriteRenderer;

    public Color colorChange;
    Color currentColor;

    public ParticleSystem emitter;


    //float blockHorizontal = 0f;
    //float blockVertical = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        currentColor = spriteRenderer.color;

    }

    void Awake()
    {
        emitter.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (currentPower < maxPowerTime)
        {
            currentPower++;
        }
        else
        {
            animator.SetBool("PSI", false);
            spriteRenderer.color = currentColor;
            //emitter.Pause();
            emitter.Stop();
        }


        if (Input.GetAxisRaw("KeyHorizontal") != 0.0f || Input.GetAxisRaw("KeyVertical") != 0.0f)
        {
            animator.SetBool("PSI", true);
            currentPower = 0;
            spriteRenderer.color = colorChange;
            //emitter.Emit(30);
            if (!emitter.isEmitting)
            {
                emitter.Play();
            }
        }
        

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding() {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
