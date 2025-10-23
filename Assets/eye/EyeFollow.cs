using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollow : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject player;
    Rigidbody rb;
    float eyeSpeed;

    private void Start()
    {
        eyeSpeed = 20f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        transform.Rotate(Vector3.right, -90f, Space.Self);
        rb.AddRelativeForce(Vector3.up * -eyeSpeed);
    }

    public void Interact(CharacterController interactor, GameObject InteractVisual)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Destroy(this);
        }
    }
}
