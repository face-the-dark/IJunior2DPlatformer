using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(CreatureAnimator))]
public class HeroInputReader : MonoBehaviour
{
    private Movement _movement;
    private CreatureAnimator _creatureAnimator;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _creatureAnimator = GetComponent<CreatureAnimator>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        _movement.SetDirection(direction);
        _creatureAnimator.SetDirection(direction);
    }
}