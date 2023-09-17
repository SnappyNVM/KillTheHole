using UnityEngine;
using System;

public class Grid
{
    private readonly Transform _gridSquare;
    private readonly int _countOfCellsBySide;
    private readonly CellPositionGenerator _cellPositionContainer;
    private readonly HoleSpawner _holeSpawner;
    private readonly MoleSpawner _moleSpawner;

    public Transform GridSquare => _gridSquare;
    public int CountOfCellsBySide => _countOfCellsBySide;
    public CellPositionGenerator CellPositionsContainer => _cellPositionContainer;
    public HoleSpawner HoleSpawner => _holeSpawner;
    public MoleSpawner MoleSpawner => _moleSpawner;

    public Grid(Transform gridSquare, int countOfCellsBySide, HoleSpawner holeSpawner, MoleSpawner moleSpawner)
    {
        if (gridSquare.transform.localScale.x != gridSquare.transform.localScale.z)
            throw new InvalidOperationException("The grid square must be square");
        _gridSquare = gridSquare;
        _countOfCellsBySide = countOfCellsBySide;
        _moleSpawner = moleSpawner;
        _holeSpawner = holeSpawner;
        _cellPositionContainer = new CellPositionGenerator(_countOfCellsBySide, _gridSquare);
    }

    public void Initalize()
    {
        _cellPositionContainer.GenerateCellPositions();
        _holeSpawner.SpawnHoles(_cellPositionContainer.CellCenters);
        _moleSpawner.Initialize();
    }
}
