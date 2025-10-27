using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driveBoat : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject boat;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject InteractVisual;
    [SerializeField] AudioSource engineSound;
    [SerializeField] GameObject player;
    bool playerDriving = false;
    FPSController FPS;

    float currSpeed;
    float currRotate;

    private float boatForwardSpeed;
    private float boatBackwardSpeed;
    private float boatRotateSpeed;
    private float boatMaxSpeed;

    private void Start()
    {
        bool webGLBuild = true;
        if (webGLBuild)
        {
            boatForwardSpeed = 160f;
            boatBackwardSpeed = 50f;
            boatRotateSpeed = 150f;
            boatMaxSpeed = 100f;
        }
        else
        {
            print("oops");
            boatForwardSpeed = 100f;
            boatBackwardSpeed = 50f;
            boatRotateSpeed = 80f;
            boatMaxSpeed = 100f;
        }
    }

    private void Update()
    {
        if (playerDriving)
        {
            currSpeed = 0f;
            currRotate = 0f;

            if (Input.GetKey(KeyCode.W))
            {
                if (engineSound.pitch < 2)
                {
                    engineSound.pitch += 0.001f;
                }
                currSpeed = boatForwardSpeed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                currSpeed = -boatBackwardSpeed;
            }

            if (Input.GetKey(KeyCode.D))
            {
                currRotate = boatRotateSpeed;
                transform.Rotate(Vector3.up, 200 * Time.deltaTime, Space.Self);
            }
            if (Input.GetKey(KeyCode.A))
            {
                currRotate = -boatRotateSpeed;
                transform.Rotate(Vector3.up, -200 * Time.deltaTime, Space.Self);
            }

            rb.AddRelativeTorque(rb.transform.up * currRotate);

            if (rb.velocity.magnitude < boatMaxSpeed)
            {
                rb.AddRelativeForce(Vector3.forward * currSpeed);
            }
        }
        if (engineSound.pitch > 1 && !Input.GetKey(KeyCode.W))
        {
            engineSound.pitch -= 0.005f;
        }
        currSpeed = 0f;
    }

    public void Interact(CharacterController interactor, GameObject InteractVisual)
    {
        InteractVisual.transform.position = transform.position + (Vector3.up * 0.7f);

        if (Input.GetKeyDown(KeyCode.E))
        {
            FPS = interactor.GetComponent<FPSController>();

            if (playerDriving == false)
            {
                playerDriving = true;
                FPS.canMove = false;
            }
            else
            {
                playerDriving = false;
                FPS.canMove = true;
            }
        }
    }
}
