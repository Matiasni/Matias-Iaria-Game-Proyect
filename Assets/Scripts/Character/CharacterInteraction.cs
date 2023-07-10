using UnityEngine;
using System;

public class CharacterInteraction : MonoBehaviour
{
    public event Action<bool> OnInteract;

    private bool canInteract;
    private bool interactableZone;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable")) 
        {
            interactableZone = true;
            if (canInteract)
            {
                var interactable = collision.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    canInteract = false;
                    interactable.OnInteractStart();
                    OnInteract?.Invoke(false);
                }
            }            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            interactableZone = false;
        }
    }

    public void SetInteraction(bool enable)
    {
        if (interactableZone)
            canInteract = enable;
    }
}