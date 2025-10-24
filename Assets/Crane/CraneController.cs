using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour, IInteractable
{
    bool playerDriving = false;
    FPSController FPS;
    [SerializeField] AudioSource creaking;
    [SerializeField] Transform EPosition;
    [SerializeField] GameObject gun;
    [SerializeField] Camera cameraForRay;
    //Vector3 wantPosition;
    Transform cube1;
    Transform cube2;
    Transform cube3;

    void Start()
    {
        cube1 = transform.GetChild(0);
        cube2 = cube1.GetChild(0);
        cube3 = cube2.GetChild(0);
    }

    void Update()
    {
        /*
        Ray r = new Ray(cameraForRay.transform.position, cameraForRay.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit, 100))
        {
            wantPosition = hit.point;
            //Thing.gameObject.transform.position = (hit.point);
        }
        */
        if (playerDriving)
        {
            if (!creaking.isPlaying)
            {
                creaking.Play();
            }

            print(cube3.localPosition.z);

            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (cube3.localPosition.z >= 0.01f)
                {
                    cube3.transform.Translate(-Vector3.forward * 3 * Time.deltaTime);
                }
            }
            else if (Input.GetKey(KeyCode.Mouse1))
            {
                if (cube3.localPosition.z <= 0.075f)
                {
                    cube3.transform.Translate(Vector3.forward * 3 * Time.deltaTime);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    if (cube2.localPosition.y <= -0.055f)
                    {
                        cube2.transform.Translate(Vector3.up * 2 * Time.deltaTime);
                    }
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    if (cube2.localPosition.y >= -0.13f)
                    {
                        cube2.transform.Translate(-Vector3.up * 2 * Time.deltaTime);
                    }
                }

                //Vector3 targetDir = wantPosition - transform.GetChild(0).position;
                //print(targetDir);

                if (Input.GetKey(KeyCode.D))
                {
                    if (cube1.transform.localRotation.z <= 0.95f)
                    {
                        cube1.transform.Rotate(Vector3.forward, 45 * Time.deltaTime, Space.Self);
                    }
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    if (cube1.transform.localRotation.z >= -0.1f)
                    {
                        cube1.transform.Rotate(Vector3.forward, -45 * Time.deltaTime, Space.Self);
                    }
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
        if (Input.GetKeyDown(KeyCode.E) && !gun.activeSelf)
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
