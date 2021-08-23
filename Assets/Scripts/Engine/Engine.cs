using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{

    protected Rigidbody2D rb;
    protected float xDir = 0;
    protected float yDir = 0;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       
        CheckVelocity();
    }
    private void FixedUpdate()
    {
        CheckVelocity();
    }

    // all game objects should move fundamentally the same way
    protected void Move(float speed = 2)
    {
        Vector2 curPos = rb.position;

        Vector2 delta = new Vector2();
        delta.x = this.xDir;
        delta.y = this.yDir;

        delta.Normalize();

        rb.MovePosition(curPos + delta.normalized * speed * Time.fixedDeltaTime);
    }


    protected void CheckVelocity()
    {
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
