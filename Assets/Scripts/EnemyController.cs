using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    
    //Enemy script OBSOLETE

    public float fireDelay = 1f;
    public GameObject projectile;
    private float timeSinceLastFire = 0f;
    private float maxPositionX = 1f;
    private float minPositionX = 0f;
    private bool movingRight = true;
    public string damageableTargetTag = "Player";
    public float movementSpeed = 0.2f;
    public int projectilesFired = 0;
    public int OnFireProjectileCount = 3;

    public bool shootRight;

    private CharacterController characterController;
    float hMovement = 1f;
    float vMovement = 1f;
    Vector3 movement = Vector3.zero;
    Quaternion rotation = Quaternion.identity;
    Vector3 newForward = Vector3.zero;

    Vector3 playerDistance = new Vector3(9999,9999,0);
    public float shootPlayerDistanceThreshold = 0f;
    public GameObject player;




    void Start()
    {
        characterController = GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        vMovement += Physics.gravity.y * Time.deltaTime;
        movement.y = vMovement;

        characterController.Move(movement * Time.deltaTime);

        maxPositionX = 1;
        minPositionX = 0;

        var pos = Camera.main.WorldToViewportPoint(transform.position);

        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);

        timeSinceLastFire += Time.deltaTime;

        
        
        if (movingRight) {
            //Move right
            // transform.Translate(new Vector2(movementSpeed, 0f));
            transform.Translate(new Vector3(movementSpeed, 0f, 0f));
            vMovement = 0f;
            //Revisar si llega al limite superior en X permitido
            if(pos.x >= maxPositionX) {
            //Ahora se debe mover a la izquierda
                movingRight = false;
            }
        } else {
            //move left
            // transform.Translate(new Vector2(-movementSpeed, 0f));
            transform.Translate(new Vector3(-movementSpeed, 0f, 0f));
            if(pos.x <= minPositionX) {
                //Ahora se debe mover a la izquierda
                movingRight = true;
            }
        }
        if (player != null){
            playerDistance = player.transform.position - transform.position;
        }
        //Solamente se puede disparar si ya paso el tiempo definido
        if (timeSinceLastFire >= fireDelay && playerDistance.magnitude <= shootPlayerDistanceThreshold) {
            //Can shoot
            //Crear proyectil
            
            shootRight = playerDistance.x > 0;
            //TODO voltear hacia donde se encuentra el Player
            //TODO Disparar al player
            var spawnOffSet = new Vector3(1.5f,0f,0f);
            if (!shootRight){
                spawnOffSet = new Vector3(-1.5f,0f,0f);
            }
            Instantiate(projectile, transform.position + spawnOffSet, Quaternion.Euler(0, 0, 0));
            Projectile projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.damageableTargetTag = "Player";
            projectileComponent.shootRight = shootRight;
            
            projectilesFired++;
            timeSinceLastFire = 0f;
        }
    }
            
}


