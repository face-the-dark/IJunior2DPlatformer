using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HeroComponents
{
    public class HeroInputReader : MonoBehaviour
    {
        public event Action<Vector2> DirectionChanged;
        public event Action Attacked;
    
        public void OnMovement(InputAction.CallbackContext context)
        {
            Vector2 direction = context.ReadValue<Vector2>();
        
            DirectionChanged?.Invoke(direction);
        }

        public void OnDoAttack(InputAction.CallbackContext context)
        {
            if (context.performed) 
                Attacked?.Invoke();
        }
    }
}