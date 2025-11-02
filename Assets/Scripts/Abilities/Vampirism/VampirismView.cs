using UnityEngine;

namespace Abilities.Vampirism
{
    public class VampirismView : MonoBehaviour
    {
        [SerializeField] private VampirismAbility _vampirismAbility;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private void OnEnable()
        {
            _vampirismAbility.Stared += OnStarted;
            _vampirismAbility.Ended += OnEnded;
        }

        private void OnDisable()
        {
            _vampirismAbility.Stared -= OnStarted;
            _vampirismAbility.Ended -= OnEnded;
        }

        private void OnStarted() => 
            _spriteRenderer.gameObject.SetActive(true);

        private void OnEnded() => 
            _spriteRenderer.gameObject.SetActive(false);
    }
}