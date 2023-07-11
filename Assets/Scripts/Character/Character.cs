using UnityEngine;
using System;

[RequireComponent(typeof(InputHandler))]
[RequireComponent(typeof(NoMovement))]
[RequireComponent(typeof(CharMovement))]
[RequireComponent(typeof(CharacterInteraction))]
[RequireComponent(typeof(CharacterAnimationController))]
[RequireComponent(typeof(SpawnEquipItem))]
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
    [SerializeField, HideInInspector]
    private SpawnEquipItem itemSpawner;

    private Action<Vector2> armorAnimation;

    private BaseMovement currentMovementBehavior;

    private Inventory charInventory = new Inventory();

    private void OnValidate()
    {
        itemSpawner = GetComponent<SpawnEquipItem>();
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
        inputs.OnMovementInput += charAnim.Move;
        inputs.OnMovementInput += ExecuteAnimArmor;
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

    public Inventory GetInventory()
    {
        return charInventory;
    }

    private void ExecuteAnimArmor(Vector2 vector)
    {
        armorAnimation?.Invoke(vector);
    }

    private CharacterAnimationController currentArmor;
    public void CharacterItemSpawn(string itemId)
    {
        if (currentArmor)
        {
            armorAnimation -= currentArmor.Move;
            Destroy(currentArmor.gameObject);
        }

        currentArmor = itemSpawner.SpawnItem(itemId);

        armorAnimation += currentArmor.Move;
    }
}