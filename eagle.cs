using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagle : MonoBehaviour
{
    Rigidbody2D eaglerigid;
    bool destroyck = false;

    
    void Start()
    {   
        eaglerigid = GetComponent<Rigidbody2D>();
        eaglerigid.velocity = new Vector2(-7, 0);
    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "check")
        {
            a();
        }
        if (obj.gameObject.tag == "Player")
        {
            eaglerigid.gravityScale = 1;
          
            Invoke("a", 1);
        }
        void a()
        {
            Destroy(gameObject);
        }
    }
}
