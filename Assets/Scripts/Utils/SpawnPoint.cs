using UnityEngine;

namespace Utils
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Color _color = Color.red;
        [SerializeField] private float _radius = 0.1f;
    
        private void OnDrawGizmos()
        {
            Gizmos.color = _color;
            Gizmos.DrawSphere(transform.position, _radius);
        }
    }
}