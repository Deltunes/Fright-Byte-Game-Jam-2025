using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;
    public AudioClip walkingSteps;
    //public AudioClip runningSteps;
    public AudioSource footstepSound;

    public float walkSpeed = 20f;
    //public float runSpeed = 20f;

    /*
    public int maxJumps = 2;
    private int jumpCount;
    public float jumpPower = 10f;
    */

    public float gravity = 20f;

    public float lookSpeed = 2f;
    public float lookXLimit = 90f;

    Vector3 moveVelocity = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;
    //bool isRunning = false;

    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        forward.Normalize();
        right.Normalize();

        //Left shift to run
        /*
        if (Input.GetKey(KeyCode.LeftShift) && characterController.isGrounded)
        {
            isRunning = true;
        } 
        else
        {
            isRunning = false;
        }
        */

        float curDirectionX  = canMove ? Input.GetAxis("Vertical") : 0;
        float curDirectionY = canMove ? Input.GetAxis("Horizontal") : 0;
        Vector3 moveDirection = (forward * curDirectionX) + (right * curDirectionY);

        float movementDirectionY = moveVelocity.y;
        //moveVelocity = moveDirection * (isRunning ? runSpeed : walkSpeed);
        moveVelocity = moveDirection * walkSpeed;

        // Jump
        /*
        if (characterController.isGrounded && jumpCount < maxJumps)
        {
            jumpCount = maxJumps;
        }

        if (Input.GetKeyDown("space") && canMove && jumpCount > 0)
        {
            moveVelocity.y = jumpPower;
            jumpCount--;
        }
        else
        {
            moveVelocity.y = movementDirectionY;
        }
        */

        if (!characterController.isGrounded)
        {
            moveVelocity.y -= gravity * Time.deltaTime;
        }

        //Footstep Sound
        footstep();

        //Move Character
        characterController.Move(moveVelocity * Time.deltaTime);

        //Rotation
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }

    private void footstep()
    {
        if (characterController.isGrounded && (moveVelocity.x != 0 || moveVelocity.z != 0))
        {
            footstepSound.pitch = Random.Range(0.7f, 1.1f);
            if (!footstepSound.isPlaying)
            {
                /*
                if (!isRunning)
                {
                    footstepSound.PlayOneShot(walkingSteps);
                }
                else
                {
                    footstepSound.PlayOneShot(runningSteps);
                }
                */
                footstepSound.PlayOneShot(walkingSteps);
            }
        }
        else
        {
            footstepSound.Stop();
        }
    }
}