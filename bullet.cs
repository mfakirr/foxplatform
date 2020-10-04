using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    Animator a;
    void Start()
    {
        a = GetComponent<Animator>();
        rb.velocity = transform.right *speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!(collision.gameObject.tag == "player"))
        {
            Invoke("hit", 0.2f);
            a.SetBool("touch", true);
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    private void hit()
    {
        
        Destroy(gameObject);
    }
}
