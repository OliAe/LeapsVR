using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private CharacterController charController;

    public string horizontalInputName;
    public string verticalInputName;
    public float landmineJump = 60;
    private bool isJumping;
    public float maxJump = 3;
    public float currentJump = 1.0f;
    public float movementSpeed;
    public float jumpMultiplier = 30.0f;
    public float verticalVelocity = 0;
    public float max = 9.8f;
    public float acceleration = 20f;


    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }
 
    private void Update()
    {
        //Jumping Physics

        if (Input.GetButtonDown("Jump") && (maxJump > currentJump))
        {
            verticalVelocity = jumpMultiplier;
            currentJump++;
        }

        if (!charController.isGrounded)
        {
            verticalVelocity = Mathf.MoveTowards(verticalVelocity, -max, acceleration * Time.deltaTime);
        }
        else
        {
            verticalVelocity = 0;

            if ((Input.GetButtonDown("Jump") && (maxJump > currentJump)))
            {
                verticalVelocity = jumpMultiplier;
            }
        }

        //Movement Physics 

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, verticalVelocity, Input.GetAxis("Vertical") * movementSpeed);
        moveDirection = transform.TransformDirection(moveDirection);
        charController.Move(moveDirection * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (other.CompareTag("ForceObject"))
        {
            Pickup(other);
        }

        void Pickup(Collider player)
        {
            verticalVelocity = landmineJump;
        }

        if (other.CompareTag("Finish"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

    }
}

