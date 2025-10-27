using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ParentPlayerToBoat : MonoBehaviour
{
    public GameObject player;
    public GameObject boat;

    void Start()
    {
        player.transform.parent = boat.transform;
    }
}
