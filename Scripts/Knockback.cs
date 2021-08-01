using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*this script is for moving a target when it gets "hit" 
 * it also has the part of the "pot" which is an object in the game
 * it allows to "shatter" the pot and destroy it.
 */
public class Knockback : MonoBehaviour
{

    public float thrust;
    public float knockTime;
    public float damage;

    //compares the tag and any object with the tag "breakable" will run this if statement.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("breakable"))
        {
            collision.GetComponent<Pot>().Shatter();
        }

        //this part checks the tags of "Enemy" and "Player"
        //does some math to calculate the position it would be in when knocked back
        //and how much damage they take
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hitBox = collision.GetComponent<Rigidbody2D>();
            if (hitBox != null)
            {
                Vector2 difference = hitBox.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hitBox.AddForce(difference, ForceMode2D.Impulse);

                if (collision.gameObject.CompareTag("Enemy") && collision.isTrigger)
                {
                    hitBox.GetComponent<Enemy>().currentState = EnemyPosition.stun;
                    collision.GetComponent<Enemy>().Knock(hitBox, knockTime, damage);
                }

                // this part is for the player, works the same way as for the enemy
                // knocks the user back with a timer and some amount of damage.
                if (collision.gameObject.CompareTag("Player"))
                {
                    if(collision.GetComponent<Player_Movement>().currentState != PlayerPosition.stun)
                    {
                        hitBox.GetComponent<Player_Movement>().currentState = PlayerPosition.stun;
                        collision.GetComponent<Player_Movement>().Knock(knockTime, damage);
                    }
                }
            }
        }
    }
}
