using System.Collections;
using UnityEngine;

namespace UI
{
    public class HealthSmoothSliderView : HealthSliderView
    {
        [SerializeField] private float _smoothSpeed = 5.0f;
        
        private Coroutine _moveCoroutine;
        
        protected override void UpdateView(int currentValue, int maxValue)
        {
            StopMoveCoroutine();

            _moveCoroutine = StartCoroutine(MoveSliderValue(currentValue));
        }

        private void StopMoveCoroutine()
        {
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
                _moveCoroutine = null;
            }
        }

        private IEnumerator MoveSliderValue(int currentValue)
        {
            while (Mathf.Approximately(Slider.value, currentValue) == false)
            {
                Slider.value = Mathf.MoveTowards(Slider.value, currentValue, Time.deltaTime * _smoothSpeed);  
            
                yield return null;
            }
        }
    }
}