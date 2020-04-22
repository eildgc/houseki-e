using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    //Enemy's Projectile
    public float speed;
    /// <summary>
    /// We saved the value of the player position.
    /// </summary>
    private Transform player;

    /// <summary>
    /// Used to make easier when read the code. It copies the value of the variable player.
    /// </summary>
    private Vector2 target;
    /// <summary>
    /// The projectile has a lifespan, the projectile will be destroyed when its lifespan is depleted to 0.
    /// </summary>
    public float m_Lifespan = 0.5f; // this is the projectile's lifespan (in seconds)
        
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        Destroy(gameObject, m_Lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        //It's unknown what this script do if the player is null.
        //TODO.

        //Looks for the player position and the projectile instantiated is will go to the values
        //saved here in that moment.
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        // if we wanted that the projectile follow the player, the follow line should be uncommented.
        //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        //if the projectile reach the position saved previously, it's going to be destroyed, if not
        //triggered by player's collider.
        if (transform.position.x == target.x && transform.position.y == target.y){
            DestroyProjectile();
        }
    }

    //The projectile is like a ghost when we use trigger instead of OnCollisionEnter. When it
    //"touch" the player, the projectile is destroyed and it hit the player
    private void OnTriggerEnter(Collider other) {

       if (other.gameObject.CompareTag("Player")) {
           Stats enemyStats = other.gameObject.GetComponent<Stats>();
            enemyStats.OnHit();
           DestroyProjectile();

       }
    }
    /// <summary>
    /// This can be used to destroy the projectile.
    /// </summary>
    void DestroyProjectile(){
            Destroy(gameObject);
        }
    }

