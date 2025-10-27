using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardPosition : MonoBehaviour
{
    [SerializeField] GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.Rotate(Vector3.up, 90f);
        transform.Rotate(Vector3.forward, -15f);
    }
}
