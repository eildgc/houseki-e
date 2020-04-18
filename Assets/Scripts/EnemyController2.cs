using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;    
    
    public GameObject projectile;
    private float timeBtwShots;
    public float startTimeBtwShots;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null) {
            return;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance) {
            
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            
        } else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) {
            
            transform.position = this.transform.position;
            
        //Si la distancia entre el enemigo y la posicion del player es menor que la distancia para retroceder.
        } else if (Vector2.Distance(transform.position, player.position) < retreatDistance) {

            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        
        if (timeBtwShots <= 0) {

            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        } else {

            timeBtwShots -= Time.deltaTime;
        }
    }

    
}
