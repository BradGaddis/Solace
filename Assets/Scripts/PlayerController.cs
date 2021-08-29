using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* FEATURES TO ADD:
 * Lock dash mechanic
 * Attack mechanic
 * Screen change mechanic that starts a battle scene
 */


public enum PlayerState
{
    IsIdle,
    IsRunning,
    IsWalking, 
    IsDashing
}

public class PlayerController : Engine
{

    // References to other GameObjects
    public PlayerState state;
    private Health health;

    // properties
    [SerializeField]
    private float walkSpeed = 2f;
    [SerializeField]
    private float runSpeed = 5;
    float dashtime = .5f;
    public float dashSpeed;


    public Vector2 newVelocity;

    [SerializeField]
    bool dirLocked;



    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        newVelocity = new Vector2(xDir, yDir) * dashSpeed;
        newVelocity = newVelocity.normalized;
        xDir = Input.GetAxisRaw("Horizontal");
        yDir = Input.GetAxisRaw("Vertical");
        HandleMovement();
        LimitVelocity(dashSpeed);
    }

    private void HandleMovement()
    {
        // Perhaps a switch statement works better here

        if (Input.GetKey(KeyCode.LeftShift))
        {
           Run();
        } 
        else if(Input.GetKey(KeyCode.E) && dirLocked)
        {
            Dash();
        }
        else
        {
            Walk();
            dirLocked = true;
        }
    }



    public void Walk()
    {
        Move(walkSpeed); 
        state = PlayerState.IsWalking;
    }

    public void Run()
    {
        Move(runSpeed);
        state = PlayerState.IsRunning;
    }


    // Edits velocity to allow for a dash between 2 points 
    public void Dash()
    {
        EnableVelociy_Dash();
        this.rb.AddForce(newVelocity, ForceMode2D.Impulse);
        LimitVelocity(dashSpeed);
        StartCoroutine(LockDirection(dashtime));

        state = PlayerState.IsDashing;


        Debug.Log(this.rb.velocity.magnitude);
    }


    // temporarily enables velocity such that object can be affected
    protected override void EnableVelociy_Dash(float time = .5f)
    {
        base.noVelicity = false;
        StartCoroutine(VelocityOnTime(dashtime));
    }


    //
    private IEnumerator VelocityOnTime(float time)
    {

        yield return new WaitForSeconds(time);
        base.noVelicity = true;


    }

    private IEnumerator LockDirection(float time)
    {

        // edit velocity to be 90 and -90 degrees respective to current length/magnitude
        yield return new WaitForSeconds(time);
        dirLocked = false;

    }

    public void LimitVelocity(float limit)
    {
        if (rb.velocity.magnitude > limit)
        {
            rb.AddForce(-newVelocity, ForceMode2D.Impulse);
        }
    }
}
