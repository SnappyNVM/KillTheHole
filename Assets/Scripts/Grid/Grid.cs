using UnityEngine;

public class Grid
{
    private readonly Transform _gridSquare;
    private readonly int _countOfCellsBySide;
    private readonly CellPositionsGenerator _cellPositionsContainer;
    private readonly FieldHolesFiller _fieldHolesFiller;

    public CellPositionsGenerator CellPositionsContainer => _cellPositionsContainer;

    public Grid(Transform gridSquare, int countOfCellsBySide, HoleSpawner holeSpawner)
    {
        _gridSquare = gridSquare;
        _countOfCellsBySide = countOfCellsBySide;
        _cellPositionsContainer = new CellPositionsGenerator(_countOfCellsBySide, _gridSquare);
        _fieldHolesFiller = new FieldHolesFiller(this, holeSpawner);
    }
}
