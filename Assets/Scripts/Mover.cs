using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 7.0f;
    [SerializeField] private bool _isSoftMovement = true;
    [SerializeField] private float _softMovementAcceleration = 20.0f;

    private Vector2 _direction;
    
    public event Action<Vector2> DirectionChanged;
    
    public float CalculateXVelocity(float rigidbodyVelocityX)
    {
        float xVelocity = _direction.x * _moveSpeed;
        
        if (_isSoftMovement) 
            xVelocity = Mathf.Lerp(rigidbodyVelocityX, xVelocity, Time.deltaTime * _softMovementAcceleration);

        return xVelocity;
    }

    protected void SetDirection(Vector2 direction)
    {
        _direction = direction;
        
        DirectionChanged?.Invoke(direction);
    }
}