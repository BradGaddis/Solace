using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* TODO:
 * Make every method in this class optional, but on by default 
 * correct that enemies cannot pass through other colliders 
 * Create pathfinder system for enemies to go home
 * Create combat system for enemies to fight each other
 */


/* KNOWN BUGS --
 * is waiting keeps turning on and theres not means to stop it from keeping going in the wrong direction...
 */


public enum EnemyState
{
    engaged,
    idle
}

public class EnemyDepreciate : MonoBehaviour
{

    GameObject player;

    public EnemyState enemyState;

    public bool enableChase = true;
    public bool enableWander = true;
    public float chaseRadius = 2f;
    public float attackRadius = 1f;
    public float homeRadius = 3f;
    public float moveSpeed = 2f;
    public float wanderDuration = 3f;
    private float lastWandered = 0f;
    public bool canAttack = true;
    public int minMax = 3;
    private float distanceFromHome;
    int ranRangeX = 0;
    int ranRangeY = 0;
    int stpnwait = 0;
    private float distEnemytoPlayer;

    Vector2 currentPos;
    Vector2 homePos;
    Vector2 target;
    Vector2 wanderTowards;
    Rigidbody2D enemyRB;

    //public int totalHealth;
    //public int totalStamina;
    //public int totalDefense;
    //public int totalMagic;

    

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        homePos = this.GetComponent<Rigidbody2D>().position;
        enemyRB = this.GetComponent<Rigidbody2D>();
        
    }


    private void Start()
    {
        ranRangeX = 0;
        ranRangeY = 0;
        target = homePos;
        wanderTowards = homePos;

        // Check if attack radius is larger than chase radius, should always be smaller
        if(attackRadius >= chaseRadius)
        {
            attackRadius = chaseRadius - 1;
        }
    }

    private void FixedUpdate()
    {

        currentPos = enemyRB.position;
        distanceFromHome = Vector2.Distance(currentPos, homePos);

        //if (enableChase)

            //CheckChasePlayer(out distEnemytoPlayer, canAttack);
        WanderAround();
       


    }

    // Chases player within specific radius
    public virtual void CheckChasePlayer(out float distEnemytoPlayer, bool canAttack)
    {
        // get player position stuff
        Vector2 position = enemyRB.position;
        Vector2 playerPos = player.GetComponent<Rigidbody2D>().position;
        
        // check distance between enemy and player gameObjects 
        float distance = Vector2.Distance(position, playerPos);
        Vector2 moveTowards = new Vector2(0, 0);


        // handle attack, wander, and chase logic
        if (distance <= chaseRadius && distance >= attackRadius )
        {
            moveTowards = Vector2.MoveTowards(position, playerPos, moveSpeed * Time.fixedDeltaTime);
            enemyRB.MovePosition(moveTowards);
        }
        else if (distance > chaseRadius)
        {

            ReturnHome();

        }
        else if(enableWander && distance > attackRadius)
        {
           WanderAround();
        }
        else if (distance <= attackRadius && canAttack)
        {
            attackPlayer();
        }

        // attack player if enemy is within attack radius
        
        distEnemytoPlayer = distance;
    }



    public virtual bool IsAtHome()
    {
        // distance from home position that is set on awake to current position
        if(distanceFromHome <= homeRadius)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public virtual void ReturnHome()
    {
        Vector2 moveTowards = Vector2.MoveTowards(currentPos, homePos, moveSpeed * Time.fixedDeltaTime);
        enemyRB.MovePosition(moveTowards);

        /*
         * If takes more than a few moments, despawn game object and move them home
         */
    }

    bool isWaiting;


    public void WanderAround()
    {
        // first go round sets target basically to zero.
        target = new Vector2(ranRangeX + currentPos.x, ranRangeY + currentPos.y);

        if (Time.time - lastWandered <= wanderDuration && IsAtHome() && !isWaiting)
        {
            // do not allow wander if in chase raidus
            
            target = new Vector2(ranRangeX + currentPos.x, ranRangeY + currentPos.y);
            wanderTowards = Vector2.MoveTowards(currentPos, target, moveSpeed * Time.fixedDeltaTime);
            enemyRB.MovePosition((wanderTowards));
            enemyState = EnemyState.idle;

            // random idle
            if(stpnwait >= 10)
            {
                isWaiting = true;
                return;
            }

        }
        // reseting parameters in the timer
        else if (Time.time - wanderDuration >= lastWandered)
        {
            lastWandered = Time.time;
            isWaiting = false;
            stpnwait = Random.Range(1, 11);
            ranRangeX = Random.Range(-minMax, minMax + 1);
            ranRangeY = Random.Range(-minMax, minMax + 1);
                

        }
        else if(!IsAtHome())
        { 
            ReturnHome();
            isWaiting = true;
        }
        
    }


    private void attackPlayer()
    {
        // change state of enemy into attack state
        // inflict some damage e
        // knock player back
    }

}




