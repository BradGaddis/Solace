using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* FEATURES TO ADD:
 * Run mechanic
 * Dash mechanic
 * Attack mechanic
 * Screen change mechanic that starts a battle scene
 */

/*KNOWN BUGS:
 * Player continues moving after collision with enemy when should only take knock back
 */
public class PlayerController : MonoBehaviour
{

    // References to other GameObjects
    private Rigidbody2D rb;
    private Animator animator;


   
    public float speed = 1;
    public bool autoMove = false;

    // health information:
    public int maxHealth;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");
        HandleMovement(xAxis, yAxis);
    }

    // Handles movement and animations associated therewithin
    void HandleMovement(float xAxis, float yAxis)
    {
        Vector2 moveDelta;
        moveDelta.x = xAxis;
        moveDelta.y = yAxis;

        moveDelta = moveDelta.normalized * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + moveDelta.normalized * speed * Time.fixedDeltaTime);


        HandleAnimation(xAxis, yAxis);


        //rb.position += moveDelta; 

        
    }

    bool firstIdle = true;
    private void HandleAnimation(float xAxis, float yAxis)
    {
        animator.SetFloat("walkX", xAxis);
        animator.SetFloat("walkY", yAxis);


        if(firstIdle && true)
        {
            animator.SetFloat("idleX", xAxis);
            animator.SetFloat("idleY", yAxis);
            firstIdle = false;
        }

        if(xAxis > 0 || xAxis < 0 || yAxis > 0 || yAxis < 0)
        {
            animator.SetFloat("idleX", xAxis);
            animator.SetFloat("idleY", yAxis);

            //Debug.Log("X IDLE: " + animator.GetFloat("idleX"));
            //Debug.Log("Y IDLE: " + animator.GetFloat("idleY"));
        }
        
    }
}




/* if (maxTime >= timer)
        {
            timer -= Time.fixedDeltaTime;
            if (timer < 0)
            {
                timer = maxTime;
            }
            else
            {
                // do shit
            }
        }*/