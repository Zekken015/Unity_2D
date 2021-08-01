using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this code is to create different states using enum.
public enum PlayerPosition
{
    stand,
    walk,
    attack,
    interact,
    stun
}
//Set some important variables that are described here.
public class Player_Movement : MonoBehaviour
{
    public PlayerPosition currentState;
    public float speed;
    private Rigidbody2D playerBody;
    private Vector3 change;
    private Animator animator;

    [Header("Health Parameters")]
    public Float_Values health;
    public Signal_Send healthSignal;
    public Player_Positioning resumeLocation;

    /* 
    Start is called before the first frame update
    sets the player state to walk and sets its position to -1
    in the animator 
    */
    void Start()
    {
        currentState = PlayerPosition.walk;

        animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();

        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);

        transform.position = resumeLocation.firstValue;
    }

    /* 
    */
    /* 
     * updates with every frame, sets the vector 3 to zero
     * receives input from the game marked as Horizontal or Vertical
     * if the player attacks then it changes the state 
     * making the player unable to use 2 different states at the same time
     * if the player is in the walking state it runs the UpdateAnimationAndMove method
    */

    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("attack") && currentState != PlayerPosition.attack && currentState != PlayerPosition.stun)
        {
            StartCoroutine(AttackCo());
        }

        else if(currentState == PlayerPosition.walk || currentState == PlayerPosition.stand)
        {
            UpdateAnimationAndMove();
        }

    }

    /* checks the movement of the character in the attack possition
     * when the user triggers attack it runs this code.
    */
    private IEnumerator AttackCo()
    {
        animator.SetBool("attack", true);
        currentState = PlayerPosition.attack;
        yield return null;
        animator.SetBool("attack", false);
        yield return new WaitForSeconds(.28f);
        currentState = PlayerPosition.walk;
    }

    //this makes sure you cant move while making animations such as attacking
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();

            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);

            animator.SetBool("moving", true);

        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    //Math for player movement - https://docs.unity3d.com/ScriptReference/Rigidbody.MovePosition.html
    void MoveCharacter()
    {
        change.Normalize();
        playerBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    //a timer to make player get knocked and stuck in animation.
    //also updates health values on player
    public void Knock(float knockTime, float damage)
    {
        health.DurationValue -= damage;
        healthSignal.Raise();
        //simple if statement that mainly runs the coroutine
        if (health.DurationValue > 0)
        {
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    //IEnumerator for the knock back of the player.
    private IEnumerator KnockCo(float knockTime)
    {
        if (playerBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            playerBody.velocity = Vector2.zero;

            currentState = PlayerPosition.stand;
            playerBody.velocity = Vector2.zero;
        }
    }
}
