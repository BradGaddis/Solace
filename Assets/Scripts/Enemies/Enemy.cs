using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    IsIdle,
    IsWandering
}

public class Enemy : Engine
{
    public EnemyState state;

    public float speed = 1f;
    public float timer;
    float startTime = 3f;
    private void Start()
    {
        timer = startTime;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Wander();
    }

    protected virtual void Wander()
    {
        // enemy moves for some time and then changes direction
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = startTime;
            xDir = Random.Range(-1, 2);
            yDir = Random.Range(-1, 2);
        }
        else
        {
            Move(speed);
        }

        this.state = EnemyState.IsWandering;
    }


    
}
