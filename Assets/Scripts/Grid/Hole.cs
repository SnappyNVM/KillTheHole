using UnityEngine;

public class Hole : MonoBehaviour
{
    private Mole _spawnedMole;
    public bool IsFree => _spawnedMole == null;

    public void SpawnMole(Mole molePrefab)
    {
        _spawnedMole = Instantiate(molePrefab, transform.position, Quaternion.identity);
    }
}
