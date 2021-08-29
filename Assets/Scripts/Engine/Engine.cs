using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{

    protected Rigidbody2D rb;
    protected float xDir = 0;
    protected float yDir = 0;
    public bool noVelicity = true;
    

    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void Update()
    {
        if (rb != null)
        {
            if (noVelicity)
            {
                ResetVelocity();
            }
        }
    }
    private void FixedUpdate()
    {
        if (rb != null)
        {
            if (noVelicity)
            {
                ResetVelocity();
            }
        }
    }

    // all game objects should move fundamentally the same way
        /// <summary>
        /// This virtual method uses Unity input system to move this rigidbody
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="enabled"></param>
    protected virtual void Move(float speed = 2, bool enabled = true)
    {
        if (enabled)
        {
            Vector2 curPos = rb.position;

            Vector2 delta = new Vector2();
            delta.x = this.xDir;
            delta.y = this.yDir;

            delta.Normalize();

            rb.MovePosition(curPos + delta.normalized * speed * Time.fixedDeltaTime);
        }
    }


    protected void ResetVelocity()
    {
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            rb.velocity = Vector2.zero;
        }
    }
    protected virtual void EnableVelociy_Dash(float time = .5f)
    {
        noVelicity = false;
    }
    // add pushback mechanic
}
