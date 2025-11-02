using UnityEngine;

[RequireComponent(typeof(Cooldown))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRadius;
    [SerializeField] private Color _attackGizmosColor = Color.blue;
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _attackTargetLayer;

    private Cooldown _cooldown;

    private void Awake() =>
        _cooldown = GetComponent<Cooldown>();

    private void OnDrawGizmos()
    {
        Gizmos.color = _attackGizmosColor;
        Gizmos.DrawSphere(_attackPoint.position, _attackRadius);
    }

    public void Attack()
    {
        if (CanDealDamage())
        {
            DealDamage();
            _cooldown.Reset();
        }
    }

    public bool CanDealDamage()
    {
        Collider2D[] targets = GetTargets();

        foreach (Collider2D target in targets)
            if (target.TryGetComponent(out Health health) && _cooldown.IsExpired())
                return true;

        return false;
    }

    public int DealDamageNearest()
    {
        Health health = DefineNearestTarget(GetTargets());

        if (health is not null)
        {
            health.TakeDamage(_damage);

            return _damage;
        }

        return 0;
    }

    private void DealDamage()
    {
        Collider2D[] targets = GetTargets();

        foreach (Collider2D target in targets)
            if (target.TryGetComponent(out Health health))
                health.TakeDamage(_damage);
    }

    private Collider2D[] GetTargets() =>
        Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius, _attackTargetLayer);

    private Health DefineNearestTarget(Collider2D[] targets)
    {
        targets[0].TryGetComponent(out Health nearestHealth);

        foreach (Collider2D target in targets)
        {
            if (target.TryGetComponent(out Health health))
            {
                Transform targetPosition = health.transform;

                if (nearestHealth is null)
                {
                    nearestHealth = health;
                }
                else
                {
                    if (targetPosition.position.magnitude < nearestHealth.transform.position.magnitude)
                    {
                        nearestHealth = health;
                    }
                }
            }
        }

        return nearestHealth;
    }
}