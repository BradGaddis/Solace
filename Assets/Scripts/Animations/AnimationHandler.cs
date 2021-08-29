using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationHandler : MonoBehaviour
{
    private PlayerController playerContoller;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    bool firstIdle = true;
    float xAxis;
    float yAxis;

    public Sprite[] dashSprites;


    private void Start()
    {
        animator = GetComponent<Animator>();
        playerContoller = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");

        if (playerContoller.state == PlayerState.IsWalking)
        {
            HandlePlayerWalkAnim();
        }
        // else if(playerContoller.state == PlayerState.IsDashing)
        //{
        //    //HandlePlayerDashAnim();
        //}


    }


    private void HandlePlayerWalkAnim()
    {
        if (firstIdle)
        {
            animator.SetFloat("idleX", 0);
            animator.SetFloat("idleY", 0);
            firstIdle = false;
        }
        if (xAxis != 0 || yAxis != 0)
        {
            animator.SetFloat("idleX", xAxis);
            animator.SetFloat("idleY", yAxis);

        }

        animator.SetFloat("walkX", xAxis);
        animator.SetFloat("walkY", yAxis);
    }

    //public void HandlePlayerDashAnim()
    //{
    //        //spriteRenderer.sprite = dashSprites[(int)Time.time % 10];
    //}


}
