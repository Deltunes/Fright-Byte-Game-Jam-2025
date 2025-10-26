using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRigid : MonoBehaviour
{
    [SerializeField] Transform rb;
    void LateUpdate()
    {
        transform.position = rb.position;
        transform.rotation = rb.rotation;
    }
}
