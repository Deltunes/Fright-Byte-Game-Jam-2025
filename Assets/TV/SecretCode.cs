using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCode : MonoBehaviour
{
    [SerializeField] GameObject familyGuy;

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
