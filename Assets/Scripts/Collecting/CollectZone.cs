using System;
using UnityEngine;

namespace Collecting
{
    public class CollectZone : MonoBehaviour
    {
        public event Action<Collider2D> ColliderDetected;

        private void OnTriggerEnter2D(Collider2D other) => 
            ColliderDetected?.Invoke(other);
    }
}