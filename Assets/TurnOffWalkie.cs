using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffWalkie : MonoBehaviour, IInteractable
{

    [SerializeField] Transform EPosition;
    [SerializeField] AudioClip offSound;
    private AudioSource walkieSound;

    private void Start()
    {
        walkieSound = GetComponent<AudioSource>();
    }

    public void Interact(CharacterController interactor, GameObject InteractVisual)
    {
        InteractVisual.transform.position = EPosition.position;

        if (Input.GetKeyDown(KeyCode.E) && walkieSound.isPlaying)
        {
            walkieSound.Stop();
            walkieSound.PlayOneShot(offSound);
            walkieSound.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
