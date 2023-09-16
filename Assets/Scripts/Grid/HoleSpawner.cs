using UnityEngine;
using Zenject;

public class HoleSpawner : MonoBehaviour
{
    [SerializeField] private Hole _holePrefab;


    public void SpawnHoles(Vector3[,] cellPositions)
    {
        for (int x = 0; x < cellPositions.GetLength(0); x++)
        { 
            for (int z = 0; z < cellPositions.GetLength(1); z++)
            {
                var hole = Instantiate(_holePrefab, cellPositions[x, z], Quaternion.identity);
            }
        }
    }
}
