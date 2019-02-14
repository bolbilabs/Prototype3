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

    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        restart = Input.GetAxisRaw("Respawn");

        if (restart > 0)
        {
            cameraPosition = Camera.main.transform.position;
            if (checkpoint != null)
            {
                checkLocation = checkpoint.position;
            }
            SceneManager.LoadScene("SampleScene");
        }

    }
}
