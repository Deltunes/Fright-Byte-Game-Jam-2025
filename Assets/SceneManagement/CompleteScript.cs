using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompleteScript : MonoBehaviour
{
    public TextMeshProUGUI completeText;
    public GameObject player;
    public bool complete;
    FPSController FPS;

    private void Start()
    {
        complete = false;
        FPS = player.GetComponent<FPSController>();
    }

    void Update()
    {
        if (FPS.scrapCollected == 10 && complete == false)
        {
            complete = true;
        }

        if (complete == true)
        {
            if (completeText.alpha < 1)
            {
                completeText.alpha += 0.01f;
            }
        }
    }
}
