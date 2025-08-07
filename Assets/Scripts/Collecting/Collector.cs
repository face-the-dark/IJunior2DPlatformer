using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private List<Collectable> _collectables;

    private void Awake()
    {
        _collectables = new List<Collectable>();
    }

    public void Collect(Collectable collectable)
    {
        _collectables.Add(collectable);
    }
}