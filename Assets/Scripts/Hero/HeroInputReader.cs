using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Hero
{
    public class HeroInputReader : MonoBehaviour
    {
        public event Action<Vector2> DirectionChanged;
    
        public void OnMovement(InputAction.CallbackContext context)
        {
            Vector2 direction = context.ReadValue<Vector2>();
        
            DirectionChanged?.Invoke(direction);
        }
    }
}