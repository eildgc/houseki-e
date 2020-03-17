using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController characterController;
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
