using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardPickup : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject clipboardTable;
    [SerializeField] GameObject clipboardPlayer;
    [SerializeField] Transform EPosition;

    public void Interact(CharacterController interactor, GameObject InteractVisual)
    {
        InteractVisual.transform.position = EPosition.position;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (clipboardTable.activeSelf)
            {
                clipboardTable.SetActive(false);
                clipboardPlayer.SetActive(true);
            }
            else
            {
                clipboardTable.SetActive(true);
                clipboardPlayer.SetActive(false);
            }
        }
    }
}
