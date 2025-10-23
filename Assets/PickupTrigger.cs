using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour
{
    [SerializeField] GameObject debris;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag is "Boat")
        {
            debris.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag is "Boat")
        {
            Destroy(this.transform.parent.gameObject);
        }
    }
}
