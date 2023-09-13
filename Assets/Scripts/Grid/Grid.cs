using UnityEngine;

public class Grid
{
    [SerializeField] private Transform _gridSquare;
    [SerializeField] private int _countOfCellsBySide;

    private CellPositionsContainer _cellPositionsContainer;

    private void Awake()
    {
        _cellPositionsContainer = new CellPositionsContainer(_countOfCellsBySide, _gridSquare);
    }
}
