using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform groundDet, upperdet;
    public LayerMask whatisground;
    [SerializeField]bool movingRight = true, isground = false, isupper = false,turn=false;
    int x=1,heal=6;
    public Animator jump;
   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
   
        InvokeRepeating("addingforce", 2, 2);
    }
    private void Update()
    {
        isground = Physics2D.OverlapCircle(groundDet.position, 0.1f, whatisground);
        isupper = Physics2D.OverlapCircle(upperdet.position, 0.1f, whatisground);
        if ((!isground || isupper) && rb.velocity== Vector2.zero)
        {
            if (movingRight == true )
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                x = -1;
                movingRight = false;turn = false;
            }
            else if(movingRight == false )
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                movingRight = true; turn = false;
                x = +1;
            }
        }
        if (isground) { jump.SetBool("frogjumping", false); }
        if (!isground) { jump.SetBool("frogjumping", true); }
        if (heal == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            jump.SetBool("hit", true);
            Invoke("cancel", 0.2f);
            heal--;
        }
    }
    void addingforce()
    {
        
        Debug.Log("jump");
         rb.velocity = new Vector3(x, 5, 0f);

    }
    void cancel()
    {
        jump.SetBool("hit", false);
    }

}
