using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Collector collector))
        {
            collector.Collect(this);
            Destroy(gameObject);
        }
    }
}