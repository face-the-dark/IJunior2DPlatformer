using UnityEngine;

public abstract class Attacker : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRadius;
    [SerializeField] private Color _attackGizmosColor = Color.blue;

    [SerializeField] protected int Damage;

    private void OnDrawGizmos()
    {
        Gizmos.color = _attackGizmosColor;
        Gizmos.DrawSphere(_attackPoint.position, _attackRadius);
    }

    public abstract bool CanDealDamage();
    
    public abstract int DealDamageNearest();
    
    protected abstract void DealDamage();

    protected Collider2D[] GetTargets() => 
        Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius);
}