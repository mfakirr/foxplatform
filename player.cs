using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D body2D; 
    public float playerspeed=5,jumppower=13,moveinput;
    [SerializeField] private Transform groundcheck,crunchcheck;   // A position marking where to check if the player is grounded.
    [SerializeField] private float radius;
    [SerializeField] private LayerMask groundwhat;
    public bool isground,facingright=true,iscrunch,crunching=true,crouch;
    [SerializeField] private int extrajumps=0,extrajumpvalue;
    public Animator run;
    [SerializeField] private Collider2D m_CrouchDisableCollider;
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 3;
        extrajumps = extrajumpvalue;
        body2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        isground = Physics2D.OverlapCircle(groundcheck.position, radius, groundwhat);
        iscrunch = Physics2D.OverlapCircle(crunchcheck.position, radius, groundwhat);

        moveinput = Input.GetAxis("Horizontal");
        body2D.velocity = new Vector2(moveinput * playerspeed, body2D.velocity.y);

     if(facingright ==  false && moveinput > 0){ flip();Debug.Log("sağa"); }
     else if (facingright==true && moveinput < 0) { flip(); Debug.Log("sola"); }
    }
    void Update()
    {
        
        if (isground) { extrajumps = extrajumpvalue;  run.SetBool("jumping", false); }
        if (!isground) {  run.SetBool("jumping", true); }

        if (Input.GetKeyDown(KeyCode.UpArrow ) && extrajumps > 0)
        {
            
            body2D.velocity = Vector2.up * jumppower;
            extrajumps--;
        }else if(Input.GetKeyDown(KeyCode.UpArrow) && extrajumps == 0 && isground == true)
        {
            
            body2D.velocity = Vector2.up * jumppower;
        }

        run.SetFloat("speed", Mathf.Abs( moveinput));
        //if (!iscrunch && Mathf.Abs(moveinput) > 0.1f && !(crunching)) { Invoke("dikil", 0.3f); }

       if (Input.GetKey(KeyCode.DownArrow) || !iscrunch) { crunch(); crunching = true; }
        if (!Input.GetKey(KeyCode.DownArrow)) {  crunching = false; }
    }

    void crunch()
    {

        if ((isground && !run.GetBool("jumping") && Input.GetKey(KeyCode.DownArrow)))
        {

            run.SetBool("crunching", true);
            if (m_CrouchDisableCollider != null)
                m_CrouchDisableCollider.enabled = false;
        }
        else if ((!Input.GetKey(KeyCode.DownArrow) && !iscrunch && !(Mathf.Abs(moveinput) > 0.1f)) /*|| (!iscrunch && Mathf.Abs( moveinput)>0.1f)*/)
        {
            crunching = false;
            run.SetBool("crunching", false);
            if (m_CrouchDisableCollider != null)
                m_CrouchDisableCollider.enabled = true;
        } else if ((!Input.GetKey(KeyCode.DownArrow) && !iscrunch && (Mathf.Abs(moveinput) > 0.1f))) { Invoke("dikil", 0.2f); }


    }

    void dikil()
    {
        crunching = false;
        run.SetBool("crunching", false);
        if (m_CrouchDisableCollider != null)
            m_CrouchDisableCollider.enabled = true;
    }
    void shooter()
    {
        run.SetBool("shoot", true);

    }
    void flip()
    {
        facingright = !facingright;
        transform.Rotate(0, 180, 0);
    }
   
}
