using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharMovement : BaseMovement
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField, HideInInspector]
    private Rigidbody2D rb;

    private Vector2 directionVector;

    void OnValidate()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 movement = directionVector * moveSpeed;
        rb.velocity = movement;
    }

    public override void Move(Vector2 movementInput)
    {
        directionVector = movementInput.normalized;
    }
}