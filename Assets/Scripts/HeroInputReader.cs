using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(HeroMovement))]
[RequireComponent(typeof(HeroAnimator))]
public class HeroInputReader : MonoBehaviour
{
    private HeroMovement _heroMovement;
    private HeroAnimator _heroAnimator;

    private void Awake()
    {
        _heroMovement = GetComponent<HeroMovement>();
        _heroAnimator = GetComponent<HeroAnimator>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        _heroMovement.SetDirection(direction);
        _heroAnimator.SetDirection(direction);
    }
}