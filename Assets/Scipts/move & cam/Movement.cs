using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement Instance {  get; private set; }  // para accessible sa other file 


    public float movespeed = 5f;
    public CharacterController controller;                  // pang move lang talaga walang rigidbody (Galaw)

    public float Jumpheight = 1f;                          // Jump eme
    public float gravity = -50.392f;
    private Vector3 velocity;
    private bool isGrounded;


    private void Awake()                                   // method ensure there is only one instances
                                                           // nauuna lagi to awake bago start
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    void Update()                                       // Every frame yung execution para macheck nya napindot sya
    {
       HandleMovement();
    }

    public void HandleMovement()                       
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * horizontal + transform.forward * vertical;   // declare direction
        controller.Move(direction * movespeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(Jumpheight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
} 