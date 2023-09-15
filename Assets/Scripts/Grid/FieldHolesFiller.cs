using UnityEngine;
using Zenject;

public class FieldHolesFiller
{
    private Grid _grid;
    private HoleSpawner _spawner;

    public FieldHolesFiller(Grid grid, HoleSpawner spawner)
    {
        _grid = grid;
        _spawner = spawner;
        _spawner.SpawnHoles(grid.CellPositionsContainer.CellCenters);
        Debug.Log("FieldHolesFiller correctly initialized");
    }
}
