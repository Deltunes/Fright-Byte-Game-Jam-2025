using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SecretCode : MonoBehaviour
{
    [SerializeField] GameObject familyGuy;
    [SerializeField] VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "family guy funny moments.mp4");
    }

    // Update is called once per frame
    void Update()
    {
        //print("test");
        if (Input.GetKey(KeyCode.F) && Input.GetKeyDown(KeyCode.G))
        {
            if (familyGuy.activeSelf == false)
            {
                familyGuy.SetActive(true);
            }
            else
            {
                familyGuy.SetActive(false);
            }
        }
    }
}
