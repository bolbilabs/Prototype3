using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{


    public Transform player;

    public float keyLoomDistance = 1.0f;

    public float followSpeed = 0.5f;


    public Transform thisObject;

    void Update()
    {

            if (Vector3.Distance(thisObject.transform.position, player.position) > keyLoomDistance)
            {
                thisObject.transform.position = Vector3.Lerp(thisObject.transform.position, player.position, followSpeed);
            }
     
     }


}
