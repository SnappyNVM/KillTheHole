using UnityEngine;
using Zenject;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField] private MoleHealth _molePrefab;
    [SerializeField] private float _spawnCooldown;

    private HoleSpawner _spawner;
    private float _currentSpawnCooldown;

    [Inject]
    private void Construct(HoleSpawner spawner)
    {
        _spawner = spawner;
        _currentSpawnCooldown = _spawnCooldown;
    }
    private void FixedUpdate()
    {
        _currentSpawnCooldown -= Time.fixedDeltaTime;
        if (_currentSpawnCooldown <= 0)
        {
            SpawnMole();
            _currentSpawnCooldown = _spawnCooldown;
        }
    }

    private void SpawnMole()
    {
        if (_spawner.Holes.Length == 0)
            return;
        var x = UnityEngine.Random.Range(0, _spawner.Holes.GetLength(0));
        var y = UnityEngine.Random.Range(0, _spawner.Holes.GetLength(1));
        var selectedHole = _spawner.Holes[x, y];
        if (selectedHole.IsFree)
            selectedHole.SpawnMole(_molePrefab);
        else
            SpawnMole();
    }
}
