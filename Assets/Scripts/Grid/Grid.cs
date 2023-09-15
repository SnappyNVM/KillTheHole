using UnityEngine;

public class Grid
{
    private readonly Transform _gridSquare;
    private readonly int _countOfCellsBySide;
    private readonly CellPositionsGenerator _cellPositionsContainer;
    private readonly FieldHolesFiller _fieldHolesFiller;

    public Grid(Transform gridSquare, int countOfCellsBySide)
    {
        _gridSquare = gridSquare;
        _countOfCellsBySide = countOfCellsBySide;
        _cellPositionsContainer = new CellPositionsGenerator(_countOfCellsBySide, _gridSquare);
        _fieldHolesFiller = new FieldHolesFiller(this);
    }
}
