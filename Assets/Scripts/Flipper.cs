using UnityEngine;

public class Flipper : MonoBehaviour
{
    private static readonly Quaternion s_spriteDirectionRightRotation = Quaternion.Euler(0f, 0f, 0f);
    private static readonly Quaternion s_spriteDirectionLeftRotation = Quaternion.Euler(0f, 180f, 0f);
    
    protected void UpdateSpriteDirection(Vector2 direction)
    {
        if (direction.x > 0)
            transform.rotation = s_spriteDirectionRightRotation;
        else if (direction.x < 0)
            transform.rotation = s_spriteDirectionLeftRotation;
    }
}