using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* FEATURES TO ADD:
 * Dash mechanic
 * Attack mechanic
 * Screen change mechanic that starts a battle scene
 */



public enum PlayerState
{
    IsIdle,
    IsRunning,
    IsWalking
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
   



    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xDir = Input.GetAxisRaw("Horizontal");
        yDir = Input.GetAxisRaw("Vertical");
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
           Run();
        } else
        {
            Walk();
        }
    }

    public void Walk()
    {
        base.Move(walkSpeed); 
        state = PlayerState.IsWalking;
    }

    public void Run()
    {
        Move(runSpeed);
        state = PlayerState.IsRunning;
    }



}
