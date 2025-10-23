using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScrap : MonoBehaviour, IInteractable
{
    public void Interact(CharacterController interactor, GameObject InteractVisual)
    {
        print("Please");
        if (Input.GetKeyDown(KeyCode.E) && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            interactor.GetComponent<FPSController>().scrapCollected += 1;
        }
    }
}
