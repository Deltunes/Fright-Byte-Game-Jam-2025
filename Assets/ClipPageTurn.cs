using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipPageTurn : MonoBehaviour
{
    private int pageNumber;
    private int firstPage;
    private int lastPage;


    private void Start()
    {
        firstPage = 1;
        lastPage = 3;

        pageNumber = firstPage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && pageNumber < lastPage)
        {
            pageNumber++;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && pageNumber > firstPage)
        {
            pageNumber--;
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        transform.GetChild(pageNumber - 1).gameObject.SetActive(true);
    }
}
