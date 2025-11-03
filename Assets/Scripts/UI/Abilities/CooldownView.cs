using System.Collections;
using UnityEngine;

namespace UI.Abilities
{
    public class CooldownView : MonoBehaviour
    {
        [SerializeField] private Cooldown _abillityCooldown;
        [SerializeField] private CooldownViewComponents _cooldownViewComponents;

        private Coroutine _fillCoroutine;

        private void OnEnable()
        {
            _abillityCooldown.InReset += OnInReset;
            _abillityCooldown.Expired += OnExpired;
        }

        private void OnDisable()
        {
            _abillityCooldown.InReset -= OnInReset;
            _abillityCooldown.Expired -= OnExpired;
        }

        private void OnInReset()
        {
            _cooldownViewComponents.Enable();
            
            StopFillCoroutine();
            
            _fillCoroutine = StartCoroutine(Unfill());
        }

        private void OnExpired()
        {
            _cooldownViewComponents.Disable();
        }

        private void StopFillCoroutine()
        {
            if (_fillCoroutine != null)
            {
                StopCoroutine(_fillCoroutine);
                _fillCoroutine = null;
            }
        }

        private IEnumerator Unfill()
        {
            while (_abillityCooldown.IsInReset)
            {
                _cooldownViewComponents.UnfillImageAndUpdateText(_abillityCooldown);

                yield return null;
            }
        }
    }
}