using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour, IInteractable
{
    bool playerDriving = false;
    FPSController FPS;
    [SerializeField] AudioSource creaking;
    [SerializeField] Transform EPosition;
    [SerializeField] GameObject Thing;
    [SerializeField] Camera cameraForRay;
    //Vector3 wantPosition;
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

            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (cube3.localPosition.z >= 0.01f)
                {
                    cube3.transform.Translate(-Vector3.forward * 3 * Time.deltaTime);
                }
            }
            else if (Input.GetKey(KeyCode.Mouse1))
            {
                if (cube3.localPosition.z <= 0.09f)
                {
                    cube3.transform.Translate(Vector3.forward * 3 * Time.deltaTime);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    print(cube2.localPosition.y);
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
                    if (transform.localRotation.x >= -0.7)
                    {
                        transform.Rotate(Vector3.forward, 45 * Time.deltaTime, Space.Self);
                    }
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    if (transform.localRotation.x <= -0.05)
                    {
                        transform.Rotate(Vector3.forward, -45 * Time.deltaTime, Space.Self);
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
        InteractVisual.GetComponent<MeshRenderer>().enabled = true;
        InteractVisual.transform.LookAt(interactor.transform);
        InteractVisual.transform.Rotate(Vector3.right, 50, Space.Self);
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
        }
    }
}
