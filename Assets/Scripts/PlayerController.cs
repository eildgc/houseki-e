using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController characterController;
    public Projectile projectile;
    public float fireDelay = 1f;
    private float timeSinceLastFire = 0f;
    public string damageableTargetTag = "Enemy";
    
    private Animator animator;
    float vMovement = 0f;
    float hMovement = 0f;
    float runningSpeed = 4.5f;
    bool running = false;
    Vector3 movement = Vector3.zero;
    Quaternion rotation = Quaternion.identity;
    Vector3 newForward = Vector3.zero;
    public float speed = 3f;
    public float turnSpeed = 5f;
    public float jumpSpeed = 4f;

    bool movingRight = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // -1 <-- 0 --> 1 
        if (characterController.isGrounded) {
            hMovement = Input.GetAxis("Horizontal");
            vMovement = 0f;

            if(hMovement != 0){
                movingRight = hMovement >= 0;
            }
            
            if(Input.GetKeyDown(KeyCode.Space)){
                vMovement = jumpSpeed;
            }

            movement = new Vector3(hMovement, 0f, 0f);
            running = false;

            movement *= speed;

        }

        vMovement += Physics.gravity.y * Time.deltaTime;
        movement.y = vMovement;

        characterController.Move(movement * Time.deltaTime);

        timeSinceLastFire += Time.deltaTime;

        //Solamente se puede disparar si ya paso el tiempo definido
        if (timeSinceLastFire >= fireDelay){
            //Can shoot
            if (Input.GetButton("Fire1")){
            // Debug.Log("Pew");
            //Crear proyectil
            //TODO Si donde se instancia esta moviendose a la izquierda, disparar en esa direccion
            //TODO Si donde se instancia esta moviendose a la derecha, disparar en esa direccion

                Projectile playerProjectileInstance = Instantiate(projectile, transform.position + new Vector3(0.5f,0f,0f), Quaternion.Euler(0, 0, 0));
                playerProjectileInstance.shootRight = movingRight;
                projectile.GetComponent<Projectile>().damageableTargetTag = "Enemy";
                //Reiniciar contador de tiempo para disparar
                timeSinceLastFire = 0f;
                
            }
        }
    }
}
