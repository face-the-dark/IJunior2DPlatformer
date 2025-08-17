using UnityEngine;
using UnityEngine.Tilemaps;

namespace Collecting
{
    public class RandomCollectableSpawner : MonoBehaviour
    {
        [SerializeField] private Collectable _collectablePrefab;
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private int _spawnCount = 20;

        private void Awake() => 
            SpawnRandom();

        private void SpawnRandom()
        {
            BoundsInt tilemapCellBounds = _tilemap.cellBounds;

            for (int i = 0; i < _spawnCount; i++)
            {
                bool isSpawned = false;

                while (isSpawned == false)
                {
                    int x = Random.Range(tilemapCellBounds.min.x, tilemapCellBounds.max.x);
                    int y = Random.Range(tilemapCellBounds.min.y, tilemapCellBounds.max.y);

                    Vector3Int cellPosition = new Vector3Int(x, y, 0);
                
                    if (_tilemap.HasTile(cellPosition) == false)
                    {
                        Vector3 cellWorldPosition = _tilemap.CellToWorld(cellPosition) + _tilemap.cellSize / 2;
                        Instantiate(_collectablePrefab, cellWorldPosition, Quaternion.identity);
                        isSpawned = true;
                    }
                }
            }
        }
    }
}