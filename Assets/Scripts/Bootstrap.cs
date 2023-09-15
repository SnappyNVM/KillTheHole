using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private int _countOfCellsBySide;
    [SerializeField] private Transform _gridSquare;
    [SerializeField] private HoleSpawner _holeSpawner;

    private Grid _grid;

    private void Awake()
    {
        InitGrid();    
    }

    private void InitGrid() => _grid = new Grid(_gridSquare, _countOfCellsBySide, _holeSpawner);
}
