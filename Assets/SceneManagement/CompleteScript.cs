using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompleteScript : MonoBehaviour
{
    public TextMeshProUGUI completeText;
    public GameObject player;
    FPSController FPS;

    private void Start()
    {
        FPS = player.GetComponent<FPSController>();
    }

    void Update()
    {
        if (FPS.scrapCollected == 10)
        {
            if (completeText.alpha < 1)
            {
                completeText.alpha += 0.01f;
            }
        }
    }
}
