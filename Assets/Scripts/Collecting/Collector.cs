using System.Collections.Generic;
using UnityEngine;

namespace Collecting
{
    public class Collector : MonoBehaviour
    {
        private List<Apple> _apples;

        private void Awake() => 
            _apples = new List<Apple>();

        public void Collect(Apple collectable) => 
            _apples.Add(collectable);
    }
}