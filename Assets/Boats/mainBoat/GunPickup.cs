using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour, IInteractable
{
    [SerializeField] FPSController FPS;
    [SerializeField] GameObject shotgunTable;
    [SerializeField] GameObject shotgunPlayer;
    [SerializeField] Transform EPosition;

    public void Interact(CharacterController interactor, GameObject InteractVisual)
    {
        InteractVisual.transform.position = EPosition.position;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (shotgunTable.activeSelf)
            {
                if (FPS.isHolding == false)
                {
                    shotgunTable.SetActive(false);
                    shotgunPlayer.SetActive(true);
                    FPS.isHolding = true;
                }
            }
            else
            {
                shotgunTable.SetActive(true);
                shotgunPlayer.SetActive(false);
                FPS.isHolding = false;
            }    
        }
    }
}
