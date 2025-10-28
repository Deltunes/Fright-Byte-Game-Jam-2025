using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipPageTurn : MonoBehaviour
{
    private int pageNumber;
    private int firstPage;
    private int lastPage;

    AudioSource pageTurnSound;

    private void Start()
    {
        firstPage = 1;
        lastPage = 4;

        pageNumber = firstPage;

        pageTurnSound = transform.GetComponent<AudioSource>();
        pageTurnSound.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && pageNumber < lastPage)
        {
            pageNumber++;
            pageTurnSound.pitch = Random.Range(0.8f, 1.2f);
            pageTurnSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && pageNumber > firstPage)
        {
            pageNumber--;
            pageTurnSound.pitch = Random.Range(0.8f, 1.2f);
            pageTurnSound.Play();
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        transform.GetChild(pageNumber - 1).gameObject.SetActive(true);
    }
}
