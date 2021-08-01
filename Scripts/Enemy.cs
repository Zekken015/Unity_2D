using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * this is like a boolean value however it can have multiple values
 * this will allow me to make characters have multiples states
 * and make it so its only 1 at a time and not multiple at once
 */

public enum EnemyPosition
{
    stand,
    walk,
    attack,
    stun
}


/*
 * this script will be used generally by all enemies within the game
 * as such this will be a collection that all enemies will use 
 * and each enemy will also have code on top of this for their own 
 * individual scripts
 */

public class Enemy : MonoBehaviour
{
    public EnemyPosition currentState;
    public float health;
    public int enemyAttack;
    public string enemyName;
    public float enemySpeed;
    public Float_Values totalHealth;


    private void Awake()
    {
        health = totalHealth.firstValue;
    }

    //this calculates how much damage an NPC will take and how long they will stay alive for
    private void DamageTaken(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }


    public void Knock(Rigidbody2D enemyRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(enemyRigidbody, knockTime));
        DamageTaken(damage);
    }

    //IEnumerator for the knock back of the monster.
    private IEnumerator KnockCo(Rigidbody2D enemyRigidbody, float knockTime)
    {
        if (enemyRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemyRigidbody.velocity = Vector2.zero;
            currentState = EnemyPosition.stand;
            enemyRigidbody.velocity = Vector2.zero;
        }
    }

}
