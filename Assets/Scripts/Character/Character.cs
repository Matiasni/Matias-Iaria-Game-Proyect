using UnityEngine;

[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(NoMovement))]
[RequireComponent(typeof(CharMovement))]
[RequireComponent(typeof(CharacterInteraction))]
[RequireComponent(typeof(CharacterAnimationController))]
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
    [SerializeField, HideInInspector]
    private CharacterAnimationController charAnim;

    private BaseMovement currentMovementBehavior;

    private Inventory charInventory = new Inventory();

    private void OnValidate()
    {
        charAnim = GetComponent<CharacterAnimationController>();
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
        inputs.OnMovementInput += charAnim.Move;
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

    public Inventory GetInventory()
    {
        return charInventory;
    }
}