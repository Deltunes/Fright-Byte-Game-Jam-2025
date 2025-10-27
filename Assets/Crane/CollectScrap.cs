using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScrap : MonoBehaviour, IInteractable
{
    public void Interact(CharacterController interactor, GameObject InteractVisual)
    {
        FPSController player = interactor.GetComponent<FPSController>();
        if (Input.GetKeyDown(KeyCode.E) && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            player.scrapCollected += 1;
            player.playerHealth = player.playerHealthMax;
        }
    }
}
