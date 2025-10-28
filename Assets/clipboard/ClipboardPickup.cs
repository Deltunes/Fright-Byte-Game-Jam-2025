using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardPickup : MonoBehaviour, IInteractable
{
    [SerializeField] FPSController FPS;
    [SerializeField] GameObject clipboardTable;
    [SerializeField] GameObject clipboardPlayer;
    [SerializeField] Transform EPosition;
    [SerializeField] GameObject emphasisLight;

    public void Interact(CharacterController interactor, GameObject InteractVisual)
    {
        InteractVisual.transform.position = EPosition.position;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (clipboardTable.activeSelf)
            {
                if (FPS.isHolding == false)
                {
                    if (emphasisLight.activeSelf)
                    {
                        emphasisLight.SetActive(false);
                    }
                    clipboardTable.SetActive(false);
                    clipboardPlayer.SetActive(true);
                    FPS.isHolding = true;
                }
            }
            else
            {
                clipboardTable.SetActive(true);
                clipboardPlayer.SetActive(false);
                FPS.isHolding = false;
            }
        }
    }
}
