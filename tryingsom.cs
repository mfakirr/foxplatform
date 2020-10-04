using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tryingsom : MonoBehaviour
{
    public float distance;
    public Transform fox;
    Rigidbody2D rb;
    Vector2 check,first;
    int heal = 3;
    Animator a;
    private void Start()
    {
       first = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        distance = Vector2.Distance(transform.position, fox.position);

        if (distance <= 7)
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
        if (distance > 7)
        {

            transform.position = Vector2.MoveTowards(transform.position, first, 2 * Time.deltaTime);
        }
        if (heal == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Invoke("cancel", 0.2f);
            a.SetBool("hit", true);
            heal--;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    void cancel()
    {
        a.SetBool("hit", false);
    }
 


}

