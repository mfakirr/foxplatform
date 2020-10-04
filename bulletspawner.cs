using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletspawner : MonoBehaviour
{
    public Transform gun;
    public GameObject bullet;
    public Animator f;
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            f.SetBool("shoot", true);
            Instantiate(bullet, gun.position, gun.rotation);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            f.SetBool("shoot", false);
           
        }
    }
}
