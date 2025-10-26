using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ParentPlayerToBoat : MonoBehaviour
{
    public GameObject player;
    public GameObject boat;
    public TextMeshProUGUI otu;
    // Start is called before the first frame update
    void Start()
    {
        player.transform.parent = boat.transform;
    }
}
