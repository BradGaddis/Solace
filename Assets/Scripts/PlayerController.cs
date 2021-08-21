using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* FEATURES TO ADD:
 * Run mechanic
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

public class PlayerController : MonoBehaviour
{

    // References to other GameObjects
    private Rigidbody2D rb;
    public AnimationHandler animationHandler;
    public PlayerState state;


    // properties
    [SerializeField]
    private float walkSpeed = 2f;
    [SerializeField]
    private float runSpeed = 5;
    float xAxis = 0;
    float yAxis = 0;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
        HandleMovement();

        Debug.Log(runSpeed);

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

    private void Move(float speed)
    {
        Vector2 curPos = rb.position;

        Vector2 delta = new Vector2();
        delta.x = xAxis;
        delta.y = yAxis;

        delta.Normalize();

        rb.MovePosition(curPos + delta.normalized * speed * Time.fixedDeltaTime);

    }

    public void Walk()
    {
        Move(walkSpeed);
        state = PlayerState.IsWalking;
    }

    public void Run()
    {
        Move(runSpeed);
       // moveState = MoveState.IsWalking;
    }


}
