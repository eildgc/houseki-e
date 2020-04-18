using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    //Enemy's Projectile
    public float speed;
    private Transform player;
    private Vector2 target;
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
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    // if we wanted that the projectile follow the player 
    //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

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
    void DestroyProjectile(){
            Destroy(gameObject);
        }
    }

