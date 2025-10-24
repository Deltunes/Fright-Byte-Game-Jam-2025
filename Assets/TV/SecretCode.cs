using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCode : MonoBehaviour
{
    [SerializeField] GameObject familyGuy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
