using System.Collections.Generic;
using UnityEngine;

namespace Collecting
{
    public class Collector : MonoBehaviour
    {
        private List<Coin> _coins;

        private void Awake() => 
            _coins = new List<Coin>();

        public void Collect(Coin coin) => 
            _coins.Add(coin);

        public void Collect(HealPotion healPotion)
        {
            if (TryGetComponent(out Health health)) 
                health.Heal(healPotion);
        }
    }
}