using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact(CharacterController interactor, GameObject InteractVisual);
}
public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    CharacterController player;
    [SerializeField] GameObject InteractVisual;

    // Update is called once per frame
    private void Start()
    {
        player = GetComponent<CharacterController>();
    }
    void Update()
    {
        InteractVisual.GetComponent<MeshRenderer>().enabled = false;
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                InteractVisual.GetComponent<MeshRenderer>().enabled = true;
                InteractVisual.transform.LookAt(player.transform);
                InteractVisual.transform.Rotate(Vector3.right, 50, Space.Self);
                interactObj.Interact(player, InteractVisual);
            }
        }
    }
}
