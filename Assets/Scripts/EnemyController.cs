using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float fireDelay = 1f;
    public GameObject projectile;
    private float timeSinceLastFire = 0f;
    private float maxPositionX = 1f;
    private float minPositionX = 0f;
    private bool movingRight = true;
    public float movementSpeed = 1f;
    public int projectilesFired = 0;
    public int OnFireProjectileCount = 3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        maxPositionX = 1;
        minPositionX = 0;
        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        timeSinceLastFire += Time.deltaTime;
        
        if (movingRight) {
            //Move right
            transform.Translate(new Vector2(movementSpeed, 0f));
            //Revisar si llega al limite superior en X permitido
            if(pos.x >= maxPositionX) {
                //Ahora se debe mover a la izquierda
                movingRight = false;
            }
        } else {
            //move left
            transform.Translate(new Vector2(-movementSpeed, 0f));
            if(pos.x <= minPositionX) {
                //Ahora se debe mover a la izquierda
                movingRight = true;
            }
        }
        //Solamente se puede disparar si ya paso el tiempo definido
        if (timeSinceLastFire >= fireDelay) {
            //Can shoot
            //Crear proyectil
            Instantiate(projectile, transform.position + new Vector3(-2f,0f,0f), Quaternion.Euler(0, 0, 180));
            projectile.GetComponent<Projectile>().damageableTargetTag = "Player";
            projectilesFired++;
            timeSinceLastFire = 0f;
        

        //you will get the direction from the enemy to the player by using 
        //(playerTransform.position - enemyTransform.position).normalized


        }
        //Reiniciar contador de tiempo para disparar
       
        // projectilesFired = 0;
    }
            
}
