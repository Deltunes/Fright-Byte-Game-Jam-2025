using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] CanvasGroup fadeFromBlack;
    private void Start()
    {
        AudioListener.volume = 0f;
    }
    void Update()
    {
        if (fadeFromBlack.alpha > 0f)
        {
            fadeFromBlack.alpha -= 0.004f;
        }

        if (AudioListener.volume < 1f)
        {
            AudioListener.volume += 0.004f;
        }
    }
}
