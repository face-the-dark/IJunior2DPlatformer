using System.Collections.Generic;
using UnityEngine;

namespace Collecting
{
    public class Collector : MonoBehaviour
    {
        [SerializeField] private CollectZone _collectZone;
        
        private List<Coin> _coins;

        private void Awake() => 
            _coins = new List<Coin>();

        private void OnEnable() => 
            _collectZone.OnCollect += Collect;

        private void OnDisable() => 
            _collectZone.OnCollect -= Collect;

        private void Collect(Collider2D other)
        {
            if (other.TryGetComponent(out Coin coin)) 
                _coins.Add(coin);
            
            if (other.TryGetComponent(out HealPotion healPotion) && TryGetComponent(out Health health))
                health.HealItself(healPotion.Value);

            if (other.TryGetComponent(out Collectable collectable)) 
                Destroy(collectable.gameObject);
        }
    }
}