using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class MoleSpawner : MonoBehaviour
{
    [Header("Moles")]
    [SerializeField] private Mole _easyMole;
    [SerializeField] private Mole _middleMole;
    [SerializeField] private Mole _hardMole;

    [Header ("Moles Spawn Data")]
    [SerializeField] private float _spawnCooldown;

    private ObjectTransformer _transformer;
    private Grid _grid;
    private float _currentSpawnCooldown;
    private bool[,] isCellsFree;
    private ScoreHolder _scoreHolder;

    public bool[,] IsCellsFree { get { return isCellsFree; } set { isCellsFree = value; } }

    [Inject]
    private void Construct(Grid grid, ObjectTransformer transformer, ScoreHolder scoreHolder)
    {
        _grid = grid;
        _transformer  = transformer;
        _scoreHolder = scoreHolder;
    }

    public void Initialize()
    {
        FillCellsStateTrue();
        RetransformMolePrefabs();
        _currentSpawnCooldown = _spawnCooldown;
    }

    private void FixedUpdate() => UpdateCooldown();

    private void RetransformMolePrefabs()
    {
        _transformer.SetXZScaleByCell(_easyMole.transform);
        _transformer.SetXZScaleByCell(_middleMole.transform);
        _transformer.SetXZScaleByCell(_hardMole.transform);
        _transformer.SetYScaleByCell(_easyMole.transform);
        _transformer.SetYScaleByCell(_middleMole.transform);
        _transformer.SetYScaleByCell(_hardMole.transform);
    }

    private void UpdateCooldown()
    {
        _currentSpawnCooldown -= Time.fixedDeltaTime;
        if (_currentSpawnCooldown <= 0)
        {
            SpawnMole();
            _currentSpawnCooldown = _spawnCooldown;
        }
    }

    private void FillCellsStateTrue()
    {
        isCellsFree = new bool[_grid.CellPositionsContainer.CellCenters.GetLength(0), _grid.CellPositionsContainer.CellCenters.GetLength(1)];
        for (int x = 0; x < _grid.CellPositionsContainer.CellCenters.GetLength(0); x++)
            for (int z = 0; z < _grid.CellPositionsContainer.CellCenters.GetLength(1); z++)
                isCellsFree[x, z] = true;
    }

    private void SpawnMole()
    {
        if (isCellsFree.ConvertToOneDimensional().Where(item => true).ToArray().Length == 0) return;
        var listOfFreeCells = FindAFreeCells();
        if (listOfFreeCells.Count == 0) return;
        var coordinatesToSpawn = SelectRandomFreePosition(listOfFreeCells);
        var molePrefab = SelectRandomMole();
        var mole = Instantiate(molePrefab, coordinatesToSpawn, Quaternion.identity);
        mole.Init(_scoreHolder);
        _transformer.RaiseAnObjectByCell(mole.transform);
        var valueIndexes = _grid.CellPositionsContainer.CellCenters.FoundAnIndexByValue(coordinatesToSpawn);
        isCellsFree[valueIndexes.Item1, valueIndexes.Item2] = false;
    }

    private List<Vector3> FindAFreeCells()
    {
        var listOfFreeCells = new List<Vector3>();
        for (int x = 0; x < isCellsFree.GetLength(0); x++)
            for (int z = 0; z < isCellsFree.GetLength(1); z++)
                if (isCellsFree[x, z]) listOfFreeCells.Add(_grid.CellPositionsContainer.CellCenters[x, z]);
        return listOfFreeCells;
    }

    private Vector3 SelectRandomFreePosition(List<Vector3> listOfFreeCells) => listOfFreeCells[UnityEngine.Random.Range(0, listOfFreeCells.Count)];

    private Mole SelectRandomMole()
    {
        var chance = UnityEngine.Random.Range(0, 100);
        if (chance <= 60) return _easyMole;
        else if (chance <= 92) return _middleMole;
        else return _hardMole;
    }

    public void MakeCellFree(Tuple<int, int> coordiantesToFree)
    {
        
    }
}
