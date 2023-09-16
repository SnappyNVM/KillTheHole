using System.Collections;
using System.Linq;
using UnityEngine;
using Zenject;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField] private Mole _molePrefab;
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
        var freeHoles = GetFreeHoles();
        if (freeHoles.Length == 0)
            return;

        var selectedHole = SelectRandomHole(freeHoles);
        selectedHole.SpawnMole(_molePrefab);
    }
    private Hole SelectRandomHole(Hole[] holes) => holes[Random.Range(0, holes.Length)];

    private Hole[] GetFreeHoles()
    {
        var freeHoles = _spawner.Holes.ConvertToOneDimensional();
        return freeHoles.Where(hole => hole.IsFree).ToArray();
    }
}
