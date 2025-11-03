using UnityEngine;

namespace EnemyComponents
{
    public class Cooldown : MonoBehaviour
    {
        [SerializeField] private float _value = 1f;

        private float _delta;

        private bool _isInReset;

        private void Awake() =>
            _delta = 1f;

        private void Update()
        {
            if (_isInReset)
                _delta += Time.deltaTime;

            if (IsExpired())
                _isInReset = false;
        }

        public void Reset()
        {
            _isInReset = true;
            _delta = 0f;
        }

        public bool IsExpired() =>
            _delta >= _value;
    }
}