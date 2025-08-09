using UnityEngine;

namespace Collecting
{
    public abstract class Collectable : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Collector collector))
            {
                AddToCollector(collector);
                Destroy(gameObject);
            }
        }

        protected abstract void AddToCollector(Collector collector);
    }
}