using UnityEngine;

public class NoMovement : BaseMovement
{
    [SerializeField, HideInInspector]
    private Rigidbody2D rb;

    void OnValidate()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void Move(Vector2 movementInput)
    {
        rb.velocity = Vector2.zero;
    }
}