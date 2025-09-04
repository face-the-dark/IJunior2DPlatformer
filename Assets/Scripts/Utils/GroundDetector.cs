using UnityEngine;

namespace Utils
{
    public class GroundDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundDetectionRadius = 0.5f;
        [SerializeField] private Color _gizmosColor = Color.green;

        public bool IsGrounded { get; private set; }
        
        private void FixedUpdate() => 
            IsGrounded = Physics2D.OverlapCircle(transform.position, _groundDetectionRadius, _groundLayer);

        private void OnDrawGizmos()
        {
            Gizmos.color = _gizmosColor;
            Gizmos.DrawSphere(transform.position, _groundDetectionRadius);
        }
    }
}