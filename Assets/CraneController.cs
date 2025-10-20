using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour, IInteractable
{
    bool playerDriving = false;
    FPSController FPS;
    [SerializeField] AudioSource creaking;
    [SerializeField] Transform EPosition;
    Transform cube2;
    Transform cube3;

    void Start()
    {
        cube2 = transform.GetChild(0);
        cube3 = cube2.GetChild(0);
    }
    // Update is called once per frame
    void Update()
    {
        if (playerDriving)
        {
            if (!creaking.isPlaying)
            {
                creaking.Play();
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (cube3.localPosition.z >= -0.045f)
                {
                    cube3.transform.Translate(-Vector3.forward * Time.deltaTime);
                }
            }
            else if (Input.GetKey(KeyCode.Mouse1))
            {
                if (cube3.localPosition.z <= 0.06f)
                {
                    cube3.transform.Translate(Vector3.forward * Time.deltaTime);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    if (cube2.localPosition.y <= 0f)
                    {
                        cube2.transform.Translate(Vector3.up * Time.deltaTime);
                    }
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    if (cube2.localPosition.y >= -0.03f)
                    {
                        cube2.transform.Translate(-Vector3.up * Time.deltaTime);
                    }
                }

                if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(Vector3.forward, 20 * Time.deltaTime, Space.Self);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(Vector3.forward, -20 * Time.deltaTime, Space.Self);
                }
            }
        }
        else
        {
            creaking.Stop();
        }
    }
    public void Interact(CharacterController interactor, GameObject InteractVisual)
    {
        InteractVisual.transform.position = EPosition.position;
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
            print("Crane Interact");
        }
    }
}
