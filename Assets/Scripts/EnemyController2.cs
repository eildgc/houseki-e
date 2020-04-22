using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    /// <summary>
    /// Used to manage speed of the enemy when moving.
    /// </summary>
    public float speed;

    /// <summary>
    /// Value that determines the distance of enemy to stop moving away or closer from the player.
    /// </summary>
    public float stoppingDistance;
    /// <summary>
    /// Value that determines the distance of the enemy from the player to know if it have to move away
    /// </summary>
    public float retreatDistance;    
    /// <summary>
    /// It's going to use the GameObject projectile, because the enemy is going to shots.
    /// </summary>
    public GameObject projectile;
    /// <summary>
    /// Time between shots, used to make the enemy shots quickly or slower between every shot.
    /// </summary>
    private float timeBtwShots;
    /// <summary>
    /// Value that help us to count if it is time to shot.
    /// </summary>
    public float startTimeBtwShots;

    /// <summary>
    /// We will use the player's position values.
    /// </summary>
    private Transform player;
    void Start()
    {
        //Look for the location of a gameObject with tag "Player" and saves it in this variable
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //Makes the time between shots equals to start time between shots, its initial values for both is 0.
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        //First check if player is null
        if(player == null) {
            return;
        }
        //If the player is not null, then the code proceed to check a few statements that measure the
        //distance between the player and the enemy, so it can "decide" if minimize distance between them, retreat or just stand in its place.
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance) {
            
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //If the distance of player's position is less than the stopping Distance and the distance of player's position is more than the retreat distance, the enemy just
        //stand at this position  
        } else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) {
            
            transform.position = this.transform.position;
            
        //If distance between enemy and the player position is less than the established retreatDistance, then retreat to a "safer" distance.
        } else if (Vector2.Distance(transform.position, player.position) < retreatDistance) {

            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        
        //If the time established between shots is less or equal to 0, the enemy can shots. 
        if (timeBtwShots <= 0) {
        //Instantiate a projectile in the position and rotation of the enemy, it also updates the time between shots value.   
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        //
        } else {
        //If a projectile was not instantiate, the value in time between shots is updated with - 1 so may be a projectile can be shot next time this if is called. 
            timeBtwShots -= Time.deltaTime;
        }
    }

    
}
