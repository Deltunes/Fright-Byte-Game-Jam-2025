using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRigid : MonoBehaviour
{
    [SerializeField] Transform rigidbody;
    void Update()
    {
        transform.position = rigidbody.position;
        transform.rotation = rigidbody.rotation;
    }
}
