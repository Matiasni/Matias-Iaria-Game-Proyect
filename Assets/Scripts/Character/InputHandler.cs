using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
    public event Action<Vector2> OnMovementInput;
    public event Action<Vector2> OnInteractInput;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        OnMovementInput?.Invoke(new Vector2(horizontalInput, verticalInput));
    }
}