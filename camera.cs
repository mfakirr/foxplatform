using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform playerposition;
    void Update()
    {
        if (playerposition.position != transform.position)
        {
            transform.position = new Vector3(playerposition.position.x, playerposition.position.y, transform.position.z);
        }
        
    }
}
