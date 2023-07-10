using UnityEngine;

[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(NoMovement))]
[RequireComponent(typeof(CharMovement))]
[RequireComponent(typeof(CharacterInteraction))]
public class Character : MonoBehaviour
{
    [SerializeField, HideInInspector]
    private InputHandler inputs;
    [SerializeField, HideInInspector]
    private NoMovement characterMovementDisable;
    [SerializeField, HideInInspector]
    private CharMovement characterMovement;
    [SerializeField, HideInInspector]
    private CharacterInteraction characterInteraction;

    private BaseMovement currentMovementBehavior;

    private void OnValidate()
    {
        inputs = GetComponent<InputHandler>();
        characterMovementDisable = GetComponent<NoMovement>();
        characterMovement = GetComponent<CharMovement>();
        characterInteraction = GetComponent<CharacterInteraction>();
    }

    private void Awake()
    {
        SetCharacterMovement(true);
        characterInteraction.OnInteract += SetCharacterMovement;
        inputs.OnMovementInput += HandleMovementInput;
        inputs.OnInteractInput += HandleInteract;
    }

    private void HandleMovementInput(Vector2 movementInput)
    {
        currentMovementBehavior.Move(movementInput);
    }

    public void SetCharacterMovement(bool enable)
    {
        if (enable)
            currentMovementBehavior = characterMovement;
        else
            currentMovementBehavior = characterMovementDisable;
    }

    private void HandleInteract()
    {
        characterInteraction.SetInteraction(true);
    }
}