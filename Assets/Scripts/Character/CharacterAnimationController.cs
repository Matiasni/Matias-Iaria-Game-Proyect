using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    private void OnValidate()
    {
        anim = GetComponent<Animator>();
    }

    public void Move(Vector2 movementInput)
    {
        Debug.Log(movementInput.x);
        anim.SetFloat("X", movementInput.x);
        anim.SetFloat("Y", movementInput.y);
    }
}