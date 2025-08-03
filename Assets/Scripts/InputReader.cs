using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(HeroAnimator))]
public class InputReader : MonoBehaviour
{
    private Mover _mover;
    private HeroAnimator _heroAnimator;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _heroAnimator = GetComponent<HeroAnimator>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        _mover.SetDirection(direction);
        _heroAnimator.SetDirection(direction);
    }
}