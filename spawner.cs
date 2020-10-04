using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
     public Rigidbody2D eaglerigid;
    public Transform playerpos;
    public GameObject eagleob,eagleobleft;
    float x,y;
    public bool flipperleft=false,flipperright=false;
    void Start()
    {

       InvokeRepeating("createeagle",2f,2f);
       InvokeRepeating("createeagleleft", 0f, 2.5f);
       InvokeRepeating("direcly", 6f, 6f);

    }
    void createeagle()
    {
         x = Random.Range(0, 3.5f);
         GameObject neweagle = Instantiate(eagleob,new Vector2 (playerpos.position.x+13, playerpos.position.y + x), Quaternion.identity);
        

    }
    void createeagleleft()
    {
        y = Random.Range(0, 1);
        if (y < 0.5)
            y = +2;
        else
            y = -2;
        GameObject neweagle = Instantiate(eagleobleft, new Vector2(playerpos.position.x + -13, playerpos.position.y + x+y), Quaternion.identity);
       
    }
    void direcly()
    {
        if (y < 0.5)
        {
            GameObject neweagle = Instantiate(eagleob, new Vector2(playerpos.position.x + 13, playerpos.position.y ), Quaternion.identity);
        }
        else
        { GameObject neweagle = Instantiate(eagleobleft, new Vector2(playerpos.position.x + -13, playerpos.position.y ), Quaternion.identity); }
        
    }



}
