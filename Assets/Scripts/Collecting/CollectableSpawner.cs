using UnityEngine;
using Utils;

namespace Collecting
{
    public class CollectableSpawner : MonoBehaviour
    {
        [SerializeField] private Collectable _collectablePrefab;
        [SerializeField] private Transform _spawnPointContainer;

        private SpawnPoint[] _spawnPoints;

        private void Awake()
        {
            _spawnPoints = _spawnPointContainer.GetComponentsInChildren<SpawnPoint>();
        
            foreach (SpawnPoint spawnPoint in _spawnPoints) 
                Instantiate(_collectablePrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}