using UnityEngine;

[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(NoMovement))]
[RequireComponent(typeof(CharMovement))]
public class Character : MonoBehaviour
{
    [SerializeField, HideInInspector]
    private InputHandler inputs;
    [SerializeField, HideInInspector]
    private NoMovement characterMovementDisable;
    [SerializeField, HideInInspector]
    private CharMovement characterMovement;

    private BaseMovement currentMovementBehavior;

    private void OnValidate()
    {
        inputs = GetComponent<InputHandler>();
        characterMovementDisable = GetComponent<NoMovement>();
        characterMovement = GetComponent<CharMovement>();
    }

    private void Awake()
    {
        EnableMovement();
        inputs.OnMovementInput += HandleMovementInput;
    }

    private void HandleMovementInput(Vector2 movementInput)
    {
        currentMovementBehavior.Move(movementInput);
    }

    public void StopMovement()
    {
        currentMovementBehavior = characterMovementDisable;
    }

    public void EnableMovement()
    {
        currentMovementBehavior = characterMovement;
    }
}