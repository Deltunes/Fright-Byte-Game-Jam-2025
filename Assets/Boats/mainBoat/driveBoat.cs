using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driveBoat : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject boat;
    [SerializeField] Rigidbody rb;
    bool playerDriving = false;
    CharacterController driver;
    FPSController FPS;

    //float maxSpeed;
    //float maxRotate;
    float currSpeed;
    float currRotate;
    //float accSpeed;
    //float accRotate;

    /*
    void Start()
    {
        maxSpeed = 10f;
        maxRotate = 20f;

        currSpeed = 0f;
        currRotate = 0f;

        accSpeed = 0.01f;
        accRotate = 0.05f;
    }
    */

    private void Update()
    {
        /*
        if (playerDriving)
        {

            if (Input.GetKey(KeyCode.W))
            {
                if (currSpeed < maxSpeed)
                {
                    currSpeed += accSpeed;
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (currSpeed > -maxSpeed)
                {
                    currSpeed -= accSpeed;
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (currRotate < maxRotate)
                {
                    currRotate += accRotate;
                }
                transform.Rotate(Vector3.up, -200 * Time.deltaTime, Space.Self);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (currRotate > -maxRotate)
                {
                    currRotate -= accRotate;
                }
                transform.Rotate(Vector3.up, 200 * Time.deltaTime, Space.Self);
            }
        }
        if (currSpeed > 0f)
        {
            currSpeed -= 0.005f;
        }
        else if (currSpeed < 0f)
        {
            currSpeed += 0.005f;
        }

        if (currRotate > 0f)
        {
            currRotate -= 0.01f;
        }
        else if (currRotate < 0f)
        {
            currRotate += 0.01f;
        }

        //rb.AddRelativeForce(Vector3.forward * currSpeed);
        //rb.AddRelativeTorque()
        boat.transform.Translate(Vector3.forward * Time.deltaTime * currSpeed);
        boat.transform.Rotate(Vector3.up, currRotate * Time.deltaTime, 0);
        //boat.transform.position = rb.position;
        */
        if (playerDriving)
        {
            currSpeed = 0f;
            currRotate = 0f;

            if (Input.GetKey(KeyCode.W))
            {
                currSpeed = 1f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                currSpeed = -1f;
            }
            else
            {
                currSpeed = 0f;
            }

            if (Input.GetKey(KeyCode.D))
            {
                currRotate = 3f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                currRotate = -3f;
            }

            rb.AddRelativeTorque(rb.transform.up * currRotate);

            if (rb.velocity.magnitude < 30.0f)
            {
                rb.AddRelativeForce(Vector3.forward * currSpeed);
            }
        }
    }

    public void Interact(CharacterController interactor)
    {
        driver = interactor;
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
