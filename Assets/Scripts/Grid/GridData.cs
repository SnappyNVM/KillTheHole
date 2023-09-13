using UnityEngine;
using System;

public class GridData : MonoBehaviour
{
    [SerializeField] private int _countOfCellsBySide;
    [SerializeField] private Transform _gridSquare;
    [SerializeField] private GameObject _sphere;
    private float _gameFieldSquareSideLength;
    private Vector3[,] _cellCenters;
    private float _cellSideSize;
    private float _halfOfCell;

    private void Awake()
    {
        if (_gridSquare.localScale.x == _gridSquare.localScale.x)
            _gameFieldSquareSideLength = _gridSquare.localScale.x;
        else 
            throw new InvalidOperationException("The grid square must be square");
        
        _cellSideSize = _gameFieldSquareSideLength / _countOfCellsBySide;
        _halfOfCell = _cellSideSize * 0.5f;
        FillTheCellsPositions();
        Test();
    }

    private void FillTheCellsPositions()
    {
        _cellCenters = new Vector3[_countOfCellsBySide, _countOfCellsBySide];
        for (int x = 0; x < _countOfCellsBySide; x++)
            for (int z = 0; z < _countOfCellsBySide; z++)
                _cellCenters[x, z] = new Vector3(x * _cellSideSize - _halfOfCell, _gridSquare.position.y, z * _cellSideSize - _halfOfCell);
    }

    private void Test()
    {
        for (int x = 0; x < _countOfCellsBySide; x++)
            for (int z = 0; z < _countOfCellsBySide; z++)
            {
                Debug.Log(_cellCenters[x, z]);
                Instantiate(_sphere, _cellCenters[x, z], Quaternion.identity);
            }
    }
}
