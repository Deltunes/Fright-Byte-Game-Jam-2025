using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class driveBoat : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject boat;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject InteractVisual;
    [SerializeField] AudioSource engineSound;
    bool playerDriving = false;
    FPSController FPS;

    float currSpeed;
    float currRotate;

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
                currSpeed = 16f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                currSpeed = -8f;
            }

            if (Input.GetKey(KeyCode.D))
            {
                currRotate = 10f;
                transform.Rotate(Vector3.up, 200 * Time.deltaTime, Space.Self);
            }
            if (Input.GetKey(KeyCode.A))
            {
                currRotate = -10f;
                transform.Rotate(Vector3.up, -200 * Time.deltaTime, Space.Self);
            }

            rb.AddRelativeTorque(rb.transform.up * currRotate);

            if (rb.velocity.magnitude < 100.0f)
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
