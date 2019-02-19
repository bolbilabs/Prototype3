using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<Sprite> images;

    public TextMeshProUGUI dialogueText;

    public Animator animator;

    public Animator playerAnimator;

    public Image image;

    public float timeDelay = 1.0f;

    private bool coroutineRunning = false;
    private string currentSentence;

    public PlayerMovement playerMovement;

    public bool inCutscene = false;

    private Rigidbody2D rb;

    public GameObject player;

    private MonoBehaviour[] scriptTriggers;


    // Start is called before the first frame update
    void Awake()
    {
        sentences = new Queue<string>();
        images = new Queue<Sprite>();
        scriptTriggers = new MonoBehaviour[0];

        rb = player.GetComponent<Rigidbody2D>();

    }


    void Start()
    {
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        inCutscene = true;

        playerMovement.horizontalMove = 0.0f;
        playerMovement.controller.Move(0, false, false);


        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

        //playerMovement.controller.enabled = false;

        playerMovement.enabled = false;
        playerAnimator.SetBool("IsJumping", false);
        playerAnimator.SetFloat("Speed", 0.0f);


        //Debug.Log("Starting conversation with " + dialogue.name);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }

        foreach (Sprite picture in dialogue.face)
        {
            images.Enqueue(picture);
        }

        scriptTriggers = dialogue.scriptTriggers;

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        if (!coroutineRunning)
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }


            if (images.Peek() != null)
            {
                image.sprite = images.Dequeue();
            }
            else
            {
                images.Dequeue();
            }

            string sentence = sentences.Dequeue();
            //Debug.Log(sentence);
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));


        }
        else
        {
            dialogueText.text = currentSentence;
            StopAllCoroutines();
            coroutineRunning = false;
        }




    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        currentSentence = sentence;
        coroutineRunning = true;
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(timeDelay);
        }
        coroutineRunning = false;
    }

    public void EndDialogue()
    {
        //Debug.Log("End of Conversation");
        animator.SetBool("IsOpen", false);
        playerMovement.enabled = true;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        inCutscene = false;


        if (scriptTriggers.Length > 0)
        {
            foreach (MonoBehaviour script in scriptTriggers)
            {
                script.enabled = true;
            }
        }

    }


    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("left shift"))
        {
            DisplayNextSentence();
        }
    }
}
