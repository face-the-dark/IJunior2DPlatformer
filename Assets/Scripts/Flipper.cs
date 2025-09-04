using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Flipper : MonoBehaviour
{
    private static readonly Quaternion s_spriteDirectionRightRotation = Quaternion.Euler(0f, 0f, 0f);
    private static readonly Quaternion s_spriteDirectionLeftRotation = Quaternion.Euler(0f, 180f, 0f);
    
    private Mover _mover;

    private void Awake() => 
        _mover = GetComponent<Mover>();

    private void OnEnable() => 
        _mover.DirectionChanged += UpdateSpriteDirection;

    private void OnDisable() => 
        _mover.DirectionChanged -= UpdateSpriteDirection;

    private void UpdateSpriteDirection(Vector2 direction)
    {
        if (direction.x > 0)
            transform.rotation = s_spriteDirectionRightRotation;
        else if (direction.x < 0)
            transform.rotation = s_spriteDirectionLeftRotation;
    }
}