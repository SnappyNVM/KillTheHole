using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private int _countOfCellsBySide;
    [SerializeField] private Transform _gridSquare;

    private Grid _grid;

    private void Awake()
    {
        InitGrid();    
    }

    private void InitGrid() => _grid = new Grid(_gridSquare, _countOfCellsBySide);
}
