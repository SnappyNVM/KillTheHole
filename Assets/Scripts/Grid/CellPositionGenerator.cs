using UnityEngine;
using System;

public class CellPositionGenerator
{
    private readonly int _countOfCellsBySide;
    private readonly Transform _gridSquare;

    private  float _cellSideSize;
    private float _gameFieldSideLength;
    private Vector3[,] _cellCenters;
    private Vector3 _cellSpawnOffset;

    public Vector3[,] CellCenters => _cellCenters;

    public CellPositionGenerator(int countOfCellsBySide, Transform gridSquare)
    {
        _countOfCellsBySide = countOfCellsBySide;
        _gridSquare = gridSquare;
    }

    public void GenerateCellPositions()
    {
        CalculateGridData();
        FillTheCellCentersArray();
    }

    private void CalculateGridData()
    {
        if (_gridSquare.localScale.x == _gridSquare.localScale.z)
            _gameFieldSideLength = _gridSquare.localScale.x;
        else
            throw new InvalidOperationException("The grid square must be square");

        _cellSideSize = _gameFieldSideLength / _countOfCellsBySide;

        float halfOfCell = _cellSideSize / 2;
        float offsetByOneAxis = _gameFieldSideLength / 2 + halfOfCell;
        _cellSpawnOffset = new Vector3(offsetByOneAxis, 0, offsetByOneAxis);
    }

    private void FillTheCellCentersArray()
    {
        _cellCenters = new Vector3[_countOfCellsBySide, _countOfCellsBySide];
        for (int x = 0; x < _countOfCellsBySide; x++)
            for (int z = 0; z < _countOfCellsBySide; z++)
            {
                _cellCenters[x, z] = new Vector3
                    ((x + 1) * _cellSideSize,
                    _gridSquare.position.y,
                    (z + 1) * _cellSideSize) - _cellSpawnOffset;
                Debug.Log(_cellCenters[x, z]);
            }
        Debug.Log("Grid correctly initialized");
    }
}
