using System.Collections;
using TMPro;
using UnityEngine;

namespace UI.Abilities
{
    public class AbilityDurationView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private AbilityDuration _abilityDuration;

        private Coroutine _durationCoroutine;

        private void OnEnable() => 
            _abilityDuration.Began += OnBegan;

        private void OnDisable() => 
            _abilityDuration.Began -= OnBegan;

        private void OnBegan()
        {
            StopDurationCoroutine();

            _text.gameObject.SetActive(true);
            
            _durationCoroutine = StartCoroutine(UpdateText());
        }

        private void StopDurationCoroutine()
        {
            if (_durationCoroutine != null)
            {
                StopCoroutine(_durationCoroutine);
                _durationCoroutine = null;
            }
        }

        private IEnumerator UpdateText()
        {
            while (_abilityDuration.IsEnd() == false)
            {
                _text.text = _abilityDuration.CurrentValue.ToString();
                
                yield return null;
            }
            
            _text.gameObject.SetActive(false);
        }
    }
}