using UnityEngine;
using UnityEngine.Events;

public class HoleSpawner : MonoBehaviour
{
    [SerializeField] private Hole _holePrefab;

    private Hole[,] _holes;

    public Hole[,] Holes => _holes;

    public void SpawnHoles(Vector3[,] cellPositions)
    {
        _holes = new Hole[cellPositions.GetLength(0), cellPositions.GetLength(1)];
        for (int x = 0; x < cellPositions.GetLength(0); x++)
            for (int z = 0; z < cellPositions.GetLength(1); z++)
                _holes[x, z] = Instantiate(_holePrefab, cellPositions[x, z], Quaternion.identity);

    }
}
