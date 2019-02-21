using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class RespawnCheckpoint : MonoBehaviour
{
    float restart;
    public static Vector3 cameraPosition;

    public static RespawnCheckpoint instance;

    public Camera cam;

    public Transform checkpoint;
    static public Vector3 checkLocation;

    public Transform player;

    public static bool firstDone = false;
    public bool debug = false;

    public GameObject shadow;

    public MonoBehaviour squish;

    public GameObject playerGO;
    public GameObject dummyGO;

    bool once = false;

    public static int level = 0;

    public bool transitionBool = false;
    public static bool grandBool = false;
    public bool elTigreBool = false;

    public SpriteRenderer rend1;

    public MonoBehaviour lerpScript;

    public string currentScene;

    public string forceScene;

    int sortOrder;

    int counter = 0;


    public static bool fadeIn = false;



    public DialogueTrigger trigger;
    //public DialogueManager manager;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        Camera.main.transform.position = cameraPosition;
        player = GameObject.FindWithTag("Player").transform;
        if (!checkLocation.Equals(new Vector3(0,0,0)))
        {
            player.position = checkLocation;
        }

        Debug.Log(player);

        sortOrder = rend1.sortingOrder;

        currentScene = "SampleScene";

        if (forceScene != null)
        {
            currentScene = forceScene;
        }

        counter = 0;

    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    


        if (firstDone || debug)
        {
            restart = Input.GetAxisRaw("Respawn");

            if (restart > 0)
            {
                cameraPosition = Camera.main.transform.position;
                if (checkpoint != null)
                {
                    checkLocation = checkpoint.position;
                }
                SceneManager.LoadScene(currentScene);
            }
        }

        if (!firstDone && !debug)
        {



            shadow.SetActive(true);
            squish.enabled = false;


            if (!once)
            {
                dummyGO.SetActive(true);
                playerGO.SetActive(false);
            }

            if (Input.GetKeyDown("w") && !once)
            {
                dummyGO.SetActive(false);
                playerGO.SetActive(true);
                once = true;


                firstDone = true;
                squish.enabled = true;
                //shadow.SetActive(false);
                FindObjectOfType<DialogueManager>().EndDialogue();
            }


            if (counter > 200 && !FindObjectOfType<DialogueManager>().inCutscene && !firstDone)
            {
                trigger.TriggerDialogue();
            }

            counter++;


        }

        if (rend1 != null)
        {
            if (rend1.sortingOrder > 1500)
            {
                rend1.sortingOrder -= 25;
            }
            else
            {
                lerpScript.enabled = true;
            }
        }

        if (shadow == null)
        {
            firstDone = true;
        }

    }



    public static int getLevel()
    {
        return level;
    }

    public static void setLevel(int num)
    {
        level = num;
    }

}
