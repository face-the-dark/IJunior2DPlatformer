using System;
using UnityEngine;

namespace Collecting
{
    public class CollectZone : MonoBehaviour
    {
        public event Action<Collider2D> OnCollect;

        private void OnTriggerEnter2D(Collider2D other) => 
            OnCollect?.Invoke(other);
    }
}