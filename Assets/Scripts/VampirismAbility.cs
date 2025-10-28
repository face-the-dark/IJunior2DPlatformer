using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Cooldown))]
[RequireComponent(typeof(AbilityDuration))]
public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private float _damageDeltaTime = 0.25f;
    [SerializeField] private SpriteRenderer _vampirismAbilitySprite;
    
    private Attacker _attacker;
    private Health _health;
    private Cooldown _cooldown;
    private AbilityDuration _abilityDuration;

    private Coroutine _vampirismCoroutine;

    protected virtual void Awake()
    {
        _attacker = GetComponent<Attacker>();
        _health = GetComponent<Health>();
        _cooldown = GetComponent<Cooldown>();
        _abilityDuration = GetComponent<AbilityDuration>();
    }

    protected void EnableVampirism()
    {
        if (_cooldown.IsExpired())
        {
            _vampirismAbilitySprite.enabled = true;
            
            _abilityDuration.Begin();
            
            StopVampirismCoroutine();

            _vampirismCoroutine = StartCoroutine(Vampirize());
        }
    }

    private void StopVampirismCoroutine()
    {
        if (_vampirismCoroutine != null)
        {
            StopCoroutine(_vampirismCoroutine);
            _vampirismCoroutine = null;
        }
    }

    private IEnumerator Vampirize()
    {
        while (_abilityDuration.IsEnd() == false)
        {
            if (_attacker.CanDealDamage())
            {
                int dealtDamage = _attacker.DealDamageNearest();
                _health.HealItself(dealtDamage);
            }
            
            yield return new WaitForSeconds(_damageDeltaTime);
        }
        
        _cooldown.Reset();
        _vampirismAbilitySprite.enabled = false;
    }
}