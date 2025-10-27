using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;
    public AudioClip walkingSteps;
    public AudioSource footstepSound;
    public TextMeshProUGUI scrapText;
    public TextMeshProUGUI healthText;
    public Transform playerStartPosition;
    public int scrapCollected = 0;
    public float playerHealth = 200f;

    private float walkSpeed = 4f;

    private float gravity = 20f;

    public float lookSpeed = 2f;
    private float lookXLimit = 90f;

    Vector3 moveVelocity = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    CharacterController characterController;

    void Start()
    {
        playerHealth = 200f;
        characterController = GetComponent<CharacterController>();
        transform.position = playerStartPosition.position;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        forward.Normalize();
        right.Normalize();

        float curDirectionX  = canMove ? Input.GetAxis("Vertical") : 0;
        float curDirectionY = canMove ? Input.GetAxis("Horizontal") : 0;
        Vector3 moveDirection = (forward * curDirectionX) + (right * curDirectionY);

        float movementDirectionY = moveVelocity.y;
        moveVelocity = moveDirection * walkSpeed;

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

        // Scrap Text Display
        scrapText.text = scrapCollected.ToString() + "/10";
        healthText.text = ((int)playerHealth).ToString() + "/200";
    }

    private void footstep()
    {
        if (characterController.isGrounded && (moveVelocity.x != 0 || moveVelocity.z != 0))
        {
            footstepSound.pitch = Random.Range(0.7f, 1.1f);
            if (!footstepSound.isPlaying)
            {
                footstepSound.PlayOneShot(walkingSteps);
            }
        }
        else
        {
            footstepSound.Stop();
        }
    }
}