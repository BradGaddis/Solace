using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationHandler : MonoBehaviour
{

    private Animator animator;
    bool firstIdle = true;
    float xAxis;
    float yAxis;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");

        HandleWalkAnim();


    }


    private void HandleWalkAnim()
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

}
