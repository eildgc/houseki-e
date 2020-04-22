using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController characterController;
    /// <summary>
    /// Projectile to fire.
    /// </summary>
    public Projectile projectile;
    /// <summary>
    /// Some delay could be helpful to not spam projectiles and be overpowered.
    /// </summary>
    public float fireDelay = 1f;
    /// <summary>
    /// It help us to count how much time has passed so can fire again.
    /// </summary>
    private float timeSinceLastFire = 0f;
    /// <summary>
    /// Target that the player will be able to do damage.
    /// </summary>
    public string damageableTargetTag = "Enemy";
    
    private Animator animator;
    /// <summary>
    /// Vertical movement. To be used to make the player jump
    /// </summary>
    float vMovement = 0f;
    /// <summary>
    /// Horizontal movement. Used to make the player move.
    /// </summary>
    float hMovement = 0f;
    /// <summary>
    /// Player's speed when running
    /// </summary>
    float runningSpeed = 4.5f;
    /// <summary>
    /// To know if player is running or not
    /// </summary>
    bool running = false;
    /// <summary>
    /// Variable that saves the desire movement for the player.
    /// </summary>
    Vector3 movement = Vector3.zero;
    /// <summary>
    ///  Used to rotate the projectiles that the player instantiates or to dictate the desire rotation. 
    /// </summary>
    Quaternion rotation = Quaternion.identity;
    /// <summary>
    /// Variable that saves the desire movement for the player.
    /// Looks like at this time this variable is not used.
    /// </summary>
    Vector3 newForward = Vector3.zero;
    /// <summary>
    /// Player's speed when walking
    /// </summary>
    public float speed = 3f;
    /// <summary>
    /// Player's speed when jumping.
    /// </summary>
    public float jumpSpeed = 4f;
    /// <summary>
    /// To check direction that the player is facing
    /// </summary>
    bool movingRight = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        //The player is going to move if vMovement is different from 0.
        // -1 <-- 0 --> 1 
        if (characterController.isGrounded) {
            hMovement = Input.GetAxis("Horizontal");
            vMovement = 0f;
            //If there is movement, if the value is more than 0, player is not facing to the right
            if(hMovement != 0){
                movingRight = hMovement >= 0;
            }
            //Jumps
            if(Input.GetKeyDown(KeyCode.Space)){
                vMovement = jumpSpeed;
            }

            movement = new Vector3(hMovement, 0f, 0f);
            running = false;

            movement *= speed;

        }

        //Physics applied so the player does not fly when jumping or falling
        vMovement += Physics.gravity.y * Time.deltaTime;
        movement.y = vMovement;

        characterController.Move(movement * Time.deltaTime);

        timeSinceLastFire += Time.deltaTime;

        //Only can shot if certaing time has passed.
        if (timeSinceLastFire >= fireDelay){
            //Can shoot
            if (Input.GetButton("Fire1")){
            // Debug.Log("Pew");

                Projectile playerProjectileInstance = Instantiate(projectile, transform.position + new Vector3(0.5f,0f,0f), Quaternion.Euler(0, 0, 0));
                playerProjectileInstance.shootRight = movingRight;
                projectile.GetComponent<Projectile>().damageableTargetTag = "Enemy";
                //Timer is reset so we can shot next time.
                timeSinceLastFire = 0f;
                
            }
        }
    }
}
