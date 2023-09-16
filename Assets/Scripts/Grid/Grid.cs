using UnityEngine;

public class Grid
{
    private readonly Transform _gridSquare;
    private readonly int _countOfCellsBySide;
    private readonly CellPositionGenerator _cellPositionContainer;
    private readonly HoleSpawner _holeSpawner;
    private readonly MoleSpawner _moleSpawner;

    public CellPositionGenerator CellPositionsContainer => _cellPositionContainer;

    public Grid(Transform gridSquare, int countOfCellsBySide, HoleSpawner holeSpawner, MoleSpawner moleSpawner)
    {
        _gridSquare = gridSquare;
        _countOfCellsBySide = countOfCellsBySide;
        _moleSpawner = moleSpawner;
        _holeSpawner = holeSpawner;
        _cellPositionContainer = new CellPositionGenerator(_countOfCellsBySide, _gridSquare);
        _cellPositionContainer.GenerateCellPositions();
        _holeSpawner.SpawnHoles(_cellPositionContainer.CellCenters);
    }
}
