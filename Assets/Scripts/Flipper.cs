using UnityEngine;

public class Flipper : MonoBehaviour
{
    private static readonly Quaternion SpriteDirectionRightRotation = Quaternion.Euler(0f, 0f, 0f);
    private static readonly Quaternion SpriteDirectionLeftRotation = Quaternion.Euler(0f, 180f, 0f);
    
    protected void UpdateSpriteDirection(Vector2 direction)
    {
        if (direction.x > 0)
            transform.rotation = SpriteDirectionRightRotation;
        else if (direction.x < 0)
            transform.rotation = SpriteDirectionLeftRotation;
    }
}