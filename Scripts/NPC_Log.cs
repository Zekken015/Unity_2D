using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Log : Enemy
{
    [Header("Target Radius")]
    public float sightRadius;
    public float hitRadius;
    public Transform homeLocation;
    public Transform target;
    public Animator logAnimation;
    private Rigidbody2D logBody;

    /*
     * Start is called before the first frame update
     * finds the target with the tag "Player"
     */
    void Start()
    {
        currentState = EnemyPosition.stand;
        logBody = GetComponent<Rigidbody2D>();

        logAnimation = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame to make sure the NPC is within distance
    void FixedUpdate()
    {
        DistanceCheck();
    }

    /*
     * this code uses vector3 which has static properties that describe positions in unity
     * checks the distance of the target and if its within the distance of sightRadius
     * it will move towards it and start using the hitRadius
     */
    void DistanceCheck()
    {
        if(Vector3.Distance(target.position, 
                            transform.position) <= sightRadius
                            && Vector3.Distance(target.position, transform.position) > hitRadius)
        {
            if (currentState == EnemyPosition.stand || currentState == EnemyPosition.walk
                && currentState != EnemyPosition.stun)
            {
                Vector3 test = Vector3.MoveTowards(transform.position,
                                                         target.position, enemySpeed * Time.deltaTime);
                
                switchLogAnimation(test - transform.position);
                logBody.MovePosition(test);
                StateChange(EnemyPosition.walk);
                logAnimation.SetBool("wakeUp", true);
            }
        }
        else if(Vector3.Distance(target.position, transform.position) > sightRadius)
        {
            logAnimation.SetBool("wakeUp", false);
        }
    }

    
    private void logAnimationFloat(Vector2 setVector)
    {
        logAnimation.SetFloat("moveX", setVector.x);
        logAnimation.SetFloat("moveY", setVector.y);
    }

    //just changed the log animation depending on what is happening
    //it can move in different directions - https://docs.unity3d.com/ScriptReference/Mathf.Abs.html
    private void switchLogAnimation(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                logAnimationFloat(Vector2.right);
            }
            else if(direction.x < 0)
            {
                logAnimationFloat(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                logAnimationFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                logAnimationFloat(Vector2.down);
            }
        }
    }

    //Just changes to different positions
    private void StateChange(EnemyPosition newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
