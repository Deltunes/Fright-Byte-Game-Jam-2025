using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Update()
    {
        Vector3 position = new Vector3(target.position.x, target.position.y, target.position.z);
        transform.position = position;
    }
}
