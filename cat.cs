using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    public float speed,distance,z;
    bool movingRight = true,isground=false,isupper=false;
    public Transform groundDet,upperdet;
    public LayerMask whatisground;
    public Transform fox;
    Rigidbody2D rb;
    public Vector2 check;
    Animator an;
    [SerializeField]int heal=5;
    private void Start()
    {
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
        {
        z = transform.eulerAngles.z;
        isground = Physics2D.OverlapCircle(groundDet.position, 0.4f, whatisground);
        isupper = Physics2D.OverlapCircle(upperdet.position, 0.1f, whatisground);
        if (!isground || isupper || transform.eulerAngles.z < -5f || transform.eulerAngles.z > 5f)
        {
            Debug.Log("s");
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        distance = Vector2.Distance(transform.position, fox.position);
        if (distance > 3 || isupper)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (distance <= 3 && (isground || !isupper))
        {
            
            check = fox.position - transform.position;
            
            if (check.x > 0)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            if (check.x < 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            transform.position = Vector2.MoveTowards(transform.position, fox.position, 2 * Time.deltaTime);
        }
        if (heal == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            an.SetBool("hit", true);
            Invoke("cancel", 0.2f);
            heal--;
       }
    }

    void cancel()
    {
        an.SetBool("hit", false);
    }

}