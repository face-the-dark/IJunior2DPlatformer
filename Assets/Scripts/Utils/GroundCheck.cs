using UnityEngine;

namespace Utils
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckRadius = 0.5f;
        [SerializeField] private Color _groundCheckColor = Color.green;

        public bool IsGrounded { get; private set; }
        
        private void Update() => 
            IsGrounded = Physics2D.OverlapCircle(transform.position, _groundCheckRadius, _groundLayer);

        private void OnDrawGizmos()
        {
            Gizmos.color = _groundCheckColor;
            Gizmos.DrawSphere(transform.position, _groundCheckRadius);
        }
    }
}