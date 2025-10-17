using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jaflkaj : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    float currSpeed = 0f;
    float currRotate = 0f;

    // Update is called once per frame
    void Update()
    {
        currSpeed = 0f;
        currRotate = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            currSpeed = 2f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            currSpeed = -2f;
        }
        else
        {
            currSpeed = 0f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            currRotate = 10f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currRotate = -10f;
        }

        rb.AddRelativeTorque(transform.up * currRotate, ForceMode.Force);

        if (rb.velocity.magnitude < 30.0f)
        {
            rb.AddRelativeForce(Vector3.forward * currSpeed);
        }
    }
}
