using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
    public event Action<Vector2> OnMovementInput;
    public event Action OnInteractInput;

    private void Update()
    {
        Movement();
        Interact();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        OnMovementInput?.Invoke(new Vector2(horizontalInput, verticalInput));
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
            OnInteractInput?.Invoke();
    }
}