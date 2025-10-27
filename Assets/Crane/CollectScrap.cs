using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollectScrap : MonoBehaviour, IInteractable
{
    [SerializeField] Transform EPosition;
    public void Interact(CharacterController interactor, GameObject InteractVisual)
    {
        InteractVisual.transform.position = EPosition.position;

        FPSController player = interactor.GetComponent<FPSController>();
        if (Input.GetKeyDown(KeyCode.E) && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            player.scrapCollected += 1;
            player.playerHealth = player.playerHealthMax;
        }
    }
}
