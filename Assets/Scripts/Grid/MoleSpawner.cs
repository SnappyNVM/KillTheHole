using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField] private Mole _molePrefab;
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private HoleSpawner _spawner;

    private Grid _grid;
    private float _currentSpawnCooldown;
    private bool[,] isCellsFree;

    public bool[,] IsCellsFree { get { return isCellsFree; } set { isCellsFree = value; } }

    [Inject]
    private void Construct(Grid grid) => _grid = grid;

    private void Awake()
    {
        FillCellsStateTrue();
        _currentSpawnCooldown = _spawnCooldown;
    }

    private void FillCellsStateTrue()
    {
        isCellsFree = new bool[_grid.CellPositionsContainer.CellCenters.GetLength(0), _grid.CellPositionsContainer.CellCenters.GetLength(1)];
        for (int x = 0; x < _grid.CellPositionsContainer.CellCenters.GetLength(0); x++)
            for (int z = 0; z < _grid.CellPositionsContainer.CellCenters.GetLength(1); z++)
                isCellsFree[x, z] = true;
    }

    private void FixedUpdate() => UpdateCooldown();

    private void UpdateCooldown()
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
        if (isCellsFree.ConvertToOneDimensional().Where(item => true).ToArray().Length == 0) return;
        var listOfFreeCells = FindAFreeCells();
        if (listOfFreeCells.Count == 0) return;
        var coordinatesToSpawn = SelectRandomFreePosition(listOfFreeCells);
        Instantiate(_molePrefab, coordinatesToSpawn, Quaternion.identity);
        var valueIndexes = _grid.CellPositionsContainer.CellCenters.FoundAnIndexByValue(coordinatesToSpawn);
        isCellsFree[valueIndexes.Item1, valueIndexes.Item2] = false;
    }

    private Vector3 SelectRandomFreePosition(List<Vector3> listOfFreeCells) => listOfFreeCells[Random.Range(0, listOfFreeCells.Count)];

    private List<Vector3> FindAFreeCells()
    {
        var listOfFreeCells = new List<Vector3>();
        for (int x = 0; x < isCellsFree.GetLength(0); x++)
            for (int z = 0; z < isCellsFree.GetLength(1); z++)
                if (isCellsFree[x, z]) listOfFreeCells.Add(_grid.CellPositionsContainer.CellCenters[x, z]);
        return listOfFreeCells;
    }
}
