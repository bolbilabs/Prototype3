using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlockPush : MonoBehaviour
{
    public Transform block;
    Rigidbody2D rb;

    public Animator animator;

    private DialogueManager dialogueManager;

    float horizontalMove = 0f;
    float verticalMove = 0f;

    public float blockSpeed = 1f;

    //public float refreshRate = 1f;

    //public float maxRefresh = 10;

    //public float refresh = 0f;

    bool isMoving = false;

    [Tooltip("Up, Down, Left, Right")]
    public int moveState = -1;

    enum Movement { Up, Down, Left, Right }

    int horizontal = 0;
    int vertical = 0;

    Vector2 lastPosition;

    GameObject oldPosition;

    bool firstFrame = false;

    Transform player;

    public float bigDistance = 10.0f;


    void Awake()
    {
        player = GameObject.FindWithTag("Player").gameObject.GetComponent<Transform>();
    }



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;


        dialogueManager = GameObject.FindWithTag("DialogueManager").gameObject.GetComponent<DialogueManager>();


        //lastPosition = rb.position;

        //oldPosition.transform.position = 

        if (moveState == (int)Movement.Down)
        {
            moveState = (int)Movement.Down;
            rb.velocity = Vector3.down * blockSpeed;
            //rb.MovePosition(rb.position + Vector2.down * Time.deltaTime * blockSpeed);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

            vertical = 1;
            horizontal = 0;
            //refresh = 0;
            isMoving = true;
            firstFrame = false;
        }
        else if (moveState == (int)Movement.Up)
        {
            moveState = (int)Movement.Up;
            rb.velocity = Vector3.up * blockSpeed;
            //rb.MovePosition(rb.position + Vector2.up * Time.deltaTime * blockSpeed);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

            vertical = -1;
            horizontal = 0;
            //refresh = 0;

            isMoving = true;
            firstFrame = false;
        }
        else if (moveState == (int)Movement.Right)
        {
            moveState = (int)Movement.Right;
            rb.velocity = Vector3.right * blockSpeed;
            //rb.MovePosition(rb.position + Vector2.right * Time.deltaTime * blockSpeed);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;

            horizontal = 1;
            vertical = 0;
            //refresh = 0;

            isMoving = true;
            firstFrame = false;
        }
        else if (moveState == (int)Movement.Left)
        {
            moveState = (int)Movement.Left;
            rb.velocity = Vector3.left * blockSpeed;
            //rb.MovePosition(rb.position + Vector2.left * Time.deltaTime * blockSpeed);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;


            horizontal = -1;
            vertical = 0;
            //refresh = 0;

            isMoving = true;
            firstFrame = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving && !dialogueManager.inCutscene)
        {
                horizontalMove = Input.GetAxisRaw("KeyHorizontal");
                verticalMove = Input.GetAxisRaw("KeyVertical");
            if (verticalMove > 0)
            {
                moveState = (int)Movement.Down;
                rb.velocity = Vector3.down * blockSpeed;
                //rb.MovePosition(rb.position + Vector2.down * Time.deltaTime * blockSpeed);
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

                vertical = 1;
                horizontal = 0;
                //refresh = 0;
                isMoving = true;
                firstFrame = false;
            }
            else if (verticalMove < 0)
            {
                moveState = (int)Movement.Up;
                rb.velocity = Vector3.up * blockSpeed;
                //rb.MovePosition(rb.position + Vector2.up * Time.deltaTime * blockSpeed);
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

                vertical = -1;
                horizontal = 0;
                //refresh = 0;

                isMoving = true;
                firstFrame = false;
            }
            else if (horizontalMove > 0)
            {
                moveState = (int)Movement.Right;
                rb.velocity = Vector3.right * blockSpeed;
                //rb.MovePosition(rb.position + Vector2.right * Time.deltaTime * blockSpeed);
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;

                horizontal = 1;
                vertical = 0;
                //refresh = 0;

                isMoving = true;
                firstFrame = false;
            }
            else if (horizontalMove < 0)
            {
                moveState = (int)Movement.Left;
                rb.velocity = Vector3.left * blockSpeed;
                //rb.MovePosition(rb.position + Vector2.left * Time.deltaTime * blockSpeed);
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;


                horizontal = -1;
                vertical = 0;
                //refresh = 0;

                isMoving = true;
                firstFrame = false;

            }
        }


        animator.SetBool("IsMoving", isMoving);



    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            //rb.AddForce(new Vector3(0.0f, -2.0f, 0.0f) * blockSpeed);
            //if (isMoving)
            //{
            //transform.Translate(Vector3.right * Time.deltaTime * horizontal * blockSpeed, Space.World);
            //if (isMoving)
            //{


            //rb.MovePosition(rb.position + Vector2.down * Time.deltaTime * vertical * blockSpeed);
            //Debug.Log("Speed:" + Time.deltaTime * vertical * blockSpeed);

            //rb.MovePosition(rb.position + Vector2.right * Time.deltaTime * horizontal * blockSpeed);

            //Debug.Log("currentPositision:" + block.position);



            //Debug.Log("Distance:" + Vector2.Distance(lastPosition, rb.position));
            //Debug.Log("blockSpeed:" + blockSpeed * Time.deltaTime / 2);

            float distance = Vector2.Distance(block.position, lastPosition);
            //Debug.Log("Distance:" + distance);





            if (Vector2.Distance(lastPosition, block.position) < blockSpeed * Time.deltaTime / 2 && firstFrame)
            {
                isMoving = false;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                Vector2 currentPos = rb.gameObject.transform.position;

                currentPos.x = (float) ((Mathf.Sign(currentPos.x) * (Mathf.Ceil(Mathf.Abs(currentPos.x)) - 0.5f)));
                currentPos.y = (float)((Mathf.Sign(currentPos.y) * (Mathf.Ceil(Mathf.Abs(currentPos.y)) - 0.5f)));

                rb.gameObject.transform.position = currentPos;

            }

            //Debug.Log("lastlastPosition:" + lastPosition);
            lastPosition = block.position;
            firstFrame = true;
            //Debug.Log("lastPosition:" + lastPosition);
            //}
        }



        //transform.Translate(Vector3.down * Time.deltaTime * vertical * blockSpeed, Space.World);
        //rb.velocity.y += blockSpeed * Time.deltaTime;
        //rb.velocity = Vector3.right * horizontal * blockSpeed;
        //rb.velocity = Vector3.down * vertical * blockSpeed;


        //}

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Platform")
        //{
        //    isMoving = false;
        ////    Debug.Log("Test");

        ////    horizontal = 0;
        ////    vertical = 0;
        //}
    }
}
