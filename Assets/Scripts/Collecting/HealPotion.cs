using UnityEngine;

namespace Collecting
{
    public class HealPotion : Collectable
    {
        [SerializeField] private int _value = 1;
        
        public int Value => _value;
    }
}