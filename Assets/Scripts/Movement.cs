using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Obsolete("THIS SCRIPT IS OBSOLETE. THE NEW ONE IS PlayerController.cs",true)]
public class Movement : MonoBehaviour
{   
    //THIS SCRIPT IS OBSOLETE. THE NEW ONE IS PlayerController.cs
    //for the enemy, it uses EnemyController2.cs
    //Thank you for reading,
    //Quack
    CharacterController characterController;
    /// <summary>
    /// 
    /// </summary>
    private Animator animator;
    /// <summary>
    /// Vertical movement. To be used to make the player jump
    /// </summary>
    float vMovement = 0f;
    /// <summary>
    /// Horizontal movement. Used to make the player move.
    /// </summary>
    float hMovement = 0f;
    
    //float runningSpeed = 4.5f;
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
    /// 
    /// </summary>
    Vector3 newForward = Vector3.zero;
    public float speed = 3f;
    public float turnSpeed = 5f;
    public float jumpSpeed = 4f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded) {
            hMovement = Input.GetAxis("Horizontal");
            vMovement = 0f;

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
    }
}
