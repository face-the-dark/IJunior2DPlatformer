using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRadius;
    
    [SerializeField] private Color _attackGizmosColor = Color.blue;

    protected void DealDamage()
    {
        Collider2D[] targets = GetTargets();

        foreach (Collider2D target in targets)
            if (target.TryGetComponent(out Health health))
                health.TakeDamage(_damage);
    }

    protected Collider2D[] GetTargets()
    {
        return Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _attackGizmosColor;
        Gizmos.DrawSphere(_attackPoint.position, _attackRadius);
    }
}